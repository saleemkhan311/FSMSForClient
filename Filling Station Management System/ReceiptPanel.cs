using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;

namespace Filling_Station_Management_System
{
    public partial class ReceiptPanel : KryptonForm
    {
        public string ref_no { get; set; }
        public string malikName { get; set; }
        public string DateTime { get; set; }
        public string wazan { get; set; }
        public string miqdar { get; set; }
        public string khoraki { get; set; }
        public string safiMiqdar { get; set; }
        public string rateFiLiter { get; set; }
        public string kulRaqam { get; set; }
        public string mazdoori { get; set; }
        public string safiRaqam { get; set; }
        public string sabqaRaqam { get; set; }
        public string totalRaqam { get; set; }
        public string raqamWasoolValue1 { get; set; }
        public string raqamWasoolValue2 { get; set; }
        public string raqamWasoolValue3 { get; set; }
        public string raqamWasoolValue4 { get; set; }
        public string raqamWasoolValue5 { get; set; }
        public string raqamWasoolTafseel1 { get; set; }
        public string raqamWasoolTafseel2 { get; set; }
        public string raqamWasoolTafseel3 { get; set; }
        public string raqamWasoolTafseel4 { get; set; }
        public string raqamWasoolTafseel5 { get; set; }
        public string baqaya { get; set; }
        public ReceiptPanel()
        {
            InitializeComponent();
        }

        public void GenerateReceipt()
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptPanel_Load(object sender, EventArgs e)
        {
            Assignation();
        }

        private void Assignation()
        {

            RefLabel.Text = "Ref# :------------------------ " + ref_no;
            MalikNameLabel.Text = malikName;
            WazanLabel.Text = wazan;
            MiqdarLabel.Text = miqdar;
            KhorakiLabel.Text = khoraki;
            SafiMiqdarLabel.Text = safiMiqdar;
            RateFiLiterLabel.Text = rateFiLiter;
            KulRaqamLAbel.Text = kulRaqam;
            MazdooriLabel.Text = mazdoori;
            SabqaRaqamLabel.Text = safiRaqam;
            SabqaRaqamLabel.Text = safiRaqam;
            TotalRaqamLabel.Text = totalRaqam;

            RaqamWasoolValue1Label.Text = raqamWasoolValue1;
            RaqamWasoolTafseel1Label.Text = raqamWasoolTafseel1;

            RaqamWasoolValue2Label.Text = raqamWasoolValue2;
            RaqamWasoolTafseel2Label.Text = raqamWasoolTafseel2;

            RaqamWasoolValue3Label.Text = raqamWasoolValue3;
            RaqamWasoolTafseel3Label.Text = raqamWasoolTafseel3;

            RaqamWasoolValue4Label.Text = raqamWasoolValue4;
            RaqamWasoolTafseel4Label.Text = raqamWasoolTafseel4;

            RaqamWasoolValue5Label.Text = raqamWasoolValue5;
            RaqamWasoolTafseel5Label.Text = raqamWasoolTafseel5;

            autoHide(RaqamWasoolValue1Label, RaqamWasoolValue1Label, Rupay1);
            autoHide(RaqamWasoolValue2Label, RaqamWasoolValue2Label, Rupay2);
            autoHide(RaqamWasoolValue3Label, RaqamWasoolValue3Label, Rupay3);
            autoHide(RaqamWasoolValue4Label, RaqamWasoolValue4Label, Rupay4);
            autoHide(RaqamWasoolValue5Label, RaqamWasoolValue5Label, Rupay5);

            BaqayaLabel.Text = baqaya;
            Receipt.Show();
        }

        public void printReceipt()
        {


            Graphics graphics = Receipt.CreateGraphics();

            Size size = Receipt.ClientSize;

            bitmap = new Bitmap(size.Width, size.Height, graphics);

            graphics = Graphics.FromImage(bitmap);

            Point point = Receipt.PointToScreen(Receipt.Location);

            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);


            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Invoice", 645, 945);

            using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
            {
                printPreviewDialog.Document = printDocument1;
                // Perform your printing and preview setup here
                // ...

                // Show the print preview dialog
                printPreviewDialog.ShowDialog();
            } // The printPreviewDialog will be automatically disposed of when exiting the using block
        }

        void autoHide(Bunifu.UI.WinForms.BunifuLabel label1, Bunifu.UI.WinForms.BunifuLabel label2, Bunifu.UI.WinForms.BunifuLabel label3)
        {
            if (label1.Text == "0" || label1.Text == string.Empty)
            {
                label1.Hide();
                label2.Hide();
                label3.Hide();
            }
        }

        private void CloseReceiptButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);

        }
        Bitmap bitmap;
        private void PrintReceipt_Click(object sender, EventArgs e)
        {
            printReceipt();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void SavePDF_Click(object sender, EventArgs e)
        {
            createPDF();
        }

        void createPDF()
        {
            // Create a SaveFileDialog to specify where to save the PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save PDF File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                iTextSharp.text.Rectangle pageSize = new iTextSharp.text.Rectangle(Receipt.Width, Receipt.Height);

                // Create a new Document
                iTextSharp.text.Document doc = new iTextSharp.text.Document(pageSize);



                try
                {
                    // Initialize a PdfWriter instance to write the document to the file
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

                    // Open the document for writing
                    doc.Open();

                    // Create a PdfContentByte object to add content to the PDF
                    PdfContentByte cb = writer.DirectContent;

                    // Create a PdfTemplate to draw the content of the Panel
                    PdfTemplate template = cb.CreateTemplate(Receipt.Width, Receipt.Height);

                    // Create a Bitmap to capture the Panel's content
                    Bitmap bmp = new Bitmap(Receipt.Width, Receipt.Height);

                    // Create a System.Drawing.Rectangle
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, Receipt.Width, Receipt.Height);

                    // Draw the Panel's content onto the Bitmap
                    Receipt.DrawToBitmap(bmp, rect);

                    // Convert the Bitmap to an iTextSharp image
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);

                    // Set the absolute position of the image on the PDF
                    img.SetAbsolutePosition(0, 0);

                    img.ScaleToFit(doc.PageSize);


                    // Add the image to the PdfTemplate
                    template.AddImage(img);

                    // Add the PdfTemplate to the PDF document
                    cb.AddTemplate(template, 0, 0);

                    // Close the document
                    doc.Close();

                    MessageBox.Show("PDF file created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                }
            }
        }
    }
}
