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

namespace thushiniMiniSuperProject
{
    public partial class SupplierUpdate : Form
    {
        int _supId; //for  add 
        bool name = true;
        bool address = true;
        bool telephone = true;
        bool agentName = true;
        bool agentTelephone = true;
        bool bankNo = true;
        bool bank = true;
        bool bankBranch = true;

       

        public SupplierUpdate(int purpose)
        {
            _supId = purpose;
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if ((name & address & agentName & telephone & agentTelephone & bank & bankBranch & bankNo) == true)
            {
                dbString db = new dbString();
                string connString = db.connectionSring;
                MySqlConnection conn = new MySqlConnection(connString);

                try
                {

                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = "UPDATE `suppliertable` SET `SupName`= '" + txtName.Text + "',`supAddress`='" + txtAddress.Text + "',`supTp`='" + txtTelephone.Text + "',`supAgentName`='" + txtAgentName.Text + "',`supAgentTp`='" + txtAgentTP.Text + "',`supBankName`='" + txtBank.Text + "',`supBankNo`='" + txtBankAccount.Text + "',`supBankBranch`='" + txtBranch.Text + "' WHERE `supId` = '" + _supId.ToString() + "'";
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
            }
            else
            {
                updateCheck();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var invWin = new SupplierBlacklist(_supId);
            invWin.Closed += (s, args) => this.Close();
            invWin.ShowDialog(); 
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            pbName.Visible = false;
            name = false;

        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                pbName.Visible = true;
                name = false;
            }
            else
            {
                pbName.Visible = false;
                name = true;

            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            pbAdress.Visible = false;
            address = false;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == "")
            {
                pbAdress.Visible = true;
                address = false;
            }
            else
            {
                pbAdress.Visible = false;
                address = true;

            }

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            telephone = false;
            pbTp.Visible = false;
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex("^[0][0-9]{9}$");

            if (validator.Match(txtTelephone.Text).Success)
            {
                telephone = true;
            }
            else
            {
                telephone = false;
                pbTp.Visible = true;
            }

        }

        private void txtAgentName_TextChanged(object sender, EventArgs e)
        {
            pbAgentName.Visible = false;
            agentName = false;

        }

        private void txtAgentName_Leave(object sender, EventArgs e)
        {
            if (txtAgentName.Text == "")
            {
                pbAgentName.Visible = true;
                agentName = false;
            }
            else
            {
                pbAgentName.Visible = false;
                agentName = true;
            }

        }

        private void txtAgentTP_TextChanged(object sender, EventArgs e)
        {
            agentTelephone = false;
            pbAgentTp.Visible = false;
        }

        private void txtAgentTP_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex("^[0][0-9]{9}$");

            if (validator.Match(txtAgentTP.Text).Success)
            {
                agentTelephone = true;
            }
            else
            {
                agentTelephone = false;
                pbAgentTp.Visible = true;
            }
        }

        private void txtBankAccount_TextChanged(object sender, EventArgs e)
        {
            pbBankNo.Visible = false;
            bankNo = false;
        }

        private void txtBankAccount_Leave(object sender, EventArgs e)
        {

            if (txtBankAccount.Text == "")
            {
                pbBankNo.Visible = true;
                bankNo = false;
            }
            else
            {
                pbBankNo.Visible = false;
                bankNo = true;
            }


        }

        private void txtBank_TextChanged(object sender, EventArgs e)
        {
            pbBank.Visible = false;
            bank = false;
        }

        private void txtBank_Leave(object sender, EventArgs e)
        {
            if (txtBank.Text == "")
            {
                pbBank.Visible = true;
                bank = false;
            }
            else
            {
                pbBank.Visible = false;
                bank = true;
            }
        }

        private void txtBranch_TextChanged(object sender, EventArgs e)
        {
            pbBranch1.Visible = false;
            bankBranch = false;

        }

        private void txtBranch_Leave(object sender, EventArgs e)
        {
            if (txtBranch.Text == "")
            {
                pbBranch1.Visible = true;
                bankBranch = false;
            }
            else
            {
                pbBranch1.Visible = false;
                bankBranch = true;
            }

        }

        private void SupplierUpdate_Load(object sender, EventArgs e)
        {
            string query = "SELECT  `SupName`, `supAddress`, `supTp`, `supAgentName`, `supAgentTp`, `supBankName`, `supBankNo`, `supBankBranch`, `supStatus`, `supBlackListReason`, `supBlackListDate`, `supStartDate` FROM `suppliertable` WHERE `supId` = '" + _supId.ToString() + "' ";
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

                }

                rdr.Close();
            }

            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                 name = true;
                 address = true;
                 telephone = true;
                 agentName = true;
                 agentTelephone = true;
                 bankNo = true;
                 bank = true;
                 bankBranch = true;

                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateCheck()
        {
            if (bankBranch == false)
            {
                pbBranch.Visible = true;
            }
            if (bank == false)
            {
                pbBank.Visible = true;
            }
            if (bankNo == false)
            {
                pbBankNo.Visible = true;
            }
            if (agentName == false)
            {
                pbAgentTp.Visible = true;
            }
            if (telephone == false)
            {
                pbTp.Visible = true;
            }
            if (name == false)
            {
                pbName.Visible = true;
            }
            if (address == false)
            {
                pbAdress.Visible = true;
            }
        }
    }
    } 
