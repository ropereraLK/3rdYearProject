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

namespace thushiniMiniSuperProject
{
    public partial class posMySummery : Form
    {
        private string username;
        public posMySummery(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void posMySummery_Load(object sender, EventArgs e)
        {
            label4.Hide();
            txtHours.Hide();
            int salesId = 0;
            //Username
            txtUserName.Text = username;

            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                
                conn.Open();
                //string rtn = @"SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock, producttable.proReplacementTime, producttable.proStock, SUM(sales_producttable.productQty) AS forecast FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId WHERE sales_producttable.salesDate < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-28).ToString("yyyy-MM-dd") + "' AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = @supplierName LIMIT 1) AND producttable.proStatus = 1 GROUP BY producttable.proId ASC";
                string rtn = "SELECT `salesId`, `salesTime` FROM `salestable` WHERE `salesDate` = '"+DateTime.Today.ToString("yyyy-MM-dd") + "' AND `salesEmpUsername` = '"+username+"' ORDER BY `salesId` ASC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
               
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {

                    salesId=Convert.ToInt32(rdr[0]);
                    txtLoggedin.Text=rdr[1].ToString();
                }

            }
            catch (Exception exb)
            {
                //MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();
                
            }

            

            String rtn1 = "SELECT sum(`salesTotal`) FROM `salestable` WHERE `salesId` > "+(salesId-1) +" AND `salesEmpUsername` = '"+username+"' ";
            try
            {
               
                conn.Open();
                //string rtn = @"SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock, producttable.proReplacementTime, producttable.proStock, SUM(sales_producttable.productQty) AS forecast FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId WHERE sales_producttable.salesDate < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-28).ToString("yyyy-MM-dd") + "' AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = @supplierName LIMIT 1) AND producttable.proStatus = 1 GROUP BY producttable.proId ASC";
                //string rtn = "SELECT `salesId`, `salesTime` FROM `salestable` WHERE `salesDate` = '" + DateTime.Today.ToString("yyyy-MM-dd") + "' AND `salesEmpUsername` = '" + username + "' ORDER BY `salesId` ASC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(rtn1, conn);

                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {

                    txtTotalSales.Text = (rdr[0]).ToString();
                    
                }

            }
            catch (Exception exb)
            {
                //MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();

            }

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
