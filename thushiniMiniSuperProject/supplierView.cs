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
    public partial class supplierView : Form
    {
        int _supId = 0;
        public supplierView(int supId )
        {
            InitializeComponent();
            _supId = supId;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inventorySupplierView_Load(object sender, EventArgs e)
        {
            
            string query = "SELECT  `SupName`, `supAddress`, `supTp`, `supAgentName`, `supAgentTp`, `supBankName`, `supBankNo`, `supBankBranch`, `supStatus`, `supBlackListReason`, `supBlackListDate` FROM `suppliertable` WHERE `supId` = '" + _supId.ToString() + "' " ;
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
                    txtAddress.Text = rdr[1].ToString();
                    txtTelephone.Text = rdr[2].ToString();
                    txtAgentName.Text = rdr[3].ToString();
                    txtAgentTP.Text = rdr[4].ToString();
                    txtBankAccount.Text = rdr[6].ToString();
                    txtBank.Text = rdr[5].ToString();
                    txtBranch.Text = rdr[7].ToString();
                    txtReason.Text = rdr[9].ToString();
                    

                    //Status
                    if (Convert.ToInt32(rdr[8]) == 1)
                    {
                        chbStatus.Checked = false;
                    }
                    else
                    {
                        chbStatus.Checked = true;
                        txtFrom.Text = rdr[10].ToString();
                    }
                   // textBox1.Text = rdr[9].ToString();


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
    }
}
