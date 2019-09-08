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
    public partial class ucOrder : UserControl
    {
        private static ucOrder _instance;
        public static ucOrder Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucOrder();
                return _instance;
            }
        }

        public ucOrder()
        {
            InitializeComponent();
        }

        private void ucOrder_Load(object sender, EventArgs e)
        {
            ucInventoryData();
            suppliersList();

        }

        private void ucInventoryData()
        {
            string sqlSelectAll = "SELECT po.`po_id` AS 'ID', ppq.`product_id` AS 'Prod. Id', pro.`proName`AS Product, " +
                "ppq.`product_qty` AS Qty , sup.SupName as Supplier ,po.`datePlaced` AS 'Date Palced', po.`dateExpected` AS 'Date Expected' " +
                "FROM `purchaseordertable` po JOIN `purchaseorder_product_quantitytable` ppq on po.`po_id`= ppq.`purchaseorderId` " +
                "JOIN producttable pro ON ppq.`product_id` = pro.`proId` JOIN suppliertable sup ON po.`supplier_id`=sup.supId WHERE po.`status` = 0";
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

        private void chb()
        {
            string sqlSelectAll;
            if (cmbSupplier.Text != "--Select--")
            {
                 sqlSelectAll = "SELECT po.`po_id` AS 'ID', ppq.`product_id` AS 'Prod. Id', pro.`proName`AS Product, " +
                    "ppq.`product_qty` AS Qty , sup.SupName as Supplier ,po.`datePlaced` AS 'Date Palced', po.`dateExpected` AS 'Date Expected' " +
                    "FROM `purchaseordertable` po JOIN `purchaseorder_product_quantitytable` ppq on po.`po_id`= ppq.`purchaseorderId` " +
                    "JOIN producttable pro ON ppq.`product_id` = pro.`proId` JOIN suppliertable sup ON po.`supplier_id`=sup.supId WHERE sup.SupName='" + cmbSupplier.Text + "' and  po.`dateExpected`='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and po.`status` = 0";
            }
            else
            {
                sqlSelectAll = "SELECT po.`po_id` AS 'ID', ppq.`product_id` AS 'Prod. Id', pro.`proName`AS Product, " +
                   "ppq.`product_qty` AS Qty , sup.SupName as Supplier ,po.`datePlaced` AS 'Date Palced', po.`dateExpected` AS 'Date Expected' " +
                   "FROM `purchaseordertable` po JOIN `purchaseorder_product_quantitytable` ppq on po.`po_id`= ppq.`purchaseorderId` " +
                   "JOIN producttable pro ON ppq.`product_id` = pro.`proId` JOIN suppliertable sup ON po.`supplier_id`=sup.supId WHERE  po.`dateExpected`='" + DateTime.Today.ToString("yyyy-MM-dd") + "' and po.`status` = 0";

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

        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chbStatus.Checked == true)
            {
                chb();
            }
            else
            {
                cmbSupplier.Text = "--Select--";
                ucInventoryData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ucInventoryData();
        }
    }
}
