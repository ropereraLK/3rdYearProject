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
    public partial class ucSuppliers : UserControl
    {
        private static ucSuppliers _instance;

        public static ucSuppliers Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucSuppliers();
                    return _instance;
            }
        }
        public ucSuppliers()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form addSuppliers = new SupplierAdd(1);
            addSuppliers.Show();
        }

        private void ucSuppliers_Load(object sender, EventArgs e)
        {
            string sqlSelectAll = "SELECT `supId`  as`ID` , `SupName` as`Name` , `supTp` as`Telephone` , `supAgentName` as`Agent Name` , `supAgentTp` as`Agent Telephone` FROM `suppliertable` WHERE `supStatus` = 1 ";
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
            var supplier = new SupplierAdd(1);
            supplier.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var supplier = new SupplierUpdate(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            supplier.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // var x = new createUserAcc2Window(false, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
           
            var supplier = new supplierView(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            supplier.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            chbStatus.Checked = false;
            string sqlSelectAll = "SELECT `supId`  as`ID` , `SupName` as`Name`   , `supTp` as`Telephone` , `supAgentName` as`Agent Name` , `supAgentTp` as`Agent Telephone` FROM `suppliertable` WHERE `supStatus` = 1 ";
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
                string sqlSelectAll = "SELECT `supId`  as`ID` , `SupName` as`Name` ,   `supTp` as`Telephone` , `supAgentName` as`Agent Name` , `supAgentTp` as`Agent Telephone` FROM `suppliertable` WHERE `supStatus` = 0 ";
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
            else
            {
                string sqlSelectAll = "SELECT `supId`  as`ID` , `SupName` as`Name`  , `supTp` as`Telephone` , `supAgentName` as`Agent Name` , `supAgentTp` as`Agent Telephone` FROM `suppliertable` WHERE `supStatus` = 1 ";
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
        }
    }
}
