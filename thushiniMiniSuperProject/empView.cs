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
    public partial class empView : Form
    {
        int employeeID;
        public empView(int empId)
        {
            InitializeComponent();
            employeeID = empId;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void empView_Load(object sender, EventArgs e)
        {
            string query = "SELECT `empId`, `empName`, `empCallingName`, `empNIC`, `empAddress`, `empTelephone`, `empMobile`, `empGender`, `empEmail`, `empRole`, `status` FROM `employeetable` WHERE `empId`=" + employeeID + "";
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
                    else {
                        rdoFemale.Checked = true;
                    }
                    textBox1.Text= rdr[9].ToString();


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
