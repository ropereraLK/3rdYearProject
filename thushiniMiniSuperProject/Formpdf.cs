using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

using System.IO;

using System.Diagnostics;

namespace thushiniMiniSuperProject
{
    public partial class Formpdf : Form
    {
        public Formpdf()
        {
            InitializeComponent();
        }

      
       

        private void pdf()
        {
            try
            {
                string path = Application.StartupPath;
                // Document pdfdoc = new Document(PageSize.A4); // Setting the page size for the PDF
                var pgSize = new iTextSharp.text.Rectangle(300, 5000);
                var pdfdoc = new iTextSharp.text.Document(pgSize, 15, 15, 15, 15);

                PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/Sample.pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                pdfdoc.Open(); // Opening the PDF to write the data from the textbox
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("-                      Thushini Mini Super                      -"));
                pdfdoc.Add(new Paragraph("                              Negombo                            "));
                pdfdoc.Add(new Paragraph("                           0312221031                            "));
                pdfdoc.Add(new Paragraph("                                                          "));
                pdfdoc.Add(new Paragraph("Date: 2019-08-27                            Invoice:14          "));
                pdfdoc.Add(new Paragraph("Sales: roperera                         "));
               // pdfdoc.Add(new Paragraph("                                                          "));
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("ITEM        QTY          PRICE            AMOUNT"));
               // pdfdoc.Add(new Paragraph("                                                          "));
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("1   Gold Hair Cream 100 ML"));
                pdfdoc.Add(new Paragraph("      1000050  -   1    200.00             200.00"));
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("Sub Total                                               200.00"));
                pdfdoc.Add(new Paragraph("Discount                                                200.00"));
                pdfdoc.Add(new Paragraph("Loyalty                                                   200.00"));
                pdfdoc.Add(new Paragraph("                                                          "));
                pdfdoc.Add(new Paragraph("TOTAL                                                   200.00"));
                pdfdoc.Add(new Paragraph("Cash                                                      200.00"));
                pdfdoc.Add(new Paragraph("Balance                                                    0.00"));
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("-----------------   IMPORTANT NOTICE   ---------------"));
                pdfdoc.Add(new Paragraph("In case of a price discrepancy, return the bill within 7 days to refund the difference"));
                pdfdoc.Add(new Paragraph("                                            "));
                pdfdoc.Add(new Paragraph("         *** Thank you Come Again ***"));






                //pdfdoc.Add(new Paragraph("1234567891234567891234567891234567891234"));
                pdfdoc.Add(new Paragraph(xtxtData.Text)); // Adding the Text to the PDF
                pdfdoc.Close();
                //MessageBox.Show("PDF Generation Successfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGeneratePDFFile_Click_1(object sender, EventArgs e)
        {
            pdf();
        }
    }
}
