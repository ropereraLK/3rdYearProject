using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thushiniMiniSuperProject.InvPurchaseOrder
{
    public class Orders
    {
        public int OrderId { get; set; }
        public String Name { get; set; }
        [Display(Name="Contact Name")]
        public String ContactName { get; set; }
    }
}
