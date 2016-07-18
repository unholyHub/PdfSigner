using System;
using System.Windows.Forms;
using PdfSigner.Forms;
using PdfSigner.Properties;

namespace PdfSigner
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Allowing the <see cref="MainForm"/> to be closed.
        /// </summary>
        private static bool allowClose;

        /// <summary>
        /// Allowing to the <see cref="MainForm"/> to be visible or not.
        /// </summary>
        private bool allowVisible = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
        
            this.InitializeComponent();
            OptionsForm = new OptionsForm();

            niTray.Icon = Resources.app_icon;

            bool result = Settings.Instance.Load();

            if (!result)
            {
                return;
            }
        }

        /// <summary>
        /// Occurs before the form is closed.
        /// </summary>
        /// <param name="e">The <see cref="FormClosedEventArgs"/> e.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!allowClose)
            {
                this.Hide();

                if (e != null)
                {
                    e.Cancel = true;
                }
            }

            base.OnFormClosing(e);
        }

        /// <summary>
        /// Sets the control to the specified visible state.
        /// </summary>
        /// <param name="value"><see>
        ///         <cref>true</cref>
        ///     </see>
        ///     to make the control visible; otherwise, <see>
        ///         <cref>false</cref>
        ///     </see>
        /// .</param>
        protected override void SetVisibleCore(bool value)
        {
            if (!allowVisible)
            {
                value = false;

                if (!this.IsHandleCreated) try
                    {
                        CreateHandle();
                    }
                    catch (InvalidOperationException invalidOperationException)
                    {
                        //LogSystem.Instance.AddToLog(invalidOperationException, false);
                    }
            }

            base.SetVisibleCore(value);
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for starting the blocking.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void OpenPdfSignFormMenuItemClick(object sender, EventArgs e)
        {
            using (SignForm s = new SignForm())
            {
                s.ShowDialog();
            }
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for stopping the blocking.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void StopBlockingMenuItemClick(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for displaying the <see cref="AddWindowNameForm"/> form.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void AddWindowNameMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                //AddWindowNameForm = new AddWindowNameForm();
                //AddWindowNameForm.ShowDialog(this);
            }
            catch (ArgumentNullException argumentNullException)
            {
                //LogSystem.Instance.AddToLog(argumentNullException, false);
            }
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for executing the <see cref="UpdateNotifier"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void UpdateCheckMenuItemClick(object sender, EventArgs e)
        {
            //UpdateNotifier.Instance.NotifyForUpdate();
        }

        /// <summary>
        /// Click event for <see cref="MenuItem"/> for exiting the application.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> e.</param>
        private void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            UnlockForm unlockForm = new UnlockForm();

            unlockForm.ShowDialog();

            if (!unlockForm.Result)
            {
                return;
            }

            ApplicationExit();
        }

        private void ApplicationExit()
        {
            allowClose = true;
            this.Dispose();
            Application.Exit();
        }

        /// <summary>
        /// Double mouse click event for showing the <see cref="OptionsForm"/>.
        /// </summary>
        /// <param name="sender">The <see cref="object"/> sender.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> e.</param>
        private void TrayNotifyIconMouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="OptionsForm"/>.
        /// </summary>
        private static OptionsForm OptionsForm { get; set; }

        private void miAbout_Click(object sender, EventArgs e)
        {
            if (OptionsForm.Visible)
            {
                OptionsForm.Focus();
                return;
            }

            OptionsForm = new OptionsForm();
            OptionsForm.ShowDialog(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Settings.Instance.Load();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnlockForm form = new UnlockForm();

            form.ShowDialog();

            if (form.Result)
            {
                MessageBox.Show("close");
            }
        }
    }
}
