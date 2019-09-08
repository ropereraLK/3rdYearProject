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

namespace thushiniMiniSuperProject.ReceiveProducts
{
    public partial class RecievedProducts : Form
    {
        public RecievedProducts()
        {
            InitializeComponent();
        }

        private void RecievedProducts_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[1].Width = 300;
           // dataGridView1.Columns[2].Name = "Max Price";
            dataGridView1.Columns[2].Name = "Min Price";
            dataGridView1.Columns[3].Name = "Ord. Qty";
            dataGridView1.Columns[4].Name = "Recieved Qty";
           // dataGridView1.Columns[6].Name = "Order Value";
            dataGridView1.Columns[5].Name = "Total";

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = false;
            dataGridView1.Columns[5].ReadOnly = true;

            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button2.Hide();
            txtPO.Enabled = false;
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string rtn = @"SELECT ppq.`product_id`, pro.proName, pro.proMinPrice, ppq.`product_qty`,sup.SupName, po.datePlaced, 
po.dateExpected FROM `purchaseorder_product_quantitytable` ppq join `purchaseordertable` po ON ppq.`purchaseorderId`=po.po_id JOIN 
producttable pro ON pro.proId=ppq.`product_id` JOIN suppliertable sup ON pro.proSupplierId=sup.supId WHERE ppq.`purchaseorderId`='"+ txtPO.Text+ "' And po.`status`='0'";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    txtSupName.Text=(rdr[4]).ToString();
                    txtPlaced.Text = (rdr[5]).ToString();
                    txtExpected.Text= (rdr[6]).ToString();

                    string[] row = new string[] { (rdr[0]).ToString(), (rdr[1]).ToString(), (rdr[2]).ToString(), rdr[3].ToString( ), (rdr[3]).ToString( ) };
                    dataGridView1.Rows.Add(row);
                  }


                cellvalueChanged();
                CalculateOtherData();
            }
            catch (Exception exb)
            {
                MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();
               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateOtherData() //always use try catch
        {
            float units = 0;
            int products = 0;
            float expectedIncome = 0;
            float ordervalue = 0;


            int counter;
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
               
                //products
                if (Convert.ToSingle(dataGridView1.Rows[counter].Cells[4].Value) != 0)
                {
                    products++;
                }

                //units
                units += Convert.ToSingle(dataGridView1.Rows[counter].Cells[4].Value);

                //Order Value
                try
                {
                    ordervalue += Convert.ToSingle(dataGridView1.Rows[counter].Cells[5].Value);
                }
                catch
                {

                }

                //Expected Income
                try
                {
                    expectedIncome += (Convert.ToSingle(dataGridView1.Rows[counter].Cells[4].Value) * Convert.ToSingle(dataGridView1.Rows[counter].Cells[5].Value));
                }
                catch
                {

                }




            }

            txtUnits.Text = units.ToString();
            txtProducts.Text = products.ToString();
            txtOrdervalue.Text = ordervalue.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);
           // txtpaid.Text = expectedIncome.ToString();
           // txtbalance.Text = (-expectedIncome + ordervalue).ToString();



        }

        private void cellvalueChanged()
        {
            int counter;

            // Iterate through the rows, skipping the Starting Balance row.
            for (counter = 0; counter < (dataGridView1.Rows.Count - 1);
                counter++)
            {
                try
                {
                    if ((Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value)) < 0.0)
                    {
                        dataGridView1.Rows[counter].Cells[4].Value = "0";
                        dataGridView1.Rows[counter].Cells[5].Value = "0.00";
                    }
                }
                catch
                {

                }

                try
                {
                    //Placed Order Value
                    dataGridView1.Rows[counter].Cells[5].Value = (Convert.ToSingle(dataGridView1.Rows[counter].Cells[4].Value) * Convert.ToSingle(dataGridView1.Rows[counter].Cells[2].Value)).ToString("##,##,##,###.00", CultureInfo.InvariantCulture);
                }
                catch
                {
                    dataGridView1.Rows[counter].Cells[4].Value = "0";
                    dataGridView1.Rows[counter].Cells[5].Value = "0.00";


                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            cellvalueChanged();
            CalculateOtherData();
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);

            if (txtInvoice.Text != "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {

                        string rtn2 = @"UPDATE `producttable` SET `proStock`= (`proStock`+ '" + Convert.ToSingle(dataGridView1.Rows[i].Cells[4].Value) + "' ) WHERE `proId` = '"+ dataGridView1.Rows[i].Cells[0].Value + "'";

                        conn.Open();
                        MySqlCommand comm = conn.CreateCommand();
                        comm.CommandText = rtn2;

                        comm.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show("Some Exception has Occured Please try again.");

                    }
                    finally
                    {
                        conn.Close();

                    }
                }


                try
                {
                    string rtn = @"INSERT INTO `recievedtable`( `poId`, `invoiceNo`, `recievedDate`, `total`) VALUES ('" + txtPO.Text + "', '" + txtInvoice.Text + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "', '" + txtOrdervalue.Text + "')";

                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = rtn;
                   
                    comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Some Exception has Occured Please try again.");

                }
                finally
                {
                    conn.Close();
                    
                }

                //////////////////////////////////////
                //Update PO Table
                try
                {
                    string rtn1 = @"UPDATE `purchaseordertable` SET `status`= '1' WHERE `po_id` = " + Convert.ToInt32(txtPO.Text) + "";  

                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = rtn1;

                    comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some Exception has Occured Please try again.");

                }
                finally
                {
                    conn.Close();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Invoice Number");
            }

        }
    }
}
