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
    public partial class invAddProd : Form
    {
        bool name = false;
        bool category = false;
        bool subC = false;
        bool minPrice = false;
        bool maxPrice = false;
        bool discount = false;
        bool supplier = false;
        bool barcode = false;
        bool unit = false;
        bool stock = false;
        bool safetyStock = false;
        bool replaceTime = false;
        bool percentage = false;
        //
        float maxPriceValue;
        float disPriceValue;
        float percentageValue;
        float minPriceValue;


        int supplierId = 0;

       


        public invAddProd()
        {
            InitializeComponent();
        }

       

        private void invAddProducts_Load(object sender, EventArgs e)
        {
            onlyAddProducts();

            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT `categoryId`, `categoryName` FROM `productcategory` WHERE 1";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow();
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(dataRow, 0);
                cmbCategory.DataSource = dataTable;
                cmbCategory.DisplayMember = "categoryName";
               cmbCategory.ValueMember = "categoryId";

                //
                string query1 = "SELECT `supId`, `SupName` FROM `suppliertable` WHERE `supStatus` = 1";
                MySqlDataAdapter mySqlDataAdapter1 = new MySqlDataAdapter(query1, con);
                DataTable dataTable1 = new DataTable();
                mySqlDataAdapter1.Fill(dataTable1);

                DataRow dataRow1 = dataTable1.NewRow();
                dataRow1.ItemArray = new object[] { 0, "--Select--" };
                dataTable1.Rows.InsertAt(dataRow1, 0);
                txtSupplier.DataSource = dataTable1;
                txtSupplier.DisplayMember = "SupName";
                txtSupplier.ValueMember = "supId";

            }
            catch
            {
               // MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }
          

        }

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbCategory.Visible = false;
            category = true;
            
            if ((cmbCategory.Text == "Vegetables")|| (cmbCategory.Text == "Fruits")|| (cmbCategory.Text == "Fish"))
            {
                cmbSubCategory.Enabled = false;
                txtUnit.Text = "Kg";
                txtDiscountPrice.Enabled = false;
                discount = true;
                txtDiscountPercentage.Enabled = false;
                //No DiscPercent
                txtDiscountPercentage.Text = "0";
                cmbSubCategory.Text = "";
                
                subC = true;
                unit = true;


            }
            else
            {
                cmbSubCategory.Enabled = true;
                subC = false;
                unit = false;
                discount = false;
            }

            cmbSubCategory.Text = "--Select--";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            int supplierId = 9;
            //Send to Database
            dbString db = new dbString();
            string connString = db.connectionSring;
            MySqlConnection conn = new MySqlConnection(connString);
            if (name & category & subC & minPrice & maxPrice & discount & supplier & barcode  & stock & safetyStock )
            {
                try
                {
                    conn.Open();
                    string rtn = @"SELECT `supId` FROM `suppliertable` WHERE `SupName` = '" + txtSupplier.Text + "' LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(rtn, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        supplierId = Convert.ToInt32(rdr[0]);
                    }

                }
                catch (Exception exb)
                {
                    MessageBox.Show("" + exb);

                }
                finally
                {
                    conn.Close();
                    
                }

                try
                {

                    conn.Open();
                    MySqlCommand comm = conn.CreateCommand();
                    comm.CommandText = @"INSERT INTO `producttable` ( `proCategory`, `proSubCategory`, `proBarCode`, `proUnit`, `proSupplierId`, `proMaxPrice`, `proMinPrice`, `proDiscountPrice`, `proStock`, `proReplacementTime`, `proStatus`, `proName`, `proMinStock`) VALUES" +
                        " ('"+cmbCategory.Text+ "'  , '" + cmbSubCategory.Text + "' , '" + txtBarcode.Text + "', '" + txtUnit.Text + "', "+supplierId+" , '" + txtMaxPrice.Text + "',  '" + txtMinPrice.Text + "', '" + txtDiscountPrice.Text + "', '" + txtInitialStock.Text + "', '" + txtReplacementTime.Text + "', '1', '" + txtName.Text + "', '" + txtSafetyStock.Text + "')";
                    
                   
                    
                    comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some Exception has Occured Please try again.");

                }
                finally
                {
                    conn.Close();
                    this.Close();
                }


            }
            else
            {
                if (name==false)
                {
                    pbName.Visible = true;
                }
                if (category == false)
                {
                    pbCategory.Visible = true;
                }
                if ( subC== false)
                {
                   pbSubC.Visible = true;
                }
                if (minPrice == false)
                {
                    pbMinPrice.Visible = true;
                }
                if (maxPrice == false)
                {
                    pbMaxPrice.Visible = true;
                }
                if (discount == false)
                {
                    pbDisc.Visible = true;
                }
                if (supplier == false)
                {
                   pbSupplier .Visible = true;
                }
                if (barcode == false)
                {
                   pbBarcode .Visible = true;
                }
               
                if ( stock== false)
                {
                    pbStock.Visible = true;
                }
                if ( safetyStock== false)
                {
                    pbSafetyS.Visible = true;
                }
                if ( replaceTime== false)
                {
                    pbReplace.Visible = true;
                }


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onlyAddProducts()
        {
            txtStatus.Visible = false;
            lblStatus.Visible = false;
            lblStatusDes.Visible = false;
        }

        private void txtDiscountPrice_TextChanged(object sender, EventArgs e)
        {
            pbDisc.Visible = false;
            discount = false;

        }

        private void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
        {
            pbPerc.Visible = false;
            percentage = false;

        }
        float maxPer;
        private void txtDiscountPercentage_Leave(object sender, EventArgs e)
        {
           

            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtDiscountPercentage.Text).Success)
            {
                try
                {
                    percentageValue = float.Parse(txtDiscountPercentage.Text);
                }
                catch
                {
                    MessageBox.Show("Exception occured in discount percentaeg. Please re-enter");
                    txtDiscountPercentage.Clear();
                }
                
                try
                {
                     maxPer = (maxPriceValue - minPriceValue) / maxPriceValue * 100;
                }
                catch
                {
                    MessageBox.Show("Enter Valied values for receiving price and selling price");
                }

                if (percentageValue >= 0 && percentageValue <= maxPer )
                {
                    pbPerc.Visible = false;
                    percentage = true;
                    disPriceValue = maxPriceValue - (maxPriceValue * percentageValue / 100);
                    txtDiscountPrice.Text = disPriceValue.ToString();
                }
                else
                {
                    pbPerc.Visible = true;
                    percentage = false;
                    MessageBox.Show("Please recheck the discount percentage");

                }
            }
            else
            {
                txtDiscountPercentage.Clear();
                pbPerc.Visible = true;
                percentage = false;
            }
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

        private void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            subC = true;
            pbSubC.Visible = false;
        }

        private void cmbCategory_Leave(object sender, EventArgs e)
        {
            if((cmbCategory.Text=="-Select-") || (cmbCategory.Text == ""))
            {
                category = false;
                pbCategory.Visible = true;
                
            }
            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                string query = "SELECT `subcategoryId`, `subcategoryname` FROM `productsubcategory` WHERE `maincategoryId` = (SELECT `categoryId` FROM `productcategory` WHERE `categoryName` = '"+ cmbCategory.Text +"')";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow()
                    ;
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                dataTable.Rows.InsertAt(dataRow, 0);
                cmbSubCategory.DataSource = dataTable;
                cmbSubCategory.DisplayMember = "subcategoryname";
                cmbSubCategory.ValueMember = "subcategoryId";

            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

        }

        private void cmbSubCategory_Leave(object sender, EventArgs e)
        {
            if ((cmbSubCategory.Text == "-Select-") || (cmbSubCategory.Text == ""))
            {
                subC = false;
                pbSubC.Visible = true;
            }
            else
            {
                subC = true;
                pbSubC.Visible = false;
            }

        }

        private void txtSupplier_Leave(object sender, EventArgs e)
        {
            if ((txtSupplier.Text == "-Select-") || (txtSupplier.Text == ""))
            {
                supplier = false;
                pbSupplier.Visible = true;
            }
            /*else
            {
                supplier = true;
                pbSupplier.Visible = false;
            }*/

        }

        private void txtSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            pbSupplier.Visible = false;
            supplier = true;

            
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            pbBarcode.Visible = false;
            barcode = false;
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex("^[0-9]{13}$");

            if (validator.Match(txtBarcode.Text).Success)
            {
                barcode = true;
            }
            else if(txtBarcode.Text == null)
            {
                barcode = true;
                //MessageBox
            }
            else
            {
                barcode = false;
                pbBarcode.Visible = true;
            }
        }

        private void txtSafetyStock_TextChanged(object sender, EventArgs e)
        {
            pbSafetyS.Visible = false;
            safetyStock = false;

        }

        private void txtSafetyStock_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtSafetyStock.Text).Success)
            {
                pbSafetyS.Visible = false;
                safetyStock = true;
            }
            else
            {
                pbSafetyS.Visible = true;
                safetyStock = false;
            }
        }

        private void txtInitialStock_TextChanged(object sender, EventArgs e)
        {
            pbStock.Visible = false;
            stock = false;

        }

        private void txtInitialStock_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtInitialStock.Text).Success)
            {
                pbStock.Visible = false;
                stock = true;
            }
            else
            {
                pbStock.Visible = true;
                stock = false;
            }
        }

        private void txtMinPrice_TextChanged(object sender, EventArgs e)
        {
            pbMinPrice.Visible = false;
            minPrice = false;
        }

        private void txtMinPrice_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtMinPrice.Text).Success)
            {
                pbMinPrice.Visible = false;
                minPrice = true;
                try
                {
                     minPriceValue = float.Parse(txtMinPrice.Text);
                   
                }
                catch
                {
                    MessageBox.Show("Exception occured in receiving price. Please re-enter");
                    txtMinPrice.Clear();
                }
            }
            else
            {
                pbMinPrice.Visible = true;
                minPrice = false;
            }

        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            pbMaxPrice.Visible = false;
            maxPrice = false;

            

        }

        private void txtMaxPrice_Leave(object sender, EventArgs e)
        {

            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtMaxPrice.Text).Success)
            {
                try
                {
                     maxPriceValue = float.Parse(txtMaxPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Exception occured in Selling price. Please re-enter");
                    txtMaxPrice.Clear();
                }

                if (maxPriceValue >= minPriceValue) {
                    pbMaxPrice.Visible = false;
                    maxPrice = true;
                   
                        discount = true;
                        pbDisc.Visible = false;
                        txtDiscountPrice.Text = txtMaxPrice.Text;
                        txtDiscountPercentage.Text = "0";
                        percentage = true;
                        pbPerc.Visible = false;

                    
                }
                else
                {
                    MessageBox.Show("Selling should be greater than or equal to receiving price");
                    pbMaxPrice.Visible = true;
                    maxPrice = false;
                }

            }
            else
            {
                pbMaxPrice.Visible = true;
                maxPrice = false;
                
            }



        }

        private void txtDiscountPrice_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtDiscountPrice.Text).Success)
            {
                try
                {
                    disPriceValue = float.Parse(txtDiscountPrice.Text);
                }
                catch
                {
                    MessageBox.Show("Exception occured in discounted price. Please re-enter");
                    txtDiscountPrice.Clear();
                }

                if (maxPriceValue>= disPriceValue && minPriceValue<=disPriceValue)
                {
                    pbDisc.Visible = false;
                    discount = true;
                    try {
                        percentageValue = (maxPriceValue - disPriceValue) / maxPriceValue * 100;
                        txtDiscountPercentage.Text = percentageValue.ToString();
                        pbPerc.Visible = false;
                        percentage = true;
                  }
                    catch
                    {
                        MessageBox.Show("One or More required entities are empty");
                    }
                   

                }
                else
                {
                    MessageBox.Show("Discounted price should be a value between Selling price and Receiving price");
                    pbDisc.Visible = true;
                    discount = false;
                    txtDiscountPercentage.Clear();
                    txtDiscountPrice.Clear();

                }

            }
            else
            {
                pbDisc.Visible = true;
                discount = false;
                txtDiscountPercentage.Clear();
                txtDiscountPrice.Clear();
            }

        }

        private void txtReplacementTime_TextChanged(object sender, EventArgs e)
        {
            pbReplace.Visible = false;
            replaceTime = false;
        }

        private void txtReplacementTime_Leave(object sender, EventArgs e)
        {
            Regex validator = new Regex(@"^(\d*\.)?\d+$");

            if (validator.Match(txtReplacementTime.Text).Success)
            {
                pbReplace.Visible = false;
                replaceTime = true;
            }
            else
            {
                pbReplace.Visible = true;
                replaceTime = false;
            }
        }

        private void txtDiscountPrice_Enter(object sender, EventArgs e)
        {
            if (txtMinPrice.Text == null)
            {
                txtMinPrice.Focus();
            }
            if (txtMaxPrice.Text == null)
            {
                txtMaxPrice.Focus();
            }
        }

        private void txtDiscountPercentage_Enter(object sender, EventArgs e)
        {
            if (txtMinPrice.Text == null)
            {
                txtMinPrice.Focus();
            }
            if (txtMaxPrice.Text == null)
            {
                txtMaxPrice.Focus();
            }
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
