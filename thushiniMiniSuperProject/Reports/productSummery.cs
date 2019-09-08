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
using System.Windows.Forms.DataVisualization.Charting;

namespace thushiniMiniSuperProject.Reports
{
    public partial class productSummery : Form
    {
        public productSummery()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create Chart
        /// </summary>
        private void fillChart()
        {
            chart1.Series.Clear();
            Series s = new Series("Value");
            chart1.Series.Add(s);

            //chart1.Series[0].Name = "Salary";
            //Series[0].Points.Clear();
            /*chart1.Series["Salary"].Points.AddXY("Ramesh", "8000");
            chart1.Series["Salary"].Points.AddXY("Ankit", "7000");
            chart1.Series["Salary"].Points.AddXY("Gurmeet", "10000");
            chart1.Series["Salary"].Points.AddXY("Suresh", "8500");*/
            for (int counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                //string x = (dataGridView1.Rows[counter].Cells[0].Value).ToString();
                chart1.Series["Value"].Points.AddXY(counter + 1, dataGridView1.Rows[counter].Cells[1].Value);

            }
        }

        /// <summary>
        /// Create Datagrid
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="duration"></param>
        /// 
        String queryString = "";
        String duration = "";
        /// 
        private void updateDataGridView(String queryString, String duration)
        {
            //Removing previous content
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = duration;
            dataGridView1.Columns[1].Name = "Sales Amount";

            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(queryString, con);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    //txtSupName.Text = (rdr[4]).ToString();
                    // txtPlaced.Text = (rdr[5]).ToString();
                    // txtExpected.Text = (rdr[6]).ToString();

                    string[] row = new string[] { (rdr[0]).ToString(), (rdr[1]).ToString() };
                    dataGridView1.Rows.Add(row);
                    //productList.Add(new InvPurchaseOrder.NodePO(Convert.ToInt32(rdr[0]), rdr[1].ToString(), Convert.ToSingle(rdr[2]), Convert.ToSingle(rdr[3]), Convert.ToSingle(rdr[4]), Convert.ToSingle(rdr[6]), Convert.ToInt32(rdr[5]), Convert.ToSingle(rdr[7])));
                }
            }
            catch (Exception exec)
            {
              //  MessageBox.Show("Erro r" + exec);
            }
            finally
            {
                con.Close();
                duration = "";
                queryString = "";
            }
        }

        /// <summary>
        /// End
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productSummery_Load(object sender, EventArgs e)
        {
            //TextBox Values
            cmbSelect.Text = "Yearly";
            cmbType.Text = "By Qty";
            cmbYear.Text = "2019";
            cmbMonth.Text = "January";
            cmbCategory.Text = "Select";
            cmbSubC.Text = "Select";
            cmbProduct.Text = "Select";

            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT `categoryId`, `categoryName` FROM `productcategory` WHERE 1";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow();
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(dataRow, 0);
                cmbCategory.DataSource = dataTable;
                cmbCategory.DisplayMember = "categoryName";
                cmbCategory.ValueMember = "categoryId";
            }
            catch { }
            finally {
                con.Close();

            }



            }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT `subcategoryId`, `subcategoryname` FROM `productsubcategory` WHERE `maincategoryId` = (SELECT `categoryId` FROM `productcategory` WHERE `categoryName` = '" + cmbCategory.Text + "')";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow()
                    ;
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(dataRow, 0);
                cmbSubC.DataSource = dataTable;
                cmbSubC.DisplayMember = "subcategoryname";
                cmbSubC.ValueMember = "subcategoryId";

            }
            catch
            {
              //  MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmbSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelect.Text == "Yearly")
            {
                cmbYear.Hide();
                cmbMonth.Hide();
                lblMonth.Hide();
                lblYear.Hide();


            }
            else if (cmbSelect.Text == "Monthly")
            {
                cmbMonth.Hide();
                cmbYear.Show();
                lblMonth.Hide();
                lblYear.Show();


            }
            else if (cmbSelect.Text == "Daily")
            {
                cmbMonth.Show();
                cmbYear.Show();
                lblMonth.Show();
                lblYear.Show();



            }

            if (cmbSelect.Text == "Yearly" && cmbCategory.Text == "--Select--" && cmbType.Text=="By Value")
            {
                //MessageBox.Show("Hi Value");
                queryString = "SELECT DATE_FORMAT(salesDate, '%Y'), SUM(salesTotal)FROM salestable GROUP BY DATE_FORMAT(salesDate, '%Y')";
                duration = "Year";
                updateDataGridView(queryString, duration);
                fillChart();
                
            }
            else if (cmbSelect.Text == "Yearly" && cmbCategory.Text == "--Select--" && cmbType.Text == "By Qty")
            {
                queryString = "SELECT DATE_FORMAT(sales.salesDate, '%Y') AS 'Year', SUM(sp.`productQty`) FROM sales_producttable sp JOIN salestable sales ON sp.salesId= sales.salesId GROUP BY DATE_FORMAT(sales.salesDate, '%Y')";
                duration = "Year";
                updateDataGridView(queryString, duration);
                fillChart();
            }
        }

        private void cmbSubC_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT `proId`, `proName`FROM `producttable` WHERE `proSubCategory`= '" + cmbSubC.Text + "'";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow();
                    
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(dataRow, 0);
                cmbProduct.DataSource = dataTable;
                cmbProduct.DisplayMember = "proName";
                cmbProduct.ValueMember = "proId";

            }
            catch
            {
               // MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
