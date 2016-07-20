using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace PdfSignerUpdater
{
    public class Startup
    {
        /// <summary>
        /// Gets or sets the version that was downloaded from GitHub.
        /// </summary>
        private static string DownloadedVersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the downloaded Html from the <see cref="WebClientExtent"/>.
        /// </summary>
        private static string DownloadedGithubReleasesHtml { get; set; }

        /// <summary>
        /// The regular expression pattern for searching the version number in GitHub Release page. 
        /// </summary>
        private const string RegExpPattern = @"(?<=\<span.*\>)\d\.\d\.\d.\d(?=\</span\>)";

        /// <summary>
        /// Field for storing the <see cref="WebClientExtent"/> for making web requests.
        /// </summary>
        private static WebClientExtent githubWebClient;

        /// <summary>
        /// Field for storing the GitHub release page for the application version.
        /// </summary>
        private static readonly Uri githubReleasesUri = new Uri(@"https://github.com/unholyHub/PdfSigner/releases");

        private static readonly string fileName = "PdfSigner.exe";

        static void Main()
        {
            Console.Title = "PdfSigner Updater";

            //const int millisecondsTimeout = 5 * 1000; // 5 secs
            //Thread.Sleep(millisecondsTimeout);

            Thread th = new Thread(KillPdfSigner);
            th.Start();

            DownloadVersionNumberFromGitHub();

            using (WebClientExtent fileClientExtent = new WebClientExtent(3000))
            {
                fileClientExtent.DownloadFile(
                    string.Format(
                        "https://github.com/unholyHub/PdfSigner/releases/download/{0}/PdfSigner.exe",
                        DownloadedVersionNumber),
                    fileName);
            }

            Process.Start(fileName);
        }

        private static void KillPdfSigner()
        {
            foreach (Process process in Process.GetProcessesByName("PdfSigner"))
            {
                process.Kill();
            }
        }

        private static void DownloadVersionNumberFromGitHub()
        {
            using (WebClientExtent client = new WebClientExtent(3000))
            {

                string reply = client.DownloadString(githubReleasesUri);
                GitHubWebClientDownloadStringCompleted(reply);
            }
        }

        /// <summary>
        /// From the <see cref="DownloadedGithubReleasesHtml"/> matches the first found version match.
        /// </summary>
        private static void GetDownloadedVersionNumber()
        {
            Match match = Regex.Match(
                DownloadedGithubReleasesHtml,
                RegExpPattern,
                RegexOptions.IgnoreCase);

            if (match.Success)
            {
                DownloadedVersionNumber = match.Value;
            }
        }

        /// <summary>
        /// Occurs when an asynchronous resource-download operation completes.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="DownloadStringCompletedEventArgs"/> e.</param>
        private static void GitHubWebClientDownloadStringCompleted(string input)
        {
            if (input == null)
            {
                return;
            }

            string result = input;

            DownloadedGithubReleasesHtml = result;
            GetDownloadedVersionNumber();
        }
    }
}
