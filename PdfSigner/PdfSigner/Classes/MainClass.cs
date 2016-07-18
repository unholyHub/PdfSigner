using System;
using System.Timers;
using System.Windows.Forms;
using PdfSigner.Forms;
using PdfSigner.Properties;
using Timer = System.Timers.Timer;

namespace PdfSigner.Classes
{
    public class ProcessIcon : IDisposable
    {
        ContextMenuStrip contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
        ToolStripMenuItem miStartLiking = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripSeparator toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripMenuItem miOptions = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripSeparator toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripMenuItem miAbout = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripSeparator toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        ToolStripMenuItem miExit = new System.Windows.Forms.ToolStripMenuItem();

        /// <summary>
        /// The NotifyIcon object.
        /// </summary>
        NotifyIcon ni;
        
        /// <summary>
        /// The update <see cref="System.Timers.Timer"/> for notifying the user for new version.
        /// </summary>
        private static System.Timers.Timer updateTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProcessIcon"/> class.
        /// </summary>
        public ProcessIcon()
        {
            // Instantiate the NotifyIcon object.
            ni = new NotifyIcon();

            InitUpdateTimer();
            InitContextMenu();

            Settings.Instance.Load();
        }

        /// <summary>
        /// Initialization for the blocking <see cref="System.Timers.Timer"/>.
        /// </summary>
        private static void InitUpdateTimer()
        {
            updateTimer = new System.Timers.Timer();
            updateTimer.Interval = 24 * 60 * 60 * 1000; // 24 hours
            updateTimer.Elapsed += new ElapsedEventHandler(UpdateNotifyTimerElapsed);
            updateTimer.Start();
        }

        /// <summary>
        /// Notifying the user for a new update if available. 
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private static void UpdateNotifyTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateNotifier.Instance.NotifyForUpdate();
        }


        private void InitContextMenu()
        {

            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartLiking,
            this.toolStripSeparator2,
            this.miOptions,
            this.toolStripSeparator1,
            this.miAbout,
            this.toolStripSeparator3,
            this.miExit});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 110);

            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miStartLiking,
            this.toolStripSeparator2,
            this.miOptions,
            this.toolStripSeparator1,
            this.miAbout,
            this.toolStripSeparator3,
            this.miExit});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(164, 110);
            // 
            // miStartLiking
            // 
            this.miStartLiking.Name = "miStartLiking";
            this.miStartLiking.Size = new System.Drawing.Size(163, 22);
            this.miStartLiking.Text = "Open PDF Signer";
            this.miStartLiking.Click += new System.EventHandler(this.OpenPdfSignFormMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // miOptions
            // 
            this.miOptions.Name = "miOptions";
            this.miOptions.Size = new System.Drawing.Size(163, 22);
            this.miOptions.Text = "Options";
            this.miOptions.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(163, 22);
            this.miAbout.Text = "About";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(163, 22);
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
        }

        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            UnlockForm unlockForm = new UnlockForm();

            unlockForm.ShowDialog();

            if (!unlockForm.Result)
            {
                return;
            }

            Dispose();
            Application.Exit();
        }

        private static OptionsForm OptionsForm = new OptionsForm();


        private void miAbout_Click(object sender, EventArgs e)
        {
            if (OptionsForm.Visible)
            {
                OptionsForm.Focus();
                return;
            }
            
            OptionsForm.ShowDialog();
        }

        private void OpenPdfSignFormMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                using (SignForm s = new SignForm())
                {
                    s.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException);
            }
        }

        /// <summary>
        /// Displays the icon in the system tray.
        /// </summary>
        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.app_icon___bck;
            ni.Text = "Pdf Signer";
            ni.Visible = true;

            // Attach a context menu.
            ni.ContextMenuStrip = contextMenuStrip;
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            ni.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
                //Process.Start("explorer", null);
            }
        }
    }
}
