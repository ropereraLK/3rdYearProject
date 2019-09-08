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
    public partial class ucEmployees : UserControl
    {
       // string sqlSelectAll = "SELECT `empId` as`E No.` , `empName` as `Full Name`, `empCallingName` as `Calling Name`, `empNIC` as  `NIC`,  `empMobile` as `Mobile` FROM `employeetable`  WHERE `status` = 1";

        public void ucInventoryData ()
        {
            string   sqlSelectAll = "SELECT `empId` as`E No.` , `empName` as `Full Name`, `empCallingName` as `Calling Name`, `empNIC` as  `NIC`,  `empMobile` as `Mobile` FROM `employeetable`  WHERE `status` = 1";
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
        private static ucEmployees _instance;

        public static ucEmployees Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucEmployees();
                return _instance;
            }
        }

        public ucEmployees()
        {
            InitializeComponent();
            ucInventoryData();
        }

        private void ucInventory_Load(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucEmployees_Enter(object sender, EventArgs e)
        {
        }

        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chbStatus.Checked == false)
            {
                string sqlSelectAll = "SELECT `empId` as`E No.` , `empName` as `Full Name`, `empCallingName` as `Calling Name`, `empNIC` as  `NIC`,  `empMobile` as `Mobile` FROM `employeetable`  WHERE `status` = 0";
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
                string sqlSelectAll = "SELECT `empId` as`E No.` , `empName` as `Full Name`, `empCallingName` as `Calling Name`, `empNIC` as  `NIC`,  `empMobile` as `Mobile` FROM `employeetable`  WHERE `status` = 1";
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

        private void chbStatus_CheckStateChanged(object sender, EventArgs e)
        {
         
        }

        private void btnUpdateProducts_Click(object sender, EventArgs e)
        {
           
                var x = new empView(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                x.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var x = new createUserAcc2Window(false, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            x.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string sqlSelectAll = "SELECT `empId` as`E No.` , `empName` as `Full Name`, `empCallingName` as `Calling Name`, `empNIC` as  `NIC`,  `empMobile` as `Mobile` FROM `employeetable`  WHERE `status` = 1";
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

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.White;
        }

        private void btnRefresh_Enter(object sender, EventArgs e)
        {
            btnRefresh.BackColor = Color.White;
        }
    }
}
