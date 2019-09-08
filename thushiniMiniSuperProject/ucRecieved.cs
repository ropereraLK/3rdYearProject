using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thushiniMiniSuperProject.ReceiveProducts;
using MySql.Data.MySqlClient;

namespace thushiniMiniSuperProject
{
    public partial class ucRecieved : UserControl
    {
        private static ucRecieved _instance;
        public static ucRecieved Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucRecieved();
                return _instance;
            }
        }
        public ucRecieved()
        {
            InitializeComponent();
        }

        private void btnProductRecieve_Click(object sender, EventArgs e)
        {
            var Recieved = new RecievedProducts();
            Recieved.Show();


        }

        private void ucRecieved_Load(object sender, EventArgs e)
        {
            btnProductReturn.Hide();
            refreshProducts();
            suppliersList();
        }

        public void refreshProducts()
        {
            //cmbSupplier.Text = "--Select--";
            string sqlSelectAll = @"SELECT r.`recievedId`, r.`poId`, r.`invoiceNo`, r.`recievedDate`, r.`total`, s.`SupName` FROM `recievedtable` r join   `purchaseordertable` po on r.`poId`=po.`po_id` join  `suppliertable` s on s.supId=po.supplier_id";
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
        private void suppliersList()
        {
            dbString dbc = new dbString();
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
        public void refreshProductsSupplier()
        {
           
            string sqlSelectAll = @"SELECT r.`recievedId`, r.`poId`, r.`invoiceNo`, r.`recievedDate`, r.`total`, s.`SupName` FROM `recievedtable` r join `purchaseordertable` po on r.`poId`=po.`po_id` join `suppliertable` s on s.supId=po.supplier_id WHERE `SupName`= '"+cmbSupplier.Text+"'";
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
               // cmbSupplier.Text = "--Select--";
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshProductsSupplier();
        }
    }
}
