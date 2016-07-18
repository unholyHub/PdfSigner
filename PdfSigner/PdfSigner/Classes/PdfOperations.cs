using System.Drawing;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace PdfSigner.Classes
{
    public static class PdfOperations
    {
        public static void InsertImageAt(byte[] inputBytes, string inputPdfPath, string outputPdfPath, Point signPoint)
        {
            byte[] imageBytes = inputBytes;

            using (Stream inputPdfStream = new FileStream(inputPdfPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream inputImageStream = new MemoryStream(imageBytes))
            using (
                Stream outputPdfStream = new FileStream(outputPdfPath, FileMode.Create, FileAccess.Write, FileShare.None)
                )
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);

                var pageSize = reader.GetPageSize(1);

                float x = signPoint.X;
                float y = signPoint.Y;



                Image image = Image.GetInstance(inputImageStream);
                image.ScaleToFit(150, 150);

                //x += 113;
                //y =  (int) ((pageSize.Height - y) + (image.Height / 2));

                y = (((pageSize.Height - y)) - 75f);

                //image.SetAbsolutePosition(signPoint.X, signPoint.Y - image.Height / 2);
                image.SetAbsolutePosition(x, y);

                //image.SetAbsolutePosition(pageSize.Width - image.Width, pageSize.Height - image.);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }
        }

        public static void AddTextToExistingPdf(string inputPdfPath, string outputPdfPath, string textToAdd, Point point)
        {
            //variables
            string pathin = inputPdfPath;
            string pathout = outputPdfPath;

            //create PdfReader object to read from the existing document
            using (PdfReader reader = new PdfReader(pathin))
            //create PdfStamper object to write to get the pages from reader 
            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(pathout, FileMode.Create)))
            {
                //select two pages from the original document
                reader.SelectPages("1-2");

                //gettins the page size in order to substract from the iTextSharp coordinates
                var pageSize = reader.GetPageSize(1);
            
                // PdfContentByte from stamper to add content to the pages over the original content
                PdfContentByte pbover = stamper.GetOverContent(1);

                //add content to the page using ColumnText
                Font font = new Font();
                font.Size = 14;

                //setting up the X and Y coordinates of the document
                int x = point.X;
                int y = point.Y;

                x += 113;
                y = (int) (pageSize.Height - y);

                ColumnText.ShowTextAligned(pbover, Element.ALIGN_RIGHT, new Phrase(textToAdd, font), x, y, 0);
            }
        }

        public static void ConvertImageToPdf(string srcImagePath, string destPdfFilePath)
        {
            Rectangle pageSize = null;

            using (var srcImage = new Bitmap(srcImagePath))
            {
                pageSize = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            }

            using (var ms = new MemoryStream())
            {
                var document = new Document(pageSize, 0, 0, 0, 0);
                PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                var image = Image.GetInstance(srcImagePath);

                document.Add(image);
                document.Close();

                File.WriteAllBytes(destPdfFilePath, ms.ToArray());

                document.Dispose();
            }
        }
    }
}
