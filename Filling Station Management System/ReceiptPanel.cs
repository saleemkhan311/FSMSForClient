using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.codec;
using Microsoft.Office.Interop.Excel;
using System.Windows.Media;
using TheArtOfDev.HtmlRenderer.Adapters;
using System.Drawing.Printing;

namespace Filling_Station_Management_System
{
    public partial class ReceiptPanel : KryptonForm
    {
        public string ref_no { get; set; }
        public string malikName { get; set; }
        public string DateTimeValue { get; set; }
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

        private void ReceiptPanel_Load(object sender, EventArgs e)
        {
            Assignation();
        }

        private void Assignation()
        {

            RefLabel.Text = "Ref# :--------------- " + ref_no;
            DateLabel.Text = DateTimeValue;
            MalikNameLabel.Text = malikName;
            WazanLabel.Text = wazan;
            MiqdarLabel.Text = miqdar;
            KhorakiLabel.Text = khoraki;
            SafiMiqdarLabel.Text = safiMiqdar;
            RateFiLiterLabel.Text = rateFiLiter;
            KulRaqamLAbel.Text = kulRaqam;
            MazdooriLabel.Text = mazdoori;
            SafiRaqmLabel.Text = safiRaqam;
            SabqaRaqamLabel.Text = sabqaRaqam;
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

            // Create a PrintDocument for printing
            PrintDocument printDocument1 = new PrintDocument();

            // Define the A5 page size
            PaperSize A5PageSize = new PaperSize("A5", 827, 1169); // 419x595 pixels for 300 DPI

            // Set the paper size for the A5 receipt
            printDocument1.DefaultPageSettings.PaperSize = A5PageSize;

            // Set the print page event handler
            printDocument1.PrintPage += (s, e) =>
            {
                // Calculate the scaling factor to fit the receipt on the A5 page without distortion
                float scaleX = (float)A5PageSize.Width / Receipt.Width * 5f; // Increase the scale factor as needed
                float scaleY = (float)A5PageSize.Height / Receipt.Height * 5f; // Increase the scale factor as needed
                float scale = Math.Min(scaleX, scaleY);

                // Calculate the centered position for the receipt on the A5 page
                int left = (A5PageSize.Width - (int)(Receipt.Width * scaleX)) / 500;
                int top = (A5PageSize.Height - (int)(Receipt.Height * scaleY)) / 500;

                // Create a bitmap to render the receipt content at the A5 size
                using (Bitmap bitmap = new Bitmap(A5PageSize.Width, A5PageSize.Height))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        // Set the higher resolution (300 DPI)
                        graphics.PageUnit = GraphicsUnit.Pixel;
                        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                        // Scale the receipt to fit the A5 page without distortion
                        graphics.ScaleTransform(scale, scale);

                        // Draw the receipt content onto the bitmap
                        Receipt.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, Receipt.Width, Receipt.Height));
                    }

                    // Set the print page resolution (300 DPI)
                    e.Graphics.PageUnit = GraphicsUnit.Pixel;

                    // Draw the receipt content onto the page at the A5 size
                    e.Graphics.DrawImage(bitmap, new System.Drawing.Rectangle(left, top, (int)(Receipt.Width * scaleX), (int)(Receipt.Height * scaleY)));
                }
            };

            // Specify the page orientation (portrait or landscape)
            printDocument1.DefaultPageSettings.Landscape = false; // Set to true for landscape orientation

            using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
            {
                printPreviewDialog.Document = printDocument1;

                // Perform your printing and preview setup here
                // ...

                // Show the print preview dialog
                printPreviewDialog.ShowDialog();
            }
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
            /* printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 148, 210);
             Graphics g = e.Graphics;
             System.Drawing.Rectangle rect = e.MarginBounds;


             // Print customer information
             *//*g.DrawString(TitleLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 35), System.Drawing.Brushes.Red, new System.Drawing.Point(TitleLabel.Location.X, -10));

             g.DrawString(PropLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 25), System.Drawing.Brushes.Black, new System.Drawing.Point(10, 100));
             g.DrawString(ManLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 25), System.Drawing.Brushes.Black, new System.Drawing.Point(ManLabel.Location.X, 100));


             g.DrawString(NameLabel.Text, new System.Drawing.Font("Noto Nastaliq Urdu", 10), System.Drawing.Brushes.Black, new System.Drawing.Point(NameLabel.Location.X, 200));
             g.DrawString(MalikNameLabel.Text, new System.Drawing.Font("Noto Nastaliq Urdu", 10), System.Drawing.Brushes.Black, new System.Drawing.Point(MalikNameLabel.Location.X, 200));*//*
             //--

             g.DrawString(TitleLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 35), System.Drawing.Brushes.Red, new System.Drawing.Point(TitleLabel.Location.X, TitleLabel.Location.X));

             g.DrawString(PropLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 20), System.Drawing.Brushes.Black, new System.Drawing.Point(PropLabel.Location.X, PropLabel.Location.Y));
             g.DrawString(ManLabel.Text, new System.Drawing.Font("Nafees Naskh v2.01", 20), System.Drawing.Brushes.Black, new System.Drawing.Point(ManLabel.Location.X, ManLabel.Location.Y));


             g.DrawString(NameLabel.Text, new System.Drawing.Font("Noto Nastaliq Urdu", 10), System.Drawing.Brushes.Black, new System.Drawing.Point(NameLabel.Location.X, NameLabel.Location.Y));
             g.DrawString(MalikNameLabel.Text, new System.Drawing.Font("Noto Nastaliq Urdu", 10), System.Drawing.Brushes.Black, new System.Drawing.Point(MalikNameLabel.Location.X, MalikNameLabel.Location.Y));


             e.HasMorePages = false;
 */

            // e.Graphics.DrawImage(bitmap, 0, 0);

        }

        Bitmap bitmap;
        private void PrintReceipt_Click(object sender, EventArgs e)
        {
            printReceipt();

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        void TempPrint()
        {

        }

        private void SavePDF_Click(object sender, EventArgs e)
        {
            createPDF();
        }

        public void createPDF()
        {
            // Create a SaveFileDialog to specify where to save the PDF
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.FileName = $"Ref# {ref_no}";
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

        private void ReceiptPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PrintScreen)
            {
                // Call your function here
                printReceipt();
            }
        }

        private void PropLabel_Click(object sender, EventArgs e)
        {

        }

        private void TitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
