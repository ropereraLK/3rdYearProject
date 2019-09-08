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
    public partial class inventoryWindow : Form
    {
        bool btnEmployeeClicked = false;
        bool btnProductsClicked = false;
        bool btnSuppliersClicked = false;
        bool btnOrdersClicked = false;
        bool btnRecievedClicked = false;
        bool btnPerformanceClicked = false;

        //Username //Role
        private string varUsername;
        private string varRole; 

        public void buttonDefaultColors()
        {
            btnEmployees.ForeColor = Color.Gray;
            btnOrders.ForeColor = Color.Gray;
            btnProducts.ForeColor = Color.Gray;
            btnReceived.ForeColor = Color.Gray;
            btnSuppliers.ForeColor = Color.Gray;
            btnPerformanceText.ForeColor = Color.Gray;
            btnEmployeeClicked = false;
            btnProductsClicked = false;
            btnSuppliersClicked = false;
            btnOrdersClicked = false;
            btnRecievedClicked = false;
            btnPerformanceClicked = false;


            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button6.BackColor = Color.White;
            btnPerformance.BackColor = Color.White;
        }
        public inventoryWindow(string username, string role)
        {
            InitializeComponent();
            varUsername = username;
            varRole = role;
            
        }



        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnSuppliersClicked = true;
            btnSuppliers.ForeColor = Color.Green;
            button3.BackColor = Color.Green;
            if (!panelInventory.Controls.Contains(ucSuppliers.Instance))
            {
                panelInventory.Controls.Add(ucSuppliers.Instance);
                ucSuppliers.Instance.Dock = DockStyle.Fill;
                ucSuppliers.Instance.BringToFront();
            }
            else ucSuppliers.Instance.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnEmployeeClicked = true;
            btnEmployees.ForeColor = Color.Green;
            button2.BackColor = Color.Green;
            if (!panelInventory.Controls.Contains(ucEmployees.Instance))
            {
                panelInventory.Controls.Add(ucEmployees.Instance);
                ucEmployees.Instance.Dock = DockStyle.Fill;
                ucEmployees.Instance.BringToFront();

            }
            else ucEmployees.Instance.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnProductsClicked = true;
            btnProducts.ForeColor = Color.Green;
            button1.BackColor = Color.Green;
            if (!panelInventory.Controls.Contains(ucProducts.Instance))
            {
                panelInventory.Controls.Add(ucProducts.Instance);
                ucProducts.Instance.Dock = DockStyle.Fill;
                ucProducts.Instance.BringToFront();
            }
            else ucProducts.Instance.BringToFront();
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (btnEmployeeClicked == true)
                btnEmployees.ForeColor = Color.Green;
            else btnEmployees.ForeColor = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnOrdersClicked = true;
            btnOrders.ForeColor = Color.Green;
            button4.BackColor = Color.Green;

            if (!panelInventory.Controls.Contains(ucOrder.Instance))
            {
                panelInventory.Controls.Add(ucOrder.Instance);
                ucOrder.Instance.Dock = DockStyle.Fill;
                ucOrder.Instance.BringToFront();
            }
            else ucOrder.Instance.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnRecievedClicked = true;
            btnReceived.ForeColor = Color.Green;
            button6.BackColor = Color.Green;

            if (!panelInventory.Controls.Contains(ucRecieved.Instance))
            {
                panelInventory.Controls.Add(ucRecieved.Instance);
                ucRecieved.Instance.Dock = DockStyle.Fill;
                ucRecieved.Instance.BringToFront();
            }
            else ucRecieved.Instance.BringToFront();
        }


        private void btnSuppliers_MouseEnter(object sender, EventArgs e)
        {
            if (btnSuppliersClicked == true)
                btnSuppliers.ForeColor = Color.Green;
            else btnSuppliers.ForeColor = Color.Red;
        }

        private void btnSuppliers_MouseLeave(object sender, EventArgs e)
        {
            if (btnSuppliersClicked == true)
                btnSuppliers.ForeColor = Color.Green;
            else btnSuppliers.ForeColor = Color.Gray;
        }

        private void btnOrders_MouseEnter(object sender, EventArgs e)
        {
            if (btnOrdersClicked == true)
                btnOrders.ForeColor = Color.Green;
            else btnOrders.ForeColor = Color.Red;

        }

        private void btnOrders_MouseLeave(object sender, EventArgs e)
        {
            if (btnOrdersClicked == true)
                btnOrders.ForeColor = Color.Green;
            else btnOrders.ForeColor = Color.Gray;

        }

        private void btnReceived_MouseEnter(object sender, EventArgs e)
        {
            if (btnRecievedClicked == true)
                btnReceived.ForeColor = Color.Green;
            else btnReceived.ForeColor = Color.Red;

        }

        private void btnReceived_MouseLeave(object sender, EventArgs e)
        {
            if (btnRecievedClicked == true)
                btnReceived.ForeColor = Color.Green;
            else btnReceived.ForeColor = Color.Gray;
        }

        private void btnEmployees_MouseEnter(object sender, EventArgs e)
        {
            if (btnEmployeeClicked == true)
                btnEmployees.ForeColor = Color.Green;
            else btnEmployees.ForeColor = Color.Red;
        }

        private void btnProducts_MouseEnter(object sender, EventArgs e)
        {
            if (btnProductsClicked == true)
                btnProducts.ForeColor = Color.Green;
            else btnProducts.ForeColor = Color.Red;

        }

        private void btnProducts_MouseLeave(object sender, EventArgs e)
        {
            if (btnProductsClicked == true)
                btnProducts.ForeColor = Color.Green;
            else btnProducts.ForeColor = Color.Gray;
        }

        private void inventoryWindow_Load(object sender, EventArgs e)
        {
            ///
            /////
            //

            lblUsername.Text = varUsername;
            lblRole.Text = varRole;

            buttonDefaultColors();
            btnProductsClicked = true;
            btnProducts.ForeColor = Color.Green;
            button1.BackColor = Color.Green;

            if (!panelInventory.Controls.Contains(ucProducts.Instance))
            {
                panelInventory.Controls.Add(ucProducts.Instance);
                ucProducts.Instance.Dock = DockStyle.Fill;
                ucProducts.Instance.BringToFront();
            }
            else ucProducts.Instance.BringToFront();

            notificationStockToRecieve();
            notificationZeroStock();
            notificationReahingStock();
        }

        

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var invWin = new LoginWindow();
            
            invWin.Closed += (s, args) => this.Close();
            invWin.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            buttonDefaultColors();
            btnPerformanceClicked = true;
            btnPerformanceText.ForeColor = Color.Green;
            btnPerformance.BackColor = Color.Green;

            if (!panelInventory.Controls.Contains(Performance.Instance))
            {
                panelInventory.Controls.Add(Performance.Instance);
                Performance.Instance.Dock = DockStyle.Fill;
                Performance.Instance.BringToFront();
            }
            else Performance.Instance.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Leave(object sender, EventArgs e)
        {

        }

        private void button9_Enter(object sender, EventArgs e)
        {

        }

        private void btnPerformanceText_MouseEnter(object sender, EventArgs e)
        {
            if (btnPerformanceClicked == true)
                btnPerformanceText.ForeColor = Color.Green;
            else btnPerformanceText.ForeColor = Color.Red;

        }

        private void btnPerformanceText_MouseLeave(object sender, EventArgs e)
        {
            if (btnPerformanceClicked == true)
                btnPerformanceText.ForeColor = Color.Green;
            else btnPerformanceText.ForeColor = Color.Gray;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btnOrders.PerformClick();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNotification3_Click(object sender, EventArgs e)
        {
            btnOrders.PerformClick();
            ucOrder.Instance.chbStatus.Checked = true;
        }

        private void notificationStockToRecieve()
        {
            string rtn = "SELECT COUNT(ppq.`ppq_id`) FROM purchaseorder_product_quantitytable ppq JOIN purchaseordertable po on po.po_id=ppq.purchaseorderId WHERE po.dateExpected='"+DateTime.Today.ToString("yyyy-MM-dd")+"'";
            string variable = "";
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    variable=rdr[0].ToString();
                }


               
            }
            catch (Exception exb)
            {
                //MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();

            }
           // MessageBox.Show(variable);

            if (variable == "0")
            {
                btnNotification3.Hide();

            }
            else if (variable == "1")
            {
                btnNotification3.Show();
                btnNotification3.Text = variable + " Item is to recieve today";
            }

            else 
            {
                btnNotification3.Show();
                btnNotification3.Text = variable + " Items are to recieve today";
            }

        }

        private void notificationZeroStock()
        {
            string rtn = "SELECT COUNT(`proId`) FROM `producttable` WHERE `proStock`=0 AND `proStatus`=1";
            string variable = "";
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    variable = rdr[0].ToString();
                }



            }
            catch (Exception exb)
            {
                //MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();

            }
            // MessageBox.Show(variable);

            if (variable == "0")
            {
                btnNotification1.Hide();

            }
            else if (variable == "1")
            {
                btnNotification1.Show();
                btnNotification1.Text = variable + " Item is out of stock";
            }
            else  
            {
                btnNotification1.Show();
                btnNotification1.Text = variable + " Items are out of stock";
            }

        }

        private void notificationReahingStock()
        {
            string rtn = "SELECT COUNT(`proId`) FROM `producttable` WHERE `proStock` <= `proMinStock` AND `proStatus`=1 AND `proStock` > 0";
            string variable = "";
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    variable = rdr[0].ToString();
                }



            }
            catch (Exception exb)
            {
                //MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();

            }
            // MessageBox.Show(variable);

            if (variable == "0")
            {
                btnNotification2.Hide();

            }
            else if (variable == "1")
            {
                btnNotification2.Show();
                btnNotification2.Text = variable + " Item is reaching stock limits";
            }
            else
            {
                btnNotification2.Show();
                btnNotification2.Text = variable + " Items are reaching stock limits";
            }

        }

        private void btnNotification1_Click(object sender, EventArgs e)
        {
            btnProducts.PerformClick();
            ucProducts.Instance.chbStatus.Checked = true;
        }

        private void btnNotification2_Click(object sender, EventArgs e)
        {
            btnProducts.PerformClick();
            ucProducts.Instance.chbStockinRisk.Checked = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnNotification1.PerformClick();
            btnNotification2.PerformClick();
            btnNotification3.PerformClick();

        }
    }
}
