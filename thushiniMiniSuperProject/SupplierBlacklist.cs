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
    public partial class SupplierBlacklist : Form
    {
        int _supId;
        public SupplierBlacklist(int supId)
        {
            InitializeComponent();
            _supId = supId;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);

            try
            {

                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "UPDATE `suppliertable` SET `supStatus`= 0 ,`supBlackListReason`= '"+textBox1.Text+"',`supBlackListDate`= '" + DateTime.Now.ToString("yyyy-MM-dd") + "'  WHERE `supId` = '"+_supId+"'";
                comm.ExecuteNonQuery();
                MessageBox.Show("Successfully updated");

            }
            catch
            {
                MessageBox.Show("Cannot create the profile at this moment. Please try again.");
            }
            finally
            {
                conn.Close();
            }
            System.Threading.Thread.Sleep(2000);
            this.Close();
        }

        private void SupplierBlacklist_Load(object sender, EventArgs e)
        {
            string query = "SELECT  `SupName`FROM `suppliertable` WHERE `supId` = '" + _supId.ToString() + "' ";
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                // MessageBox.Show("2");
                while (rdr.Read())
                {
                    txtName.Text = rdr[0].ToString();
                    

                }

                rdr.Close();
            }

            catch
            {
                MessageBox.Show("Error");
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
    }
}
