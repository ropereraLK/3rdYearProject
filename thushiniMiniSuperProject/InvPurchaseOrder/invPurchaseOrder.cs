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
using RDotNet;


namespace thushiniMiniSuperProject
{
    public partial class invPurchaseOrder : Form
    {

        public invPurchaseOrder()
        {
            InitializeComponent();
            btnOrder.Hide();
        }


        private void invPurchaseOrder_Load(object sender, EventArgs e)
        {
            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                string query = "SELECT `supId`,`SupName` FROM `suppliertable` WHERE `supStatus` = 1";
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                dataRow.ItemArray = new object[] { 0, "--Select--" };
                cmbSupplier.DataSource = dataTable;
                cmbSupplier.DisplayMember = "SupName";
                cmbSupplier.ValueMember = "supId";


            }
            catch
            {
                MessageBox.Show("Erro r");
            }
            finally
            {
                con.Close();
            }

            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Product Name";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Name = "Max Price";
            dataGridView1.Columns[3].Name = "Min Price";
            dataGridView1.Columns[4].Name = "Current Stock";
            dataGridView1.Columns[5].Name = "Forecasted Order";
            dataGridView1.Columns[6].Name = "Order Value";
            dataGridView1.Columns[7].Name = "Total";

            dataGridView1.Columns[7].MinimumWidth = 184;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = false; // Can be Edited
            dataGridView1.Columns[6].FillWeight = 30;



        }



        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPO_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.Text == "--Select--")
            {
                MessageBox.Show("Please select a supplier");
            }
            else
            {
                cmbSupplier.Enabled = false;
                try
                {
                    generationOfPO();
                }
                catch
                {

                }
                try
                {
                    CalculateOtherData();
                    
                }
                catch
                {

                }
                finally
                {

                }

                btnPO.Hide();
                btnOrder.Show();
                //this.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void generationOfPO()
        {
            List<InvPurchaseOrder.NodePO> productList = new List<InvPurchaseOrder.NodePO>();

            dbString db = new dbString();
            string connString = db.connectionSring;
            int varX = 0;


            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                //AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-30).ToString("yyyy - MM - dd") + "' 
                conn.Open();
                string rtn = @"SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock, producttable.proReplacementTime, producttable.proStock, SUM(sales_producttable.productQty) AS forecast FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId WHERE producttable.proStatus = 1 and sales_producttable.salesDate < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-28).ToString("yyyy-MM-dd") + "' AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = '"+cmbSupplier.Text+"' LIMIT 1) AND producttable.proStatus = 1 GROUP BY producttable.proId ASC";

                MySqlCommand cmd = new MySqlCommand(rtn, conn);
              
                MySqlDataReader rdr = cmd.ExecuteReader();

                
                while (rdr.Read())
                {
                    productList.Add(new InvPurchaseOrder.NodePO(Convert.ToInt32(rdr[0]),rdr[1].ToString(), Convert.ToSingle(rdr[2]), Convert.ToSingle(rdr[3]), Convert.ToSingle(rdr[4]), Convert.ToSingle(rdr[6]), Convert.ToInt32(rdr[5]), Convert.ToSingle(rdr[7])));
                }

            }
            catch(Exception exb)
            {
                MessageBox.Show("" +   exb);

            }
            finally
            {
                conn.Close();
                varX = 0;
            }

            ////
            try
            {
                //AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-30).ToString("yyyy - MM - dd") + "' 
                conn.Open();
               // string rtn2 = @"";// SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock, producttable.proReplacementTime, producttable.proStock, SUM(sales_producttable.productQty) AS forecast FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId WHERE producttable.proStatus = 1 and sales_producttable.salesDate < '" + DateTime.Now.ToString("yyyy-MM-dd") + "' AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-28).ToString("yyyy-MM-dd") + "' AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = @supplierName LIMIT 1) AND producttable.proStatus = 1 GROUP BY producttable.proId ASC";
                string rtn2 = @"SELECT producttable.proId, producttable.proName, producttable.proMaxPrice, producttable.proMinPrice, producttable.proMinStock,
 producttable.proReplacementTime, producttable.proStock FROM producttable JOIN sales_producttable ON producttable.proId = sales_producttable.productId 
 WHERE producttable.proStatus = 1  AND producttable.proSupplierId = (SELECT `supId` FROM `suppliertable` WHERE `SupName` = '"+cmbSupplier.Text+"' LIMIT 1) GROUP BY producttable.proId ASC";
 
                MySqlCommand cmd = new MySqlCommand(rtn2, conn);             
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                { bool addItem = true;
                    foreach (var node in productList)
                    {
                        if (node.getProId().ToString() == rdr[0].ToString())
                        {
                            addItem = false;
                        }
                    }
                    if (addItem == true)
                    {
                        
                        productList.Add(new InvPurchaseOrder.NodePO(Convert.ToInt32(rdr[0]), rdr[1].ToString(), Convert.ToSingle(rdr[2]), Convert.ToSingle(rdr[3]), Convert.ToSingle(rdr[4]), Convert.ToSingle(rdr[6]), Convert.ToInt32(rdr[5]), 0));
                        addItem = false;
                       }
                }

            }
            catch (Exception exb)
            {
                MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();
                varX = 0;
            }
            ///////////////////////////
            
            try
            {
                conn.Open();
                string rtn5 = @"SELECT `proId`, `proName`,   `proMaxPrice`, `proMinPrice`,   `proMinStock`, `proStock`, `proReplacementTime`FROM `producttable` WHERE `proSupplierId`= (SELECT `supId` FROM `suppliertable` WHERE `SupName` = '"+cmbSupplier.Text+"' LIMIT 1) AND `proStatus` = 1";

                MySqlCommand cmd = new MySqlCommand(rtn5, conn);               
                MySqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    bool addItem = true;
                    foreach (var varNode in productList)
                    {
                        if (varNode.getProId().ToString() == rdr[0].ToString())
                        {
                            addItem = false;
                        }
                    }
                    if (addItem == true)
                    {
                       
                        productList.Add(new InvPurchaseOrder.NodePO(Convert.ToInt32(rdr[0]), rdr[1].ToString(), Convert.ToSingle(rdr[3]), Convert.ToSingle(rdr[2]), Convert.ToSingle(rdr[4]), Convert.ToSingle(rdr[5]), Convert.ToInt32(rdr[6]), 0));
                        addItem = false;
                    }
                    

                }

            }
            catch (Exception exb)
            {
                MessageBox.Show("" + exb);

            }
            finally
            {
                conn.Close();
                varX = 0;
            }
            
            ///////////////////////////
            /*

            foreach (var varNode in productList)
            {
                float pastSales = 0;
                pastSales = varNode.getSalesPastSevenDays();
                int forecast = Convert.ToInt32(pastSales);



                string[] row = new string[] { varNode.getProId().ToString(), varNode.getProName(), varNode.getMinPrice().ToString(), varNode.getMaxPrice().ToString(), varNode.getCurrentstock().ToString(), forecast.ToString(), forecast.ToString(), (forecast * varNode.getMinPrice()).ToString() };
                dataGridView1.Rows.Add(row);


            }

    */



            ////////////////////////*
            List<string> stringProdId = new List<string>();

            try
            {
                //AND sales_producttable.salesDate > '" + DateTime.Now.AddDays(-30).ToString("yyyy - MM - dd") + "' 
                conn.Open();
                string rtn1 = @"SELECT DISTINCT ppq.`product_id` FROM `purchaseorder_product_quantitytable` ppq JOIN purchaseordertable po ON ppq.`purchaseorderId`= po.po_id JOIN suppliertable sup ON po.supplier_id=sup.supId WHERE po.`status`=0 AND sup.supId=(SELECT `supId` FROM suppliertable WHERE `SupName` = '" + cmbSupplier.Text +"' )";

                MySqlCommand cmd = new MySqlCommand(rtn1, conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                

                MySqlDataReader rdr = cmd.ExecuteReader();

               while( rdr.Read())
                {
                    stringProdId.Add(rdr[0].ToString());
                   // MessageBox.Show(rdr[0].ToString());

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
            /*
           
            //MessageBox.Show(stringProdId.Count.ToString());
            
            for(int x= 0; x<stringProdId.Count ; x++)
            {
                MessageBox.Show(stringProdId[x+1]);
               
                for (int ii = 0; ii < 10; ii++) {
                    if (stringProdId[x+1] == dataGridView1.Rows[ii].Cells[0].Value.ToString())
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[ii]);
                    }
                    else
                    {
                        

                    }
                }
                MessageBox.Show(stringProdId.Count.ToString()+"hiii");
            }

            MessageBox.Show(stringProdId.Count.ToString());

    */



            foreach (var varNode in productList)
            {
                float pastSales = 0;
                pastSales = varNode.getSalesPastSevenDays();
                int forecast = Convert.ToInt32(pastSales);

                bool add = false;
                foreach (string x in stringProdId) {
                   if ( x == varNode.getProId().ToString())
                    {
                        add = true;
                    }
                }

                if (add != true)
                {
                   // varNode.getSalesPastSevenDays
                    string[] row = new string[] { varNode.getProId().ToString(), varNode.getProName(), varNode.getMinPrice().ToString(), varNode.getMaxPrice().ToString(), varNode.getCurrentstock().ToString(), forecast.ToString(), forecast.ToString(), (forecast * varNode.getMinPrice()).ToString() };
                    dataGridView1.Rows.Add(row);
                    add = false;
                }

            }
            ///
            /*
            for (int x = 0; x < stringProdId.Count; x++)
            {
               

                for (int ii = 0; ii < 10; ii++)
                {




                    if (stringProdId[x + 1] == dataGridView1.Rows[ii].Cells[0].Value.ToString())
                    {
                        
                    }
                    else
                    {


                    }
                }
                MessageBox.Show(stringProdId.Count.ToString() + "hiii");
            }
            */


        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int counter;

            // Iterate through the rows, skipping the Starting Balance row.
            for (counter = 0; counter < (dataGridView1.Rows.Count ); counter++)
            {
                try {
                    if ((Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value)) < 0.0 )
                    {
                            dataGridView1.Rows[counter].Cells[6].Value = "0";
                            dataGridView1.Rows[counter].Cells[7].Value = "0.00";
                    }
                }
                catch {

                }

                try
                {
                    //Placed Order Value
                    dataGridView1.Rows[counter].Cells[7].Value = Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value) * Convert.ToSingle(dataGridView1.Rows[counter].Cells[2].Value);
                }
                catch
                {
                    dataGridView1.Rows[counter].Cells[6].Value = "0";
                    dataGridView1.Rows[counter].Cells[7].Value = "0.00";


                }


            }

            try {
                CalculateOtherData();
            }
            catch
            {

            }

        }

       private void CalculateOtherData() //always use try catch
        {
            float units = 0;
            int products =0;
            float expectedIncome =0;
            float ordervalue = 0;
           

            int counter;
            for (counter = 0; counter < (dataGridView1.Rows.Count); counter++)
            {
                //products
                if(Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value)!= 0)
                {
                    products ++;
                }

                //units
                units += Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value);

                //Order Value
                try
                {
                    ordervalue += Convert.ToSingle(dataGridView1.Rows[counter].Cells[7].Value);
                }
                catch
                {

                }

                //Expected Income
                try
                {
                    expectedIncome += (Convert.ToSingle(dataGridView1.Rows[counter].Cells[3].Value) * Convert.ToSingle(dataGridView1.Rows[counter].Cells[6].Value));
                }
                catch
                {

                }

               
               

            }

            txtUnits.Text = units.ToString();
            txtProducts.Text = products.ToString();
            txtOrdervalue.Text = ordervalue.ToString();
            txtExpectedIncome.Text = expectedIncome.ToString();
            txtGrossProfit.Text= (-expectedIncome+ordervalue).ToString();



        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // " + dateTimePicker1.Value.ToString("yyyy - MM - dd") + "
            
            string QueryString = "INSERT INTO `purchaseordertable` ( `supplier_id`, `datePlaced`, `dateExpected`, `status`) VALUES ( (SELECT `supId` FROM `suppliertable` WHERE `SupName` = '"+ cmbSupplier.Text.ToString() +"'  LIMIT 1), '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '2015-10-08', '0');";

            dbString dbc = new dbString();
            string conString = dbc.connectionSring;
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();

                MySqlCommand comm = con.CreateCommand(); 
                comm.CommandText = QueryString;
                comm.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

            ///////////////////////////////////////////

            int purchaseOrderId = 0 ; //

            try
            {
                
                con.Open();

                string sql = "SELECT `po_id` FROM `purchaseordertable` GROUP BY  `po_id` DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                      purchaseOrderId = Convert.ToInt32(result);
                   
                }

            }
            catch (Exception ex)
            {
                 
            }
            finally
            {
                con.Close();
            }
            /////////////////////////////

            string queryInsert = "INSERT INTO `purchaseorder_product_quantitytable`(`purchaseorderId`, `product_id`, `product_qty`) VALUES ";

            int i = 0;
 
            for (i = 0; i < dataGridView1.RowCount -2 ; i++)
            {
                int prodId = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                float prodQty = Convert.ToSingle(dataGridView1.Rows[i].Cells[6].Value);

                string var1 = "("+ purchaseOrderId.ToString() + "," + prodId.ToString() + "," + prodQty.ToString() + "),";
                queryInsert += var1;

            }
            
            int prodId1 = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            float prodQty1 = Convert.ToSingle(dataGridView1.Rows[i].Cells[6].Value);

            string var2 = "(" + purchaseOrderId.ToString() + "," + prodId1.ToString() + "," + prodQty1.ToString() + ")";
            queryInsert += var2;

            i = 0;


            try
            {
                con.Open();
                
                MySqlCommand comm = con.CreateCommand();
                comm.CommandText = queryInsert;
                comm.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                con.Close();
            }

            purchaseOrderId = 0;



            MessageBox.Show("Purchase order placed successfully");
            this.Close();


        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
