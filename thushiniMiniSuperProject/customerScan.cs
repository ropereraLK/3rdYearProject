using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using MySql.Data.MySqlClient;

namespace thushiniMiniSuperProject
{
    public partial class customerScan : Form
    {
        float redemablepoints;
        bool allowSubmit = false;
        string billNo;
        string dateToday;
        string CustomerId;
        float total;
        string fname;
        string lname;
        float pastLoyalPoints;
        float earnedPoints;

        //
        float deductedPoints;

        private giftVTransition1 _state;

        public customerScan(string fname,string lname,float pastLoyalPoints, string billNo, string dateToday, string CustomerId, float total, giftVTransition1 state)
        {
            InitializeComponent();
            //
            _state = state;
            

            this.billNo = billNo;
            this.dateToday = dateToday;
            this.CustomerId = CustomerId;
            this.total = total;
            this.fname = fname;
            this.lname = lname;
            this.pastLoyalPoints = pastLoyalPoints;
        
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _state.Text = txtDeductPoints.Text;
            _state.CaretPosition = txtDeductPoints.SelectionStart;
            base.OnClosing(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDeductPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (Convert.ToSingle(txtDeductPoints.Text) > pastLoyalPoints)
                {
                    txtDeductPoints.ForeColor = Color.Red;
                }
                else
                {
                    txtDeductPoints.ForeColor = Color.Green;
                }
            }
            catch
            {

            }
        }

        private void txtDeductPoints_Enter(object sender, EventArgs e)
        {
            txtDeductPoints.Clear();
        }

        private void customerScan_Load(object sender, EventArgs e)
        {
            try
            {
                redemablepoints = Convert.ToSingle(txtReedemablePoints.Text);
            }
            catch
            {

            }

            txtCardNo.Text = CustomerId;
            txtFirstName.Text = fname;
            txtLastName.Text = lname;
            txtReedemablePoints.Text = pastLoyalPoints.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);
            earnedPoints = (total / 100);
            txtPointsEarned.Text = earnedPoints.ToString("##,##,##,###.00", CultureInfo.InvariantCulture);


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (earnedPoints <= 0 )
            {
                allowSubmit = false;
            }
            else if (total <= deductedPoints)
            {
                allowSubmit = false;
                MessageBox.Show("Deducted points should be equal or less than the total.");

            }
            else
            {
                allowSubmit = true;
            }

            if (allowSubmit == true)
            {
                string query1 = "UPDATE `customertable` SET `cusLoyaltyPoints`= (`cusLoyaltyPoints` -'"+ (deductedPoints+ earnedPoints) +"') WHERE `cusId` = '"+CustomerId+"'";

                dbString dbc = new dbString();
                string conString = dbc.connectionSring;
                MySqlConnection con = new MySqlConnection(conString);
                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query1;
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //MessageBox.Show("Hi");
                }
                finally
                {
                    this.Close();
                }
            }
        }
    }
}
