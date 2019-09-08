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
    public partial class GiftVoucherPay : Form
    {
        float vValue = 0;
        private giftVTransition1 _state;
        private string _barcode;
        public GiftVoucherPay(string barcode ,giftVTransition1 state)
        {
            InitializeComponent();
            _state = state;
            _barcode = barcode;

        }

        private void lblValiedTill_Click(object sender, EventArgs e)
        {

        }

        private void GiftVoucherPay_Load(object sender, EventArgs e)
        {
            //  txtDate.Text = DateTime.Today.ToLongDateString();
            txtVoucher.Text = _barcode.ToString();

        }

        private void txtDate_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtVoucher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPIN_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            _state.Text =txtValue.Text;
           _state.CaretPosition = txtValue.SelectionStart;
            base.OnClosing(e);
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            // Local Variables

            float vValue = 0;
            
            string issuedDate = "";
            string expiaryDate = "";
            string to = "";
            string from = "";

            try
            {
                conn.Open();
                string Query = "SELECT `vExpDate`, `vIssuedDate`, `vTo`, `vFrom`,   `value` FROM `giftvouchertable` WHERE `vBarcode`= '" + txtVoucher.Text + "' AND `vPIN` = '" + txtPIN.Text + "' AND `status` = 1 ";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                while (rdr.Read())
                {
                    expiaryDate = rdr[0].ToString();
                    vValue = Convert.ToSingle(rdr[4]);
                    issuedDate = rdr[1].ToString();
                    to = rdr[2].ToString();
                    from = rdr[3].ToString();
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

            if (vValue != 0)
            {
                txtValue.Text = vValue.ToString();
                txtExpiary.Text = expiaryDate.ToString();
                txtDate.Text = issuedDate.ToString();
                txtTo.Text = to.ToString();
                txtFrom.Text = from.ToString();
                vValue = 0;
            }
            else { MessageBox.Show("Error occured"); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                string Query = "UPDATE `giftvouchertable` SET `status`= 2 WHERE `vBarcode` = '"+ _barcode +"'";
                MySqlCommand mySqlCommand = new MySqlCommand(Query, conn);
                mySqlCommand.ExecuteNonQuery();
                  
            }
            catch
            {
                MessageBox.Show("Error in connecting with the Database");
            }
            finally
            {
                conn.Close();
                this.Close();
            }
            
        }
    }
}
