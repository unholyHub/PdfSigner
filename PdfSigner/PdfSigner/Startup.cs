using System;
using System.Diagnostics;
using System.Windows.Forms;
using PdfSigner.Classes;

namespace PdfSigner
{
    static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var docReaderProcess = Process.GetProcessesByName("PdfSigner");

            var mainProcess = Process.GetCurrentProcess();

            foreach (var currentProcess in docReaderProcess)
            {
                if (currentProcess.Id != mainProcess.Id)
                {
                    currentProcess.Kill();
                }
            }

            // Show the system tray icon.					
            using (ProcessIcon pi = new ProcessIcon())
            {
                pi.Display();

                // Make sure the application runs!
                Application.Run();
            }
        }
    }
}
