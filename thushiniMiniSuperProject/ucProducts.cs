using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace thushiniMiniSuperProject
{
    public partial class ucProducts : UserControl
    {
        private static ucProducts _instance;

        public static ucProducts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucProducts();
                return _instance;
            }
        }
        public ucProducts()
        {
            InitializeComponent();
            
        }

        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            var invAdd = new invAddProd();
            invAdd.ShowDialog();
            
        }

        private void btnProductPurchase_Click(object sender, EventArgs e)
        {
            var obj = new invPurchaseOrder();
            obj.Show();
        }

        private void ucProducts_Load(object sender, EventArgs e)
        {
            btnUpdateProducts.Hide();
           // refreshProducts();
            suppliersList();

            //dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Product Name";
            
            dataGridView1.Columns[2].Name = "Selling Price";
            dataGridView1.Columns[3].Name = "Min Price";
            dataGridView1.Columns[4].Name = "Safety Stock";
            dataGridView1.Columns[5].Name = "Stock";
            dataGridView1.Columns[6].Name = "Supplier Name";
           

            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[6].Width = 250;

            dataGridView1.Columns[0].MinimumWidth = 120;
            dataGridView1.Columns[1].MinimumWidth = 250;
            dataGridView1.Columns[2].MinimumWidth = 100;
            dataGridView1.Columns[3].MinimumWidth = 80;
            dataGridView1.Columns[4].MinimumWidth = 80;
            dataGridView1.Columns[5].MinimumWidth = 80;
            //dataGridView1.Columns[5].MinimumWidth = 150;
            btnRefresh.PerformClick();
        }
        public void refreshProducts()
        {
            cmbSupplier.Text = "--Select--";
            string sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                "`Selling Price`, a.`proMinPrice` as `Min Price`, a.`proMinStock` as 'Safety Stock', a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` LIMIT 50";
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshProducts();
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void suppliersList()
        {   dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                string query = "SELECT `supId`,`SupName` FROM `suppliertable` WHERE `supStatus` = 1";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                cmbSupplier.DataSource = dataTable;
                cmbSupplier.DisplayMember = "SupName";
                cmbSupplier.ValueMember = "supId";


            }
            catch
            {
                MessageBox.Show("Erro r");
            }
            finally
            {
                con.Close();
            }
        }

        private void updateDataGridView()
        {
            if (cmbSupplier.Text == "--Select--")
            {
                refreshProducts();
            }
            else
            {

            }
        }
        public void refreshProductsSupplier()
        {
            
            string sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                "`Selling Price`, a.`proMinPrice` as `Min Price`,a.`proMinStock` as 'Safety Stock' , a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` and b.`SupName`='"+cmbSupplier.Text+"' LIMIT 50";
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
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProductsSupplier();
        }

        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {
            chbStockinRisk.Checked = false;
            if (chbStatus.Checked)
            {
                ZeroStock();
            }
            else
            {
                btnRefresh.PerformClick();
            }
        }

        private void ZeroStock()
        {
            string sqlSelectAll;

            if (cmbSupplier.Text == "--Select--")
            {
                 sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                   "`Selling Price`, a.`proMinPrice` as `Min Price`,a.`proMinStock` as 'Safety Stock' , a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                   " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` and a.`proStock`<=0 LIMIT 50";
            }
            else
            {
                 sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                   "`Selling Price`, a.`proMinPrice` as `Min Price`,a.`proMinStock` as 'Safety Stock' , a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                   " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` and b.`SupName`='" + cmbSupplier.Text + "'and a.`proStock`<=0 LIMIT 50";
            }
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
        }

        private void chbStockinRisk_CheckedChanged(object sender, EventArgs e)
        {
            chbStatus.Checked = false;
            string sqlSelectAll;

            if (cmbSupplier.Text == "--Select--")
            {
                sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                  "`Selling Price`, a.`proMinPrice` as `Min Price`,a.`proMinStock` as 'Safety Stock' , a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                  " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` and a.`proStock`<=a.`proMinStock` and a.`proStock`>0  LIMIT 50";
            }
            else
            {
                sqlSelectAll = "SELECT a.`proId` AS `ID`,a.`proName` AS `Name`, a.`proDiscountPrice` as " +
                  "`Selling Price`, a.`proMinPrice` as `Min Price`,a.`proMinStock` as 'Safety Stock' , a.`proStock` as `Stock`, b.`SupName` as `Supplier`" +
                  " FROM `producttable` a, `suppliertable` b where a.`proSupplierId` = b.`supId` and b.`SupName`='" + cmbSupplier.Text + "'and a.`proStock`<= a.`proMinStock` and a.`proStock`>0  LIMIT 50";
            }
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
        }

        private void btnUpdateProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
