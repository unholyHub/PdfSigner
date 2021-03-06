﻿using System.Windows.Forms;
using PdfSigner.Properties;

namespace PdfSigner
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            this.Icon = Resources.app_icon___bck;
            this.Name = "Options";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnTextFileLocation_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.RestoreDirectory = true;
            openFile.FileName = "Guest.txt";
            openFile.Filter = "TXT files|*.txt";

            DialogResult result = openFile.ShowDialog(this);

            if (result != DialogResult.OK)
            {
                return;
            }

            this.txtTextFileLocation.Text = openFile.FileName;
        }

        private void btnOkay_Click(object sender, System.EventArgs e)
        {
            Settings.Instance.TextFilePath = this.txtTextFileLocation.Text;
            Settings.Instance.PdfFileNameFormat = this.txtPdfFileNameFormat.Text;

            Settings.Instance.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void OptionsForm_Load(object sender, System.EventArgs e)
        {
        }

        private void OptionsForm_Shown(object sender, System.EventArgs e)
        {
            this.txtTextFileLocation.Text = Settings.Instance.TextFilePath;
            this.txtPdfFileNameFormat.Text = Settings.Instance.PdfFileNameFormat;

        }
    }
}
