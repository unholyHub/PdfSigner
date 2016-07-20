using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace PdfSigner
{
    public class Settings
    {
        /// <summary>
        /// The instance of the settings.
        /// </summary>
        private static Settings instance;

        /// <summary>
        /// Gets the instance of the settings.
        /// </summary>
        public static Settings Instance
        {
            get
            {
                lock (SyncRoot)
                {
                    if (instance == null)
                    {
                        instance = new Settings();
                    }

                    return instance;
                }
            }
        }

        private static readonly object SyncRoot = new object();

        private readonly string applicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        
        /// <exception cref="AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception>
        public string SettingsPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Settings.dat");

        public string LogPath { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.dat");

        public string SourceFolder { get; set; }

        public string DestinationFolder { get; set; }

        public string TextFilePath { get; set; }

        public string PdfFileNameFormat { get; set; }



        public int SavingDelay { get; set; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public string AssemblyVersion
        {
            get
            {
                return this.applicationVersion;
            }
        }

        public void Save()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(TextFilePath);
            sb.AppendLine(PdfFileNameFormat);

            using (StreamWriter writer = new StreamWriter(SettingsPath, false))
            {
                writer.WriteLine(sb.ToString());
            }
        }

        /// <exception cref="AppDomainUnloadedException">The operation is attempted on an unloaded application domain. </exception>
        public bool Load()
        {
            if (!File.Exists(SettingsPath))
            {
                return false;
            }

            string[] load = File.ReadAllLines(SettingsPath);

            try
            {
                TextFilePath = load[0];
                PdfFileNameFormat = load[1];
            }
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }


            return true;
        }
    }
}