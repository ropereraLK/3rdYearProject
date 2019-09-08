using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thushiniMiniSuperProject
{
   public class dbString
    {
        public  String connectionSring = "Server=127.0.0.1;Database=thushiniminisuper;Uid=root;Pwd=;";  
        
        private String connectionString = "Server=127.0.0.1;Database=thushiniminisuper;Uid=root;Pwd=;";

        public String getConnectionString()
        {
            return connectionString;
        }
    }
}
