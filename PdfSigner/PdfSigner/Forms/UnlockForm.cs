using System;
using System.Drawing;
using System.Windows.Forms;

namespace PdfSigner.Forms
{
    public partial class UnlockForm : Form
    {
        private static string unlockCode = string.Empty;

        public UnlockForm()
        {
            this.InitializeComponent();

#if DEBUG
            unlockCode = string.Empty;
#else
            unlockCode = DateTime.Now.ToString("dd") + @"varna";
#endif
        }

        private static string customMsg = "Enter code to unlock:";

        private const string ErrorMsg = "The entered code is invalid!";

        private void UnlockBtnClick(object sender, EventArgs e)
        {
            if (unlockCode == this.txtPassword.Text)
            {
                this.Result = true;
                this.Close();
                return;
            }

            this.Result = false;

            if (ErrorMsg != string.Empty)
            {
                MessageBox.Show(
                    ErrorMsg,
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            //this.Close();
            this.txtPassword.Text = string.Empty;
        }

        private void CUnlockBoxLoad(object sender, EventArgs e)
        {
            this.Result = false;
            this.lblEnterCode.Text = customMsg;
            //this.Icon = Resources.app_icon;
            this.lblEnterCode.TextAlign = ContentAlignment.MiddleRight;
        }

        public string CustomMessage
        {
            private get
            {
                return customMsg;
            }
            set
            {
                customMsg = value;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool Result { get; private set; }

        private void OnKeyDownTextBox1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.UnlockBtnClick(sender, e);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Result = false;
                this.DialogResult = DialogResult.Cancel;
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            else
            {
                this.OnKeyDown(e);
            }
        }
    }
}
