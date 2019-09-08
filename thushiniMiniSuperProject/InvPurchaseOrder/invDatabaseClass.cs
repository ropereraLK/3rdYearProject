using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace thushiniMiniSuperProject.InvPurchaseOrder
{
    public class invDatabaseClass
    {
        private static string connectionString = "Server=127.0.0.1;Database=thushiniminisuper;Uid=root;Pwd=;";
        MySqlConnection c = new MySqlConnection(connectionString);

        public void databaseFunction(String inputQuery)
        {
            try
            {
                c.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(inputQuery, c);


            }

            catch
            {

            }
        }


        /* try
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

 }*/
    }
}
