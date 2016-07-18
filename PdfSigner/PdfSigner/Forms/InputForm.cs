using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PdfSigner.Forms
{
    public partial class InputForm : Form
    {
        public string LabelText { get; set; }

        public string TextBoxText { get; set; }

        private Process onScreenKeyboardProc;

        public InputForm(string labelText)
        {
            InitializeComponent();
            this.LabelText = labelText;
        }

        private void OpenKeyboardClick(object sender, EventArgs e)
        {
            string progFiles = @"C:\Program Files\Common Files\Microsoft Shared\ink";
            string onScreenKeyboardPath = Path.Combine(progFiles, "TabTip.exe");
            onScreenKeyboardProc = Process.Start(onScreenKeyboardPath);
        }

        private void OkBtnClick(object sender, EventArgs e)
        {
            this.TextBoxText = txtInputText.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void InputForm_Closing(object sender, EventArgs e)
        {
            this.Dispose(true);

        }
    }
}
