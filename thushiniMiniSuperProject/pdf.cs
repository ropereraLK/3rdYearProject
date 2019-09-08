using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Reflection;
namespace thushiniMiniSuperProject
{
    public partial class pdf : Form
    {
        public pdf()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            


            FileStream fs = new FileStream(@"G:\PDFs\First PDF document.pdf", FileMode.Create);
            Document document = new Document(PageSize.A7, 25, 25, 30, 30);
            
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddAuthor("Micke Blomquist");
            document.AddCreator("Sample application using iTextSharp");
            document.AddKeywords("PDF tutorial education");
            document.AddSubject("Document subject - Describing the steps creating a PDF document");
            document.AddTitle("The document title - PDF creation using iTextSharp");

            // Open the document to enable you to write to the document  
            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner  
            document.Add(new Paragraph(".    Thushini Mini Super     ."));

            PdfContentByte cb = writer.DirectContent;
            BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            /*
            cb.SetTextMatrix(100, 100); // Left, Top  
            


            

            int row = 1;
            for (int y = 0; y != 70; y++)
            {
                cb.SetTextMatrix(10, row);
                cb.ShowText("Y: " + row.ToString());
                row += 12; // The spacing between the rows is set to 12 "points"  
            }
            int col = 35;
            for (int x = 0; x != 22; x++)
            {
                cb.SetTextMatrix(col, 829);
                cb.ShowText("X: " + col.ToString());
                col += 25; // The spacing between the columns is set to 25 "points"  
            }


    */
            cb.BeginText();
            cb.SetFontAndSize(f_cb, 9);

            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, "This text is left aligned", 200, 800, 0);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "This text is right aligned", 200, 788, 0);

            cb.ShowText("Hello World");
            cb.EndText();
            // Close the document  
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            fs.Close();



        }
    }
}
