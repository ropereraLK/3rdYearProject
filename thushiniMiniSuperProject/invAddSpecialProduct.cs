using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thushiniMiniSuperProject
{
    public partial class invAddSpecialProduct : Form
    {
        public invAddSpecialProduct()
        {
            InitializeComponent();
        }

        private void invAddSpecialProduct_Load(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Today.ToLongDateString();
            
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
