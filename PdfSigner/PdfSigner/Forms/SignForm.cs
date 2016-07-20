using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PdfSigner.Classes;
using PdfDocument = PdfiumViewer.PdfDocument;
using Point = System.Drawing.Point;
using Florentis;
using PdfiumViewer;
using PdfSigner.Properties;

namespace PdfSigner.Forms
{
    public partial class SignForm : Form
    {
        private static Point namePoint = new Point(120, 384);

        private static Point telephonePoint = new Point(404, 380);

        private static Point addressPoint = new Point(85, 444);

        private static Point cityPoint = new Point(421, 300);

        private static Point statePoint = new Point(95, 270); // correct

        private static Point zipPoint = new Point(230, 250);

        private static Point countryPoint = new Point(428, 492);
        
        private static Point passportPoint = new Point(133, 525);

        private static Point dateOfBirthPoint = new Point(377, 525);

        private static Point emailPoint = new Point(120, 564);

        private static Point signPoint = new Point(216, 665);

        private static string regCardImgPath = Path.Combine(System.IO.Path.GetTempPath(),"Reg-Card.jpg");

        private static string inputPdf = Path.Combine(System.IO.Path.GetTempPath(), "Reg-Card.pdf");

        private static string outputPdf = Path.Combine(System.IO.Path.GetTempPath(), "Reg-Card-Output.pdf");

        private InputForm inputForm;

        private PdfViewer pdfViewer = new PdfViewer();

        private string signWhy = "The hotel assumes no responsibility for loss of personal belongings left in the room. \n\rI hereby authorize the Hotel Fortina/ Fortina Spa Resort, to debit my credit card for any extras taken.";

        public SignForm()
        {

            InitializeComponent();
            this.Icon = Resources.app_icon___bck;
            pdfViewer.Location = new Point(12, 162);
            pdfViewer.Size = new Size(781, 341);
            pdfViewer.ShowBookmarks = false;
            pdfViewer.Document = null;
            this.Controls.Add(pdfViewer);
            
            InsertGuestTextFileToPdf();
        }

        private void InsertGuestTextFileToPdf()
        {
            File.Copy("OperaPrint.pdf", inputPdf, true);

            string[] data = File.ReadAllLines(Settings.Instance.TextFilePath, Encoding.UTF8);

            Person.Instance.FullName = data[0];
            Person.Instance.GetNames();
            Person.Instance.Country = data[1];
            Person.Instance.DocumentNumber = data[2];
            Person.Instance.DateOfBirth  = DateTime.ParseExact(data[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);

            AddTextToPdf(data[0], namePoint);
            AddTextToPdf(data[1], countryPoint);
            AddTextToPdf(data[2], passportPoint);
            AddTextToPdf(data[3], dateOfBirthPoint);
            
            this.pdfViewer.Document = PdfDocument.Load(outputPdf);
        }

        private void SignForm_Load(object sender, EventArgs e)
        {
            //this.DoubleBuffered = true;
        }

        private void OpenFile()
        {
            using (var form = new OpenFileDialog())
            {
                form.Filter = "PDF Files (*.pdf)|*.pdf|Image Files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg|All Files (*.*)|*.*";
                form.RestoreDirectory = true;
                form.Title = "Open PDF File";
                form.RestoreDirectory = true;
                
                if (form.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                FileInfo fi = new FileInfo(form.FileName);
                string pdfToLoadPath = fi.FullName;

                if (fi.Extension != ".pdf")
                {
                    PdfOperations.ConvertImageToPdf(fi.FullName, inputPdf);
                    pdfToLoadPath = inputPdf;
                }

                if (pdfViewer.Document != null)
                {
                    pdfViewer.Document.Dispose();
                }

                inputPdf = Path.Combine(System.IO.Path.GetTempPath(), fi.Name);
                fi.CopyTo(inputPdf, true);

                pdfViewer.Document = PdfDocument.Load(pdfToLoadPath);
            }
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            pdfViewer.Renderer.ZoomIn();

        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            pdfViewer.Renderer.ZoomOut();
        }

        private void AddNameBtnClick(object sender, EventArgs e)
        {
            OpenSignatureInput(btnAddName.Text, namePoint);
        }

        private void AddTextToPdf(string text, Point textPont)
        {
            pdfViewer.Document?.Dispose();
            pdfViewer.Document = null;
            PdfOperations.AddTextToExistingPdf(inputPdf, outputPdf, text, textPont);
            //pdfViewer.Document = PdfDocument.Load(outputPdf);
            File.Copy(outputPdf, inputPdf, true);
        }

        private void OpenInputWindow(string labelText, Point point)
        {
            if (inputForm != null)
            {
                inputForm.Dispose();
            }

            inputForm = new InputForm(labelText);
            DialogResult result = DialogResult.None;
            if (!inputForm.Visible)
            {
                result = inputForm.ShowDialog(this);
            }

            if (result != DialogResult.OK)
            {
                return;
            }

            AddTextToPdf(inputForm.TextBoxText, point);
        }

        private void btnOpenPdf_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pdfViewer.Document != null)
            {
                pdfViewer.Document.Dispose();
                pdfViewer.Document = null;
            }
        }

        private void btnSignature_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(signWhy, signPoint);
        }

        private void OpenSignatureInput(string why, Point inputPoint)
        {
            SigCtl sigCtl = new SigCtl();
            DynamicCapture dc = new DynamicCaptureClass();
            DynamicCaptureResult res = dc.Capture(sigCtl, " ", why, null, null);

            if (res == DynamicCaptureResult.DynCaptOK)
            {
                SigObj sigObj = (SigObj) sigCtl.Signature;
                sigObj.set_ExtraData("AdditionalData", "C# test: Additional data");
                String filename = Path.Combine(System.IO.Path.GetTempPath(), "data.png");

                try
                {
                    sigObj.RenderBitmap(filename, 200, 200, "image/png", 1f, 0xff0000, 0xffffff, 10.0f, 10.0f,
                        RBFlags.RenderOutputFilename | RBFlags.RenderColor32BPP | RBFlags.RenderEncodeData |
                        RBFlags.RenderBackgroundTransparent);

                    pdfViewer.Document?.Dispose();
                    pdfViewer.Document = null;

                    PdfOperations.InsertImageAt(File.ReadAllBytes(filename), inputPdf, outputPdf, inputPoint);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            pdfViewer.Document = PdfDocument.Load(outputPdf);
            File.Copy(outputPdf, inputPdf, true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnCity.Text, cityPoint);
        }

        private void btnTelephone_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnTelephone.Text, telephonePoint);
        }

        private void btnAddress_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnAddress.Text, addressPoint);
        }

        private void btnStateProv_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnStateProv.Text, statePoint);
        }

        private void btnZipCode_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnZipCode.Text, zipPoint);
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnCountry.Text, countryPoint);
        }

        private void btnPassportIdCard_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnPassportIdCard.Text, passportPoint);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnDateOfBirth.Text, dateOfBirthPoint);
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            OpenSignatureInput(btnEmail.Text, emailPoint);
        }

        private void SaveBtnClick(object sender, EventArgs e)
        {
            SaveFileDialog openFile = new SaveFileDialog();
            openFile.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*";
            openFile.RestoreDirectory = true;
            openFile.FileName = DataFunctions.TransformPersonData();
            openFile.Title = "Open PDF File";
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            FileInfo fi = new FileInfo(openFile.FileName);

            File.Copy(outputPdf, fi.FullName, true);
        }
    }
}
