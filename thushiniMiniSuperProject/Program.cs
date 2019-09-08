using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using thushiniMiniSuperProject.ReceiveProducts;
using thushiniMiniSuperProject.Reports;


namespace thushiniMiniSuperProject
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new inventoryWindow ("ropereraSL","Sales Man"));
            Application.Run(new LoginWindow());
           //Application.Run(new posWindow("ropereraSL","Sales Person","16"));
             //Application.Run(new invPurchaseOrder());
            //Application.Run(new RecievedProducts());
            //Application.Run(new Sales());
          // Application.Run(new invAddProd());
         // Application.Run(new Sales( ));
        }
    }
}
