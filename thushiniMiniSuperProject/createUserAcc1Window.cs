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
   
    public partial class createUserAcc1Window : Form
    {
        public string usernameVariable = null;
        private bool username = false;
        private bool password = false;
        private bool confirm = false;
        public createUserAcc1Window()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            pcUsernameWrong.Visible = false;


            if (txtUsername.TextLength > 5)
            {
                // string ConnectionString = "Server=127.0.0.1;Database=thushiniminisuper;Uid=root;Pwd=;";
                dbString db = new dbString();
                string ConnectionString = db.connectionSring;

                using (MySqlConnection con = new MySqlConnection(ConnectionString))

                    try
                    {
                        con.Open();
                        using (MySqlCommand cmd = con.CreateCommand())
                        {
                            cmd.CommandText = @"select count(*) from employeetable where empUsername=@UserName";
                            cmd.Parameters.Add(new MySqlParameter("UserName", txtUsername.Text));

                            int i = Convert.ToInt32(cmd.ExecuteScalar());
                            if (i == 1)
                            {
                                pbUserNameCorrect.Visible = false;
                                username = false;

                            }
                            else
                            {
                                pbUserNameCorrect.Visible = true;
                                username = true;
                            }
                        }
                    }
                    catch
                    {
                        //does nothing 
                        
                    }
                    finally
                    {
                        con.Close();
                    }

                    
                    }

            else
            {
                pbUserNameCorrect.Visible = false;
                username = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            pcPasswordWrong.Visible = false;
            pcConfirmWrong.Visible = false;
            pbConfirmCorrect.Visible = false;

            if (txtPassword.TextLength > 7)
            {
                pbPassCorrect.Visible = true;
                password = true;

            }
            else
            {
                pbPassCorrect.Visible = false;
                password = false;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            pcConfirmWrong.Visible = false;
            if ((txtConfirmPassword.Text == txtPassword.Text)&& password)
            {
                pbConfirmCorrect.Visible = true;
                confirm = true;
            }
            else
            {
                pbConfirmCorrect.Visible = false;
                confirm = false;
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (! username)
            {
                pbUserNameCorrect.Visible = false;
                pcUsernameWrong.Visible = true;
            }
            if (! password)
            {
                pbPassCorrect.Visible = false;
                pcPasswordWrong.Visible = true;
            }
            if(! confirm)
            {
                pbConfirmCorrect.Visible = false;
                pcConfirmWrong.Visible = true;
            }

            if(password & confirm & username)
            {
                dbString db = new dbString();
                string connString = db.connectionSring;

                MySqlConnection conn = new MySqlConnection(connString);
                try
                {
                    //Send to db
                    // ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                    
                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();                    
                    comm.CommandText = "INSERT INTO `employeetable` (`empId`, `empName`, `empCallingName`, `empNIC`, `empAddress`, `empTelephone`, `empMobile`, `empGender`, `empEmail`, `empUsername`, `empPassword`, `empRole`) VALUES(NULL, '', '', '', '', '', '', '', '', @username, @password, '');";
                    comm.Parameters.AddWithValue("@username", txtUsername.Text);
                    comm.Parameters.AddWithValue("@password", txtPassword.Text);
                    comm.ExecuteNonQuery();
                    conn.Close();


                    //usernameVariable = txtUsername.Text; 
                    this.Hide();
                    var createUser2 = new createUserAcc2Window(true, 0);
                    createUser2.Closed += (s, args) => this.Close();
                    createUser2.Show();
                }
                catch
                {
                    conn.Close();
                }
                finally
                {
                    //Close Connection
                    

                }
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = null;
        }

        private void txtConfirmPassword_Enter(object sender, EventArgs e)
        {
            txtConfirmPassword.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createUser3 = new LoginWindow();
            createUser3.Closed += (s, args) => this.Close();
            createUser3.Show();
        }

        private void createUserAcc1Window_Load(object sender, EventArgs e)
        {
            //
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
