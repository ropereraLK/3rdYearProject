using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thushiniMiniSuperProject.Reports;
using MySql.Data.MySqlClient;

namespace thushiniMiniSuperProject
{
    public partial class Performance : UserControl
    {
        private static Performance _instance;

        public static Performance Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Performance();
                return _instance;
            }
        }
        public Performance()
        {
            InitializeComponent();
            txtDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var sales = new Sales();
            sales.ShowDialog();
        }     private void btnProduct_Click(object sender, EventArgs e)
        {
            var productSumm = new productSummery();
            productSumm.ShowDialog();
        }

        private void Performance_Load(object sender, EventArgs e)
        {
            updateDatagrid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateDatagrid()
        {
            string sqlSelectAll = "SELECT `salesEmpUsername` as 'User Name' , COUNT(`salesId`) as 'No. of Transactions', SUM(`salesTotal`) as 'Total Sales' FROM salestable WHERE `salesDate`= '" + txtDate.Text + "' GROUP BY `salesEmpUsername`";
            dbString db = new dbString();
            string connectionString = db.connectionSring;
            MySqlConnection mysqlCon = new MySqlConnection(connectionString);
            try
            {
                mysqlCon.Open();
                MySqlDataAdapter MyDA = new MySqlDataAdapter();

                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;


                dataGridView1.DataSource = bSource;
            }
            catch
            {

            }
            finally
            {
                mysqlCon.Close();
            }
            string rtn = "SELECT   COUNT(`salesId`) as 'No. of Transactions', SUM(`salesTotal`) as 'Total Sales' FROM salestable WHERE `salesDate`= '" + txtDate.Text + "' ";


            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                //AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-30).ToString("yyyy - MM - dd") + "' 
                conn.Open();
              //  string rtn = @"SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock, producttable.proReplacementTime, producttable.proStock, SUM(sales_producttable.productQty) AS forecast FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId WHERE producttable.proStatus = 1 and sales_producttable.salesDate < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-28).ToString("yyyy-MM-dd") + "' AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = @supplierName LIMIT 1) AND producttable.proStatus = 1 GROUP BY producttable.proId ASC";

                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                //cmd.CommandType = CommandType.StoredProcedure;

             

                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    txtSalesTotal.Text = rdr[1].ToString();
                    txtTotalTransactions.Text = rdr[0].ToString();

                }

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

       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            updateDatagrid();
        }
    }
}
