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
    public partial class SupplierAdd : Form
    {
        public static int FormPurpose; //for  add 
        bool name = false;
        bool address = false;
        bool telephone = false;
        bool agentName = false;
        bool agentTelephone = false;
        bool bankNo = false;
        bool bank = false;
        bool bankBranch = false;

        public SupplierAdd(int purpose)
        {
            FormPurpose = purpose;
            InitializeComponent();
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

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Adding New Supplier
            {
                dbString db = new dbString();
                string connString = db.connectionSring;
                MySqlConnection conn = new MySqlConnection(connString);

                if (name & address & telephone & agentName & agentTelephone & bank & bankBranch & bankNo) {
                    try
                    {
                        conn.Open();
                        MySqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "INSERT INTO `suppliertable` (`supId`, `SupName`, `supAddress`, `supTp`, `supAgentName`, `supAgentTp`, `supBankName`, `supBankNo`, `supBankBranch`, `supStatus`, `supBlackListReason`, `supBlackListDate`, `supplierCurrentOutstanding`) VALUES (NULL, @dbName, @dbAddress,@dbTp , @dbAgentName, @dbAgentTp, @dbBank, @dbBankNo, @dbBranch, '1', '', CURRENT_TIMESTAMP, '0')";
                        comm.Parameters.AddWithValue("@dbName", txtName.Text);
                        comm.Parameters.AddWithValue("@dbAddress", txtAddress.Text);
                        comm.Parameters.AddWithValue("@dbTp", txtTelephone.Text);
                        comm.Parameters.AddWithValue("@dbAgentName", txtAgentName.Text);
                        comm.Parameters.AddWithValue("@dbAgentTp", txtAgentTP.Text);
                        comm.Parameters.AddWithValue("@dbBankNo", txtBankAccount.Text);
                        comm.Parameters.AddWithValue("@dbBank", txtBank.Text);
                        comm.Parameters.AddWithValue("@dbBranch", txtBranch.Text);

                        comm.ExecuteNonQuery();
                        MessageBox.Show("Supplier added Successfully");

                    }
                    catch
                    {
                        MessageBox.Show("Exception Occured");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    if(name == false)
                    {
                        pbName.Visible = true;
                    }
                    if (address == false)
                    {
                        pbAdress.Visible = true;
                    }
                    if (telephone == false)
                    {
                        pbTp.Visible = true;
                    }
                    if (agentName == false)
                    {
                        pbAgentName.Visible = true;
                    }
                    if (agentTelephone == false)
                    {
                        pbAgentTp.Visible = true;
                    }
                    if (bank == false)
                    {
                        pbBank.Visible = true;
                    }
                    if (bankNo == false)
                    {
                        pbBankNo.Visible = true;
                    }
                    if (bankBranch == false)
                    {
                        pbBranch1.Visible = true;
                    }
                    MessageBox.Show("Incomplete");
                }

            }
        }

        private void inventorySupplier_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
