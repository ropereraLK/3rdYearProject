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
    public partial class LoginWindow : Form

    {
        string empId = null;
        string empRole = null;
        string empUsername = null;
        public LoginWindow()
        {
            InitializeComponent();

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            var createUser = new createUserAcc1Window();
            createUser.Closed += (s, args) => this.Close();
            createUser.Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            string query = "SELECT `empId`, `empUsername`, `empRole` FROM `employeetable` WHERE `empUsername` = '"+ txtUserName.Text+"' AND`empPassword`= '"+txtPassword.Text+"' AND`status`= 1";

          
            conn.Open();
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                // MessageBox.Show("2");
                while (rdr.Read())
                {
                     empId = rdr[0].ToString();
                    empUsername = rdr[1].ToString();

                     empRole = rdr[2].ToString();
                    
                }
                rdr.Close();

            }
            catch
            {
                MessageBox.Show("Error Connecting with the database. Try again Shortly.");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            if(empRole == "sales")
            {
                this.Hide();
                var posWin = new posWindow(empUsername,empRole,empId);
                empId = null;
                empRole = null;
                empUsername = null;

                posWin.Closed += (s, args) => this.Close();
                posWin.Show();

            }
            else if (empRole == "stores")
            {
                this.Hide();
                var invWin = new inventoryWindow(empUsername, empRole);
                empId = null;
                empRole = null;
                empUsername = null;

                invWin.Closed += (s, args) => this.Close();
                invWin.Show();

            }
            else if (empRole == "admin")
            {
                this.Hide();
                var invWin = new inventoryWindow(empUsername, empRole);
                empId = null;
                empRole = null;
                empUsername = null;

                invWin.Closed += (s, args) => this.Close();
                invWin.Show();

            }
            else
            {
                MessageBox.Show("Username or Password is Incorrect !");
            }
        }
           
         

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(this, new EventArgs());
            }
        }

        private void LoginWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }
    }
}
