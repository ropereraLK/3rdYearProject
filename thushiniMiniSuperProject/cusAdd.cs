using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace thushiniMiniSuperProject
{
    public partial class cusAdd : Form
    {
        bool appNo = false;
        bool fname = false;
        bool lname = false;
        bool nic = false;
        bool tp = true;
        bool mob = false;
        bool email = true;
        bool address = false;
        
        private void sendToDB()
        {
            if(appNo & fname & lname & nic & tp & mob & email & address)
            { string title;
                if (rdoMale.Checked == true)
                {
                    title = "Male";

                }
                else
                {
                    title = "Female";
                }
                string q = "INSERT INTO `customertable`(`cusNic`, `cusId`, `cusTitle`, `cusFirstName`, `cusLastName`,  `cusTelephone`, `cusMobile`, `cusEmail`, `cusAddress`, `cusApplicationNo`, `cusDateRegister`, `cusLoyaltyPoints`) VALUES ('"+ txtNic.Text+ "','" + txtCardNo.Text + "','" + title + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtTelephone.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "','" + txtAddress.Text + "','" + txtAppNo.Text + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '0')";
                //

                dbString db = new dbString();
                string connString = db.connectionSring;
                MySqlConnection conn = new MySqlConnection(connString);
                try
                {
                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = q;
                    

                    comm.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully");

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
                if (address == false)
                {
                    pbAdress.Visible = true;
                }
                if ( email== false)
                {
                    pbEmail.Visible = true;
                }
                if (mob == false)
                {
                    pbMobile.Visible = true;
                }
                if (tp == false)
                {
                    pbTp.Visible = true;
                }
                if (nic == false)
                {
                    pbNic.Visible = true;
                }
                if ( lname== false)
                {
                    pbLastName.Visible = true;
                }
                if ( fname== false)
                {
                    pbFirstName.Visible = true;
                }
                if (appNo == false)
                {
                    pbApplication.Visible = true;
                }

            }
        }

        private void enableDisableComp(bool status)
        {
            txtAppNo.Enabled = status;
            txtFirstName.Enabled = status;
            txtLastName.Enabled = status;
            txtNic.Enabled = status;
            gbGender.Enabled = status;
            txtTelephone.Enabled = status;
            txtMobile.Enabled = status;
            txtEmail.Enabled = status;
            txtAddress.Enabled = status;
            btnSubmit.Enabled = status;
        }
        public cusAdd()
        {
            InitializeComponent();
        }

        private void cusAdd_Load(object sender, EventArgs e)
        {
            enableDisableComp(false);


        }

        private void txtCardNo_TextChanged(object sender, EventArgs e)
        {
            Regex validator = new Regex("^['C'][0-9]{5}$");

            if (validator.Match(txtCardNo.Text).Success)
            {//Check the availability from Db


                txtCardNo.Enabled = false;
                pbCardCorrect.Visible = true;
                enableDisableComp(true);
            }

            pbCard.Visible = false;
        }

        private void txtCardNo_Leave(object sender, EventArgs e)
        {
            pbCard.Visible = true;
        }
        private void txtAppNo_TextChanged(object sender, EventArgs e)
        {
            pbApplication.Visible = false;
            appNo = false;
        }

        private void txtAppNo_Leave(object sender, EventArgs e)
        {
            if (txtAppNo.Text == null)
            {
                pbApplication.Visible = true;


            }
            else
            {
                appNo = true;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            fname = false;
            pbFirstName.Visible = false;
        }

        private void txtFirstName_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^[a-zA-Z]+$");

            if (validator.Match(txtFirstName.Text).Success)
            {
                fname = true;

            }
            else
            {
                pbFirstName.Visible = true;

            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            lname = false;
            pbLastName.Visible = false;
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {

            Regex validator = new Regex(@"^[a-zA-Z]+$");

            if (validator.Match(txtLastName.Text).Success)
            {
                lname = true;

            }
            else
            {
                pbLastName.Visible = true;

            }
        }

        private void txtNic_TextChanged(object sender, EventArgs e)
        {
            nic = false;
            pbNic.Visible = false;
        }

        private void txtNic_Leave(object sender, EventArgs e)
        {
            Regex validator1 = new Regex("^[0-9]{9}['V'|'v']$");
            Regex validator2 = new Regex("^[0-9]{12}$");

            if ((validator1.Match(txtNic.Text).Success) || (validator2.Match(txtNic.Text).Success))
            {
                nic = true;
            }
            else
            {
                nic = false;
                pbNic.Visible = true;
            }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            tp = false;
            pbTp.Visible = false;
        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                tp = true;
                pbTp.Visible = false;
            }
            else
            { 

            Regex validator = new Regex("^[0][0-9]{9}$");

            if (validator.Match(txtTelephone.Text).Success)
            {
                tp = true;
                    pbTp.Visible = false;
            }

            else
            {
                tp = false;
                pbTp.Visible = true;
            }

        }
           
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            mob = false;
            pbMobile.Visible = false;

        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex("^[0][0-9]{9}$");

            if (validator.Match(txtMobile.Text).Success)
            {
                mob = true;
            }
            else
            {
                mob = false;
                pbMobile.Visible = true;

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = false;
            pbEmail.Visible = false;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                email = true;
                pbEmail.Visible = false;
            }
            else
            {
                Regex validator1 = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

                if ((validator1.Match(txtEmail.Text).Success))
                {
                    email = true;
                    pbEmail.Visible = false;
                }
                else
                {
                    email = false;
                    pbEmail.Visible = true;

                }
            }
           
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            address = false;
            pbAdress.Visible = false;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            if (txtAddress.Text == null)
            {
                address = false;
            }
            else
            {
                address = true;
                pbAdress.Visible = false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            sendToDB();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
