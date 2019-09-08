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
    public partial class createUserAcc2Window : Form
    {
        private bool fullName = true;
        private bool callingName = false;
        private bool nic = false;
        private bool mobile = false;
        private bool telephone = false;
        private bool email = false;
        private bool address = false;

        

        private bool function;
        private int employeeID = 0;

        public createUserAcc2Window(bool function1, int empId) //function true for add, false for update
        {
            InitializeComponent();
            function = function1;
            employeeID = empId;
           
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string gender = "Male";

            if (function == true)
            {
                if (fullName & callingName & nic & telephone & mobile & address & email & (rdoFemale.Checked | rdoMale.Checked))
                {
                    dbString db = new dbString();
                    string connString = db.connectionSring;

                    MySqlConnection conn = new MySqlConnection(connString);
                    if (rdoFemale.Checked)
                    {
                        gender = "Female";

                    }

                    try
                    {

                        conn.Open();
                        MySqlCommand comm = conn.CreateCommand();
                        comm.CommandText = "UPDATE `employeetable` SET `empName` = @dbFullname , `empCallingName` = @dbCallingName, `empNIC` = @dbNic, `empAddress` = @dbAddress, `empTelephone` = @dbTp, `empMobile` = @dbMob, `empGender` = @dbGender, `empEmail` = @dbEmail , `status` = '0' ORDER by `empId` DESC LIMIT 1;";
                        comm.Parameters.AddWithValue("@dbFullname", txtFullName.Text);
                        comm.Parameters.AddWithValue("@dbCallingName", txtCallingName.Text);
                        comm.Parameters.AddWithValue("@dbNic", txtNic.Text);
                        comm.Parameters.AddWithValue("@dbAddress", txtAddress.Text);
                        comm.Parameters.AddWithValue("@dbTp", txtTelephone.Text);
                        comm.Parameters.AddWithValue("@dbMob", txtMobile.Text);
                        comm.Parameters.AddWithValue("@dbGender", gender);
                        comm.Parameters.AddWithValue("@dbEmail", txtEmail.Text);

                        comm.ExecuteNonQuery();
                        
                        MessageBox.Show("New Profile Created Successfully");

                        this.Hide();

                        var createUser3 = new LoginWindow();
                        createUser3.Closed += (s, args) => this.Close();
                        createUser3.Show();

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
                    performValidation();
                }
            }
            else if (function == false) //Update
            {
                if (fullName & callingName & telephone & mobile & address & email)
                {
                   
                    bool statusChecked = true;
                    if (chChecked.Checked == false)
                    {
                        statusChecked = false;
                    }
                    dbString db = new dbString();
                    string connString = db.connectionSring;
                    MySqlConnection conn = new MySqlConnection(connString);


                    try
                    {
                        string query = "UPDATE `employeetable` SET `empName`='" + txtFullName.Text + "' ,`empCallingName`='" + txtCallingName.Text + "',`empAddress`='" + txtAddress.Text + "' ,`empTelephone`='" + txtTelephone.Text + "' ,`empMobile`='" + txtMobile.Text + "',`empEmail`='" + txtEmail.Text + "',`empRole`='" + txtRole.Text + "',`status`=" + statusChecked + " WHERE `empId` ='" + employeeID + "'";
                        conn.Open();
                        MySqlCommand comm = conn.CreateCommand();
                        comm.CommandText = query;
                        comm.ExecuteNonQuery();

                        MessageBox.Show("Profile updated successfully");
                    }
                    catch
                    {

                        MessageBox.Show("Update Failed. Try again shortly");
                    
                    }
                    finally
                    {
                        conn.Close();
                    }
                    this.Close();
                }
                else
                {
                    performValidation();

                }
            }
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^[a-zA-Z]+$");

            if (validator.Match(txtFullName.Text).Success)
            {
                fullName = true;
            }
            else
            {
                fullName = true;
                pbFullName.Visible = false;
                
            }
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            fullName = true;
            pbFullName.Visible = false;
        }

        private void txtCallingName_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^[a-zA-Z]+$");

            if (validator.Match(txtCallingName.Text).Success)
            {
                callingName = true;
            }
            else
            {
                callingName = false;
                pbCallingName.Visible = true;

            }

        }

        private void txtCallingName_TextChanged(object sender, EventArgs e)
        {
            callingName = false;
            pbCallingName.Visible = false;
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

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            if (txtTelephone.Text == "")
            {
                telephone = true;
                pbTp.Visible = false;
            }
            else
            {
                Regex validator = new Regex("^[0][0-9]{9}$");

                if (validator.Match(txtTelephone.Text).Success)
                {
                    telephone = true;
                    pbTp.Visible = false;
                }
                else
                {
                    telephone = false;
                    pbTp.Visible = true;
                }
            }
            

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            telephone = false;
            pbTp.Visible = false;
        }

        private void txtMobile_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex("^[0][0-9]{9}$");

            if (validator.Match(txtMobile.Text).Success)
            {
                mobile = true;
            }
            else
            {
                mobile = false;
                pbMobile.Visible = true;

            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            mobile = false;
            pbMobile.Visible = false;
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            Regex validator1 = new Regex(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");

            if ((validator1.Match(txtEmail.Text).Success))
            {
                email = true;
            }
            else
            {
                email = false;
                pbEmail.Visible = true;

            }
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

        private void performValidation()
        {

            if (fullName == false)
            {
                pbFullName.Visible = true;
            }
            if (callingName == false)
            {
                pbCallingName.Visible = true;
            }
            if (mobile == false)
            {
                pbMobile.Visible = true;
            }
            if (telephone == false)
            {
                pbTp.Visible = true;
            }
            if (email == false)
            {
                pbEmail.Visible = true;
            }
            if (address == false)
            {
                pbAdress.Visible = true;
            }
            if (nic == false)
            {
                pbNic.Visible = true;
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            address = false;
            pbAdress.Visible = false;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = false;
            pbEmail.Visible = false;
        }

        private void createUserAcc2Window_Load(object sender, EventArgs e)
        {
            if (function == false)
            {
                txtNic.Enabled = false; nic = true;
                gbGender.Enabled = false; 
                // Set values to textboxes
                string query = "SELECT `empId`, `empName`, `empCallingName`, `empNIC`, `empAddress`, `empTelephone`, `empMobile`, `empGender`, `empEmail`, `empRole`, `status` FROM `employeetable` WHERE `empId`=" + employeeID + "";
                dbString db = new dbString();
                string connString = db.connectionSring;
                MySqlConnection conn = new MySqlConnection(connString);
                try
                {
                    conn.Open();
                    MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                    MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        txtFullName.Text = rdr[1].ToString();
                        txtAddress.Text = rdr[4].ToString();
                        txtCallingName.Text = rdr[2].ToString();
                        txtNic.Text = rdr[3].ToString();
                        txtTelephone.Text = rdr[5].ToString();
                        txtMobile.Text = rdr[6].ToString();
                        txtEmail.Text = rdr[8].ToString();
                        if (rdr[7].ToString() == "Male")
                        {
                            rdoMale.Checked = true;
                        }
                        else
                        {
                            rdoFemale.Checked = true;
                        }
                        txtRole.Text = rdr[9].ToString();


                    }
                    rdr.Close();
                  //  MessageBox.Show("2");
                }
                catch
                {
                    
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                    fullName = true;
                    callingName = true;
                    nic = true;
                    mobile = true;
                    telephone = true;
                    email = true;
                    address = true;
                }


            }
            else if (function == true)
            {
                
                chChecked.Visible = false;
                chChecked.Checked = false;
                txtRole.Visible = false;
                lblRole.Visible = false;
                button1.Visible = false;
                txtRole.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRole_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
