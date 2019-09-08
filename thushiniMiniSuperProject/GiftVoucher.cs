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
    public partial class GiftVoucher : Form
    {
        DateTime x;//Exp date
        private giftVTransition1 _state;
        string barC="";
        public GiftVoucher(string barcode, giftVTransition1 state)
        {
            InitializeComponent();
           barC = barcode;
            _state = state;
          
        }

        private void GiftVoucher_Load(object sender, EventArgs e)
        {
            
            txtTo.Enabled = true;
            txtFrom.Enabled = true;
            txtVoucher.Enabled = false;
            txtVoucher.Text = barC;

            var random = new Random(System.DateTime.Now.Millisecond);
            txtPIN.Text = random.Next(1, 500000).ToString();

            Regex validator500 = new Regex("^['V'][0-9]{10}[1]$");

            if (validator500.Match(barC).Success)
            {//
                txtValue.Text = "500.00";

            }
            Regex validator1000 = new Regex("^['V'][0-9]{10}[2]$");

             if (validator1000.Match(barC).Success)
            {//
                txtValue.Text = "1000.00";
            }

            Regex validator2000 = new Regex("^['V'][0-9]{10}[3]$");

            if (validator2000.Match(barC).Success)
            {//
                txtValue.Text = "2000.00";
            }

            Regex validator5000 = new Regex("^['V'][0-9]{10}[4]$");
            if (validator5000.Match(barC).Success)
            {//
                txtValue.Text = "5000.00";
            }
  

            txtDate.Text = DateTime.Now.Date.ToLongDateString();
             x = DateTime.Now.AddDays(90);
            txtExpiary.Text = x.ToLongDateString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void txtVoucher_TextChanged(object sender, EventArgs e)
        {
           
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
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = "INSERT INTO `giftvouchertable`(`vBarcode`, `vPIN`, `vExpDate`, `vIssuedDate`, `vTo`, `vFrom`, `status`, `value`)VALUES ('"+txtVoucher.Text+ "','"+txtPIN.Text+ "','"+ x.ToString("yyyy-MM-dd") + "','"+ DateTime.Now.ToString("yyyy-MM-dd") + "','"+txtTo.Text+ "','"+txtFrom.Text+ "','1','"+txtValue.Text+"' )";               
                comm.ExecuteNonQuery();
                MessageBox.Show("Gift voucher processed successfully");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Exception Occured in the process");
            }
            finally
            {
                conn.Close();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (txtValue.Text != "")
            {
                _state.Text = txtValue.Text;
                _state.CaretPosition = txtValue.SelectionStart;
                base.OnClosing(e);
            }
        }


    }
}
