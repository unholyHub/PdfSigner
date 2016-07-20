﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using PdfSigner.Properties;

namespace PdfSigner
{
    /// <summary>
    /// Class for checking and notifying the user for newer version of the application.
    /// </summary>
    public class UpdateNotifier : IDisposable
    {
        public bool IsThereNewVersion = false;

        /// <summary>
        /// The regular expression pattern for searching the version number in GitHub Release page. 
        /// </summary>
        private const string RegExpPattern = @"(?<=\<span.*\>)\d\.\d\.\d.\d(?=\</span\>)";

        /// <summary>
        /// The date and time format for the <see cref="DateTime"/>.
        /// </summary>
        private const string DateTimeFormat = "dd-MM-yyyy HH:mm:ss";

        /// <summary>
        /// The sync root to ensure that only one instance is running.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        /// Instance of the <see cref="UpdateNotifier"/> class.
        /// </summary>
        private static UpdateNotifier instance;

        /// <summary>
        /// Field for storing the GitHub release page for the application version.
        /// </summary>
        private readonly Uri githubReleasesUri = new Uri(@"https://github.com/unholyHub/PdfSigner/releases");

        /// <summary>
        /// Field for storing the <see cref="WebClientExtent"/> for making web requests.
        /// </summary>
        private WebClientExtent githubWebClient;

        /// <summary>
        /// Prevents a default instance of the <see cref="UpdateNotifier"/> class from being created.
        /// </summary>
        private UpdateNotifier()
        {
            const string lastUpdateCheckFilePath = "last-update-check.dat";

            this.UpdateFilePath = lastUpdateCheckFilePath;

            try
            {
                if (!File.Exists(this.UpdateFilePath))
                {
                    File.CreateText(this.UpdateFilePath).Close();
                }

            }
            catch (IOException ex)
            {
                return;
            }

            this.LoadLastUpdateCheckFromFile();
        }

        /// <summary>
        /// Gets instance of the <see cref="UpdateNotifier"/> class.
        /// </summary>
        public static UpdateNotifier Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    return instance ?? (instance = new UpdateNotifier());
                }
            }
        }

        /// <summary>
        /// Gets the update file path where its stored the last update check.
        /// </summary>
        private string UpdateFilePath { get; }

        /// <summary>
        /// Gets or sets the version that was downloaded from GitHub.
        /// </summary>
        private string DownloadedVersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the downloaded Html from the <see cref="WebClientExtent"/>.
        /// </summary>
        private string DownloadedGithubReleasesHtml { get; set; }

        /// <summary>
        /// Gets or sets last update perform check.
        /// </summary>
        private DateTime LastUpdateCheck { get; set; }

        /// <summary>
        /// Performs check for version and notifies the user for new version of the application.
        /// </summary>
        /// <param name="isMainLoad">Is the main load of the application. </param>
        public void NotifyForUpdate()
        {
            this.DownloadVersionNumberFromGitHub();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ComponentModel.Component"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.githubWebClient.Dispose();
            }
        }

        /// <summary>
        /// Informs the user for a new version of the application.
        /// </summary>
        private static void InformAboutNewVersion()
        {
            //TODO: start update process
            //MessageBox.Show("Informaboutnewversion");
            Process.Start("PdfSignerUpdater.exe");
        }

        /// <summary>
        /// Loading the date and time from the text file in the application data directory.
        /// </summary>
        private void LoadLastUpdateCheckFromFile()
        {
            DataFunctions.LoadStringFromFile(this.UpdateFilePath);
            string loadedString = DataFunctions.LoadedString;

            if (string.IsNullOrEmpty(loadedString))
            {
                loadedString = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            }

            DateTime outputDateTime;
            bool result = DateTime.TryParse(loadedString, out outputDateTime);

            if (!result)
            {
                return;
            }

            TimeSpan timeDifference = DateTime.Now - outputDateTime;

            if (timeDifference.Hours >= 24)
            {
                InformAboutNewVersion();
            }

            DataFunctions.SaveTextDataToFile(this.UpdateFilePath, loadedString, false);
        }

        /// <summary>
        /// Performs a comparison between the <see cref="DownloadedVersionNumber"/> with the <see cref="Settings.Instance.AssemblyVersion"/>.
        /// </summary>
        private void CompareVersionNumbers()
        {
            Version currentVersion = new Version(Settings.Instance.AssemblyVersion);
            Version downloadedVersion = new Version(this.DownloadedVersionNumber);

            int result = currentVersion.CompareTo(downloadedVersion);

            switch (result)
            {
                case -1:
                    {
                        InformAboutNewVersion();
                        break;
                    }

                case 0:
                case 1:
                    {
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// From the <see cref="DownloadedGithubReleasesHtml"/> matches the first found version match.
        /// </summary>
        private void GetDownloadedVersionNumber()
        {
            Match match = Regex.Match(
                this.DownloadedGithubReleasesHtml,
                RegExpPattern,
                RegexOptions.IgnoreCase);

            if (match.Success)
            {
                this.DownloadedVersionNumber = match.Value;
            }
        }

        /// <summary>
        /// Downloads the latest version from GitHub release page.
        /// </summary>
        private void DownloadVersionNumberFromGitHub()
        {
            this.githubWebClient = new WebClientExtent(3000);

            this.githubWebClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(this.GitHubWebClientDownloadStringCompleted);
            this.githubWebClient.DownloadStringAsync(this.githubReleasesUri);
        }

        /// <summary>
        /// Occurs when an asynchronous resource-download operation completes.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="DownloadStringCompletedEventArgs"/> e.</param>
        private void GitHubWebClientDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null)
            {
                return;
            }

            string result = e.Result;

            if (string.IsNullOrEmpty(result))
            {
                return;
            }

            this.DownloadedGithubReleasesHtml = result;
            this.GetDownloadedVersionNumber();
            this.CompareVersionNumbers();
            this.SaveLastUpdateCheckToFile();
        }

        /// <summary>
        /// Saving the last update check date and time to the application data file.
        /// </summary>
        private void SaveLastUpdateCheckToFile()
        {
            this.LastUpdateCheck = DateTime.Now;
            DataFunctions.SaveTextDataToFile(this.UpdateFilePath, this.LastUpdateCheck.ToString(DateTimeFormat, CultureInfo.InvariantCulture), false);
        }
    }
}
