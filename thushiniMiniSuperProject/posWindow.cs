using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Media;
using System.Globalization;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Diagnostics;



namespace thushiniMiniSuperProject
{
    public partial class posWindow : Form
    {
        private void pdf()
        {
            try
            {
                string path = Application.StartupPath;
                // Document pdfdoc = new Document(PageSize.A4); // Setting the page size for the PDF
                var pgSize = new iTextSharp.text.Rectangle(300, 5000);
                var pdfdoc = new iTextSharp.text.Document(pgSize, 15, 15, 15, 15);

                PdfWriter.GetInstance(pdfdoc, new FileStream(path + "/pos.pdf", FileMode.Create)); //Using the PDF Writer class to generate the PDF
                pdfdoc.Open(); // Opening the PDF to write the data from the textbox
                pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("-                      Thushini Mini Super                      -"));
                pdfdoc.Add(new Paragraph("                              Negombo                            "));
                pdfdoc.Add(new Paragraph("                           0312221031                            "));
                pdfdoc.Add(new Paragraph("                                                          "));
                 pdfdoc.Add(new Paragraph("Date: "+DateTime.Today.ToString("yyyy-MM-dd")+ "                            Invoice: "+txtInvoice.Text.ToString() + "          "));
                 pdfdoc.Add(new Paragraph("Sales: "+lblUsername.Text.ToString()+"                         "));
                 // pdfdoc.Add(new Paragraph("                                                          "));
                 pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                 pdfdoc.Add(new Paragraph("ITEM        QTY          PRICE            AMOUNT"));
                 // pdfdoc.Add(new Paragraph("                                                          "));
                 pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    pdfdoc.Add(new Paragraph(""+(i+1)+"   "+dataGridView1.Rows[i].Cells[1].Value+""));
                    pdfdoc.Add(new Paragraph("      " + dataGridView1.Rows[i].Cells[0].Value + "       " + dataGridView1.Rows[i].Cells[2].Value + "      {" + dataGridView1.Rows[i].Cells[3].Value + "}       " + dataGridView1.Rows[i].Cells[4].Value + "  * " + dataGridView1.Rows[i].Cells[5].Value + ""));
                }
                 pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                 pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                 pdfdoc.Add(new Paragraph("Sub Total                                               "+txtSubTotal.Text.ToString() + ""));
                 pdfdoc.Add(new Paragraph("Discount                                                "+txtDiscount.Text.ToString() + ""));
                 pdfdoc.Add(new Paragraph("Loyalty Redemed                                     "+txtRedem.Text.ToString() + ""));
                 pdfdoc.Add(new Paragraph("                                                          "));
                 pdfdoc.Add(new Paragraph("TOTAL                                                 "+txtTotal.Text.ToString() + ""));
                 pdfdoc.Add(new Paragraph("Cash                                                      "+txtCash.Text.ToString() + ".00"));
                 pdfdoc.Add(new Paragraph("Balance                                                    "+txtBalance.Text.ToString() + ".00"));
                 pdfdoc.Add(new Paragraph("-------------------------------------------------------------------"));
                pdfdoc.Add(new Paragraph("*   Earned Loyalty   *"));
                 pdfdoc.Add(new Paragraph("   "+txtLoyalty.Text+""));
                 pdfdoc.Add(new Paragraph(""));

                 pdfdoc.Add(new Paragraph("-----------------   IMPORTANT NOTICE   ---------------"));
                 pdfdoc.Add(new Paragraph("In case of a price discrepancy, return the bill within 7 days to refund the difference"));
                 pdfdoc.Add(new Paragraph("                                            "));
                 pdfdoc.Add(new Paragraph("         *** Thank you Come Again ***"));
                 
                pdfdoc.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int publicVariable = 0;

        string empUsername = null;
        string empRole = null;
        string empId = null;

        public char textBoxName;


        bool startBilling = false;

        public posWindow(string username, string role, string id)
        {
            empId = id;
            empUsername = username;
            empRole = role;

            InitializeComponent();
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[0].Width = 90;
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[1].Width = 340;
            dataGridView1.Columns[2].Name = "Price (Rs)";
            dataGridView1.Columns[2].Width = 135;
            dataGridView1.Columns[3].Name = "Discount(Rs)";
            dataGridView1.Columns[3].Width = 130;
            dataGridView1.Columns[4].Name = "Qty";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Name = "Amount(Rs)";
            dataGridView1.Columns[5].Width = 154;


            txtTotal.Text = "0.00";

            lblUsername.Text = username;
            lblRole.Text = role;
        }

        //Variable 
        private void alternateAddProducts()
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection con = new MySqlConnection(connString);
            try
            {
                con.Open();


                using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT `proId`, `proName` FROM `producttable` WHERE `proStatus` = 1", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Insert the Default Item to DataTable.
                    DataRow dataRow = dt.NewRow();
                    dt.Rows.InsertAt(dataRow, 0);
                    dataRow.ItemArray = new object[] { 0, "--Select--" };
                    cmbSearch.DataSource = dt;

                    //Assign DataTable as DataSource.
                    cmbSearch.DataSource = dt;
                    cmbSearch.DisplayMember = "proName";
                    cmbSearch.ValueMember = "proId";

                    //Set AutoCompleteMode.
                    cmbSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                    cmbSearch.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
            catch
            {
                MessageBox.Show("alternate");
            }
            finally
            {
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //alternate add products
            alternateAddProducts();

            //For Keypad
            btnBackspace.Visible = false;
            lblTime.Text = DateTime.Now.ToShortTimeString();
            textBoxName = 'A';
            txtScan.Focus();
            txtTransactionDate.Text = DateTime.Today.ToShortDateString();
            lblDate.Text = DateTime.Today.ToShortDateString();
            //Assigning date and invoiceNo
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                string Query = "SELECT `salesId` FROM `salestable`  ORDER by `salesId` DESC LIMIT 1;";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    lastInvoice = Convert.ToInt32(rdr[0]);
                }
                rdr.Close();
            }
            catch
            {
                MessageBox.Show("Exception Occured");
            }
            finally
            {
                txtInvoice.Text = (lastInvoice + 1).ToString();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            BtnClick('9');
        }


        private void txtCash_TextChanged(object sender, EventArgs e)
        {
           
            try
            {
                float balaceVar = (float.Parse(txtCash.Text) - float.Parse(txtTotal.Text));
                if (balaceVar >= 0)
                {
                    txtBalance.ForeColor = Color.Green;
                }
                else
                {
                    txtBalance.ForeColor = Color.Red;
                }
                txtBalance.Text = balaceVar.ToString();

            }
            catch
            {
                txtCash.Clear();
            }
        }

        //  private string scannedItemBuffer = null;
        int lastInvoice = 0; //To calculate Invoice No
        bool transactionStatus = false; // Transaction status is false at the beginning and becomes true at the inception of process and becomes false at the end

        //POS
        private string proId = "";
        private string proName;
        private float proMaxPrice;
        private float proDisPrice;
        private float proStock;
        //
        //
        private string proIdBuffer = "";
        private string proNameBuffer;
        private float proMaxPriceBuffer;
        private float proDisPriceBuffer;
        private float proStockBuffer;

        //
        private float subTotal = 0;
        private float discount = 0;
        private float loyalty = 0;
        private float redeem = 0; //redeemed points from card



        private float total;
        private string billNo = null;
        //

        float itemQty = 1; //variable to pick txtQty

        private void afterBillPrinted()
        {
            //POS
            proId = "";
            proName = "";
            proMaxPrice = 0;
            proDisPrice = 0;
            proStock = 0;
            //
            //
            proIdBuffer = "";
            proNameBuffer = "";
            proMaxPriceBuffer = 0; ;
            proDisPriceBuffer = 0; ;
            proStockBuffer = 0; ;

            //
            subTotal = 0;
            discount = 0;
            redeem = 0;
            loyalty = 0;
            billNo = "";
            //

            itemQty = 1; //variable to pick txtQty


            lastInvoice++;

            //resetTexts;
            txtSubTotal.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtLoyalty.Text = "0.00";
            txtTotal.Text = "0.00";
            txtCash.Text = "";
            txtBalance.Text = "0.00";
            txtInvoice.Text = (lastInvoice + 1).ToString();

            //Enable if disabled;
            txtScan.Enabled = true;
            txtQty.Enabled = true;
            txtScan.Clear();
            txtQty.Text = "1";
            txtScan.Focus();

            

        }

        private void scanForItem()
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string Query = "SELECT `proId`,  `proMaxPrice`, `proDiscountPrice`, `proStock`,  `proName` FROM `producttable` WHERE `proStatus`= 1 AND `proBarCode` = '" + txtScan.Text + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    proId = rdr[0].ToString();
                    proName = rdr[4].ToString();
                    proStock = Convert.ToSingle(rdr[3]);
                    proDisPrice = Convert.ToSingle(rdr[2]);
                    proMaxPrice = Convert.ToSingle(rdr[1]);
                }
                rdr.Close();


                if (proIdBuffer == "")
                {
                    proIdBuffer = proId;
                    proNameBuffer = proName;
                    proStockBuffer = proStock;
                    proDisPriceBuffer = proDisPrice;
                    proMaxPriceBuffer = proMaxPrice;

                }
                else
                {
                    sendToDataGrid(proIdBuffer, proNameBuffer, proStockBuffer, proMaxPriceBuffer, proDisPriceBuffer);
                    //
                    proIdBuffer = proId;
                    proNameBuffer = proName;
                    proStockBuffer = proStock;
                    proDisPriceBuffer = proDisPrice;
                    proMaxPriceBuffer = proMaxPrice;

                }

                txtSearch.Text = proNameBuffer;
                if (proNameBuffer != "")
                {
                    using (SoundPlayer player = new SoundPlayer("C:/SystemDevelopmentProject_INTE_34212/beep-3.wav"))
                    {
                        // Use PlaySync to load and then play the sound.
                        // ... The program will pause until the sound is complete.
                        player.PlaySync();
                    }
                }
                txtShowPrice.Text = proMaxPriceBuffer.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);
                txtShowTotal.Text = (proDisPriceBuffer * itemQty).ToString("##,##,##,###.00", CultureInfo.InvariantCulture);


                //Clear Scan Box
                txtScan.Clear();
                txtScan.Focus();

            }
            catch
            {
                MessageBox.Show("Error occured. Please try again from the current item ! ");

            }

            finally
            {
                conn.Close();

            }
        }

        public void sendToDataGrid(string id, string name, float stock, float maxPrice, float discPrice)
        {
            if ((stock - itemQty) >= 0)
            {
                dbString dbc = new dbString();
                string conString = dbc.connectionSring;
                MySqlConnection con = new MySqlConnection(conString);
                try
                {
                    con.Open();

                    MySqlCommand comm = con.CreateCommand();
                    comm.CommandText = "UPDATE `producttable` SET `proStock`=" + (proStock - itemQty) + " WHERE `proId`='" + proIdBuffer.ToString() + "'";
                    comm.ExecuteNonQuery();



                }
                catch
                {
                    MessageBox.Show("Product with that Barcode is not available");
                }
                finally
                {
                    con.Close();
                    //

                }

                try
                {
                    con.Open();

                    MySqlCommand comm = con.CreateCommand();
                    comm.CommandText = "INSERT INTO `sales_producttable` (`salesId`, `salesDate`, `productId`, `productQty`) VALUES ('" + (lastInvoice + 1) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '" + id + "','" + itemQty + "');";
                    comm.ExecuteNonQuery();

                    string[] row = new string[] { id, name, maxPrice.ToString("##,##,##,###.00", CultureInfo.InvariantCulture), (maxPrice - discPrice).ToString("##,##,##,###.00", CultureInfo.InvariantCulture), txtQty.Text, (Convert.ToSingle(txtQty.Text) * discPrice).ToString("##,##,##,###.00", CultureInfo.InvariantCulture) };
                    dataGridView1.Rows.Add(row);

                    subTotal = subTotal + Convert.ToSingle(txtQty.Text) * maxPrice;
                    txtSubTotal.Text = subTotal.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);

                    discount = discount + Convert.ToSingle(txtQty.Text) * (maxPrice - discPrice);
                    txtDiscount.Text = discount.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);

                    total = (int)Math.Floor(subTotal - (loyalty + discount));

                    txtTotal.Text = total.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);

                }
                catch
                {

                }
                finally
                {
                    con.Close();
                    itemQty = 1;
                }
            }
            else
            {
                // Facilitate Negative stock
                MessageBox.Show("Stock runs out.....");
            }

            /*  proId = "";
              proMaxPrice = 0;
              proName = "";
              proDisPrice = 0;
  */
        }

        private void txtQty_Click(object sender, EventArgs e)
        {
            txtQty.Text = null;
            textBoxName = 'B'; //Qty = B
                               // textBoxName = 'A'; //Scan = A
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BtnClick('8');
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var createUser = new cusAdd();
            createUser.Show();
        }

        private void btnUpdateCustomer_Click_1(object sender, EventArgs e)
        {
            var createUser = new cusUpdate();
            createUser.Show();
        }


        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            // var giftVoucher2 = new GiftVoucherPay();
            //  giftVoucher2.Show();
        }


        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }



        private void button11_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var invWin = new LoginWindow();

            invWin.Closed += (s, args) => this.Close();
            invWin.Show();
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            try
            {
                int vari = Convert.ToInt32(empId);

                var x = new empView(vari);
                x.ShowDialog();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }



        private void StBilling()
        {
            if (startBilling == false)
            {
                startBilling = true;
            }
        }

        private void ConclBilling()
        {
            startBilling = false;
        }

        DateTime date = DateTime.Now.Date;
        DateTime exp;
        private void txtScan_TextChanged(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToShortTimeString(); //Update Time


            Regex validator = new Regex("^[0-9]{13}$");
            Regex validator1 = new Regex("^['V'][0-9]{11}$");
            Regex validator2 = new Regex("^['C'][0-9]{5}$");
            if (validator.Match(txtScan.Text).Success)
            {
                txtQty.Text = "1";
                scanForItem();

            }

            else if (validator1.Match(txtScan.Text).Success) // for Gift Vouchers
            {
                btnAddItem.PerformClick();
                txtQty.Text = "1";
                giftVoucherProcess();

            }
            else if (validator2.Match(txtScan.Text).Success)
            {
                //Block Further Items adding to Cart
                btnAddItem.PerformClick();

                //Validity of card
                dbString db = new dbString();
                string connString = db.connectionSring;
                MySqlConnection conn = new MySqlConnection(connString);
                string query = "SELECT `cusFirstName`, `cusLastName`, `cusLoyaltyPoints` FROM `customertable` WHERE `cusId` = '" + txtScan.Text + "'";

                string cusFname = "";
                string cusLname = "";
                float cusPastLoyalPoints = 0;
                conn.Open();
                try
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = mySqlCommand.ExecuteReader();

                    while (rdr.Read())
                    {
                        cusFname = rdr[0].ToString();
                        cusLname = rdr[1].ToString();
                        cusPastLoyalPoints = Convert.ToSingle(rdr[2]);

                    }
                    rdr.Close();

                }
                catch
                {
                    //MessageBox.Show("Error Connecting with the database. Try again Shortly.");
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                if (cusFname != "")
                {
                    giftVTransition1 state = new giftVTransition1(string.Empty, 0);

                    customerScan customerScan = new customerScan(cusFname, cusLname, cusPastLoyalPoints, txtInvoice.Text, txtTransactionDate.Text, txtScan.Text, total, state);
                    customerScan.ShowDialog();

                    //txtRedem.Text = loyalty.ToString();
                    try
                    {
                        redeem = Convert.ToSingle(state.Text);
                        txtRedem.Text = redeem.ToString();
                    }
                    catch
                    {

                    }

                    //Prevent further items adding

                    //ClearVariables;
                }
                else
                {
                    MessageBox.Show("Invalied Card");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        public void button12_Click(object sender, EventArgs e)
        {
            if (proIdBuffer != "")
            {
                sendToDataGrid(proIdBuffer, proNameBuffer, proStockBuffer, proMaxPriceBuffer, proDisPriceBuffer);
                //
                proIdBuffer = "";
                proNameBuffer = "";
                proStockBuffer = 0;
                proDisPrice = 0;
                proMaxPriceBuffer = 0;

                //
                txtQty.Text = "1"; itemQty = 1;
                txtScan.Clear();
                txtSearch.Clear();
                txtShowPrice.Clear();
                txtShowTotal.Clear();
                txtScan.Focus();
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            if (itemQty <= 0)
            {
                MessageBox.Show("Are you sure you want to remove the product", "Warning", MessageBoxButtons.YesNo);



            }
            else
            {
                btnAddItem.PerformClick();
            }

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                itemQty = Convert.ToSingle(txtQty.Text);

            }
            catch
            {

            }
            try
            {
                txtShowTotal.Text = (proDisPrice * itemQty).ToString();
            }
            catch { }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            btnAddItem.PerformClick();
            if (btnMode.Text == "CASH")
            {
                btnMode.BackColor = Color.Yellow;
                btnMode.Text = "CARD";
                txtCash.Text = txtTotal.Text;
                txtCash.Enabled = false;//
                txtCardNo.ReadOnly = false;//
                txtCardNo.Enabled = true;

            }
            else
            {
                btnMode.BackColor = Color.White;
                btnMode.Text = "CASH";
                txtCardNo.Text = "";
                txtCardNo.ReadOnly = true;
                txtCash.Enabled = true;
                txtCash.Text = "";

            }
        }

        private void cash_Card_Change()
        {
            btnMode.Enabled = true;
            txtCash.Enabled = true;
            txtCardNo.Enabled = false;
            if (btnMode.Text == "CARD")
            {
                btnMode.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                txtLoyalty.Text = (Convert.ToSingle(txtTotal.Text) / 100).ToString();
            }
            catch {
            }
            float balx = -1;
            try
            {
                balx = Convert.ToSingle(txtBalance.Text);
            }
            catch
            {

            }
            bool cardMode = true;
            if (btnMode.Text == "CARD" && txtCardNo.Text == "")
            {
                cardMode = false;
            }
            else
            {
                cardMode = true;

            }
            if ((subTotal >= 1) && (balx > (-1)) && cardMode)
            {
                btnPrint.Enabled = false;
                btnAddItem.PerformClick();
                pdf();
                dataGridView1.Rows.Clear();

                dbString dbc = new dbString();
                string conString = dbc.connectionSring;
                MySqlConnection con = new MySqlConnection(conString);
                try
                {
                    con.Open();

                    MySqlCommand comm = con.CreateCommand();
                    string que = "";
                    string cus = "";
                    if (cus == "")
                    {
                        que = "INSERT INTO `salestable` (`salesId`, `salesDate`, `salesTime`, `salesSubTotal`, `salesDiscount`, `salesTotal`, `salesEmpUsername`, `salesCusId`, `salesLoyaltyRedeem`, `salesLoyaltyEarn`) VALUES ('" + (lastInvoice + 1) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', CURRENT_TIME(), '" + subTotal + "', '" + discount + "', '" + (subTotal - discount) + "', '" + empUsername + "', '0', '10', '" + (subTotal / 100) + "');";
                    }
                    else
                    {
                        que = "INSERT INTO `salestable` (`salesId`, `salesDate`, `salesTime`, `salesSubTotal`, `salesDiscount`, `salesTotal`, `salesEmpUsername`, `salesCusId`, `salesLoyaltyRedeem`, `salesLoyaltyEarn`) VALUES ('" + (lastInvoice + 1) + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', CURRENT_TIME(), '" + subTotal + "', '" + discount + "', '" + (subTotal - discount) + "', '" + empUsername + "', '0', '0', '0');";

                    }
                    comm.CommandText = que;
                    comm.ExecuteNonQuery();



                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    con.Close();
                    
                }

                afterBillPrinted();


                btnPrint.Enabled = true;
                txtScan.Enabled = true; txtQty.Enabled = true; txtSearch.Enabled = true;
            }

            cash_Card_Change();
            //// print Exchange Bill

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSummery_Click(object sender, EventArgs e)
        {
            posMySummery mySummery = new posMySummery(empUsername);
            mySummery.ShowDialog();
        }

        private void txtBalance_Click(object sender, EventArgs e)
        {

        }

        private void giftVoucherIssue()
        {
            string myValue = "1124567891231";
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            try { }
            catch { }

        }

        private void txtScan_Enter(object sender, EventArgs e)
        {
            textBoxName = 'A'; //Scan = A
        }

        private void txtQty_Enter(object sender, EventArgs e)
        {
            textBoxName = 'B'; //Qty = B
        }

        private void txtCash_Enter(object sender, EventArgs e)
        {
            textBoxName = 'C'; //Cash = C
            btnAddItem.PerformClick();
        }

        public void BtnClick(char btnValue1)
        {

            char btnValue = btnValue1;
            if (textBoxName == 'A') //Scan
            {
                txtScan.Text += btnValue;
                txtScan.Focus();
            }
            if (textBoxName == 'B') //Qty
            {
                txtQty.Text += btnValue;
                txtQty.Focus();
            }
            if (textBoxName == 'C') //Qty
            {
                txtCash.Text += btnValue;
                txtCash.Focus();
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            textBoxName = 'D';
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            BtnClick('.');
        }
        private void button0_Click(object sender, EventArgs e)
        {
            BtnClick('0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BtnClick('1');

        }
        private void button2_Click(object sender, EventArgs e)
        {
            BtnClick('2');
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BtnClick('3');
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BtnClick('4');
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BtnClick('5');
        }
        private void button6_Click(object sender, EventArgs e)
        {
            BtnClick('6');
        }
        private void button7_Click(object sender, EventArgs e)
        {
            BtnClick('7');
        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            BtnClick('8');
        }
        private void button9_Click_1(object sender, EventArgs e)
        {
            BtnClick('9');
        }

        private void txtLoyalty_TextChanged(object sender, EventArgs e)
        {

        }

        bool exchange = false;

        private void btnExchangeBill_Click(object sender, EventArgs e)
        {
            if (exchange == false)
            {
                //btnExchangeBill.BackColor = Color.Yellow;
                exchange = true;
                //btnExchangeBill.Enabled = false;
            }
        }

        private void giftVoucherProcess()
        {
            //Local Variables
            string voucherBarcodeNo = txtScan.Text;
            float vValue = 0;
            int vStatus = 0;
            bool notExpired = false;
            string expiaryDate = "";
            //
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {
                conn.Open();
                string Query = "SELECT  `vExpDate`,  `status`, `value` FROM `giftvouchertable` WHERE `vBarcode` = '" + voucherBarcodeNo + "'";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    expiaryDate = rdr[0].ToString();
                    vStatus = Convert.ToInt32(rdr[1]);
                    vValue = Convert.ToSingle(rdr[2]);
                }
                rdr.Close();



                try
                {
                    exp = Convert.ToDateTime(expiaryDate);
                }
                catch
                {
                    notExpired = false;
                    // MessageBox.Show("Error in Date conversion");

                }
                if (date > exp)//expied
                {
                    notExpired = false;
                    expiaryDate = "";
                }
                else if (date <= exp)//Not Expired
                {
                    // textBox1.Text = "Not Exp";
                    notExpired = true;
                    expiaryDate = "";
                }

            }
            catch
            {
                MessageBox.Show("Exception Occured in connecting to Database");

            }
            finally
            {
                conn.Close();
            }

            //////////////////////////////////////////////////
            /////


            if (vStatus == 1 && notExpired == true && (total >= vValue)) //Voucher Issued and not presented for redemption
            {
                if (proIdBuffer == "")
                {
                    txtScan.Enabled = false; txtQty.Enabled = false; txtSearch.Enabled = false;

                    giftVTransition1 state = new giftVTransition1(string.Empty, 0);
                    var GV = new GiftVoucherPay(voucherBarcodeNo, state);
                    GV.ShowDialog();
                    //textBox1.Text = state.Text;
                    //textBox1.SelectionStart = state.CaretPosition;
                    loyalty = loyalty + Convert.ToSingle(state.Text);
                    txtLoyalty.Text = loyalty.ToString();
                    total = subTotal - loyalty - discount;
                    txtTotal.Text = total.ToString();




                }
                else
                {
                    txtScan.Clear();
                    MessageBox.Show("Complete the existing transaction and try again");
                    txtCash.Focus();

                }

                notExpired = false;

            }
            else if (vStatus == 2) //Voucher is redemmed
            {
                MessageBox.Show("This voucher already presented for redemption.");
            }

            else if (total < vValue) // if voucher cannot be fully utilized
            {
                MessageBox.Show("Total sum of amount should be greater than gift voucher value");
            }
            else if (vStatus == 0)//New voucher
            {



                Regex validator500 = new Regex("^['V'][0-9]{10}[1]$");

                if (validator500.Match(voucherBarcodeNo).Success)
                {//
                 // voucherBarcodeNo.Text = "500.00";
                    var state = new giftVTransition1(string.Empty, 0);
                    GiftVoucher gv = new GiftVoucher(voucherBarcodeNo, state);
                    gv.ShowDialog();
                    txtScan.Text = "1111111110500";
                    txtScan.Enabled = false;
                    txtQty.Enabled = false;
                    btnAddItem.PerformClick();

                }
                Regex validator1000 = new Regex("^['V'][0-9]{10}[2]$");

                if (validator1000.Match(voucherBarcodeNo).Success)
                {//
                 //txtValue.Text = "1000.00";
                    var state = new giftVTransition1(string.Empty, 0);
                    GiftVoucher gv = new GiftVoucher(voucherBarcodeNo, state);
                    gv.ShowDialog();
                    txtScan.Text = "1111111111000";
                    txtScan.Enabled = false;
                    txtQty.Enabled = false;
                    btnAddItem.PerformClick();

                }

                Regex validator2000 = new Regex("^['V'][0-9]{10}[3]$");

                if (validator2000.Match(voucherBarcodeNo).Success)
                {//
                 //txtValue.Text = "2000.00";
                    var state = new giftVTransition1(string.Empty, 0);
                    GiftVoucher gv = new GiftVoucher(voucherBarcodeNo, state);
                    gv.ShowDialog();
                    txtScan.Text = "1111111112000";
                    txtScan.Enabled = false;
                    txtQty.Enabled = false;
                    btnAddItem.PerformClick();
                }

                Regex validator5000 = new Regex("^['V'][0-9]{10}[4]$");
                if (validator5000.Match(voucherBarcodeNo).Success)
                {//
                 // txtValue.Text = "5000.00";
                    var state = new giftVTransition1(string.Empty, 0);
                    GiftVoucher gv = new GiftVoucher(voucherBarcodeNo, state);
                    gv.ShowDialog();
                    txtScan.Text = "1111111115000";
                    txtScan.Enabled = false;
                    txtQty.Enabled = false;
                    btnAddItem.PerformClick();
                }



            }
            else if (notExpired == false)// if Voucher is Expired
            {
                MessageBox.Show("This voucher is Expired");
            }

            //  Reset Local Variables
            voucherBarcodeNo = "";
            vValue = 0;
            vStatus = 0;
            notExpired = false;
            expiaryDate = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToSingle(txtBalance.Text) >= 0)
            {
                txtBalance.ForeColor = Color.Green;
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {

        }

        private void txtRedem_TextChanged(object sender, EventArgs e)
        {
            total = total - redeem;
            txtTotal.Text = total.ToString();

            redeem = 0;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            string alternateBarcode = "";
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            
            try
            {
                conn.Open();
                string Query = "SELECT  `proBarCode` FROM `producttable` WHERE `proName` = '" + cmbSearch.Text + "' LIMIT 1";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    alternateBarcode = rdr[0].ToString();
                }
                rdr.Close();

            }
            catch
            {

            }
            finally
            {

                conn.Close();
            }

            if(alternateBarcode != "")
            {
                txtScan.Text = alternateBarcode;
            }
            alternateBarcode = "";
        }

        private void createPDF()
        {
           
               
        }
    }
    
}
