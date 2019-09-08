using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrinterUtility;
using System.IO;

namespace thushiniMiniSuperProject
{
    public partial class print1 : Form
    {
        public print1()
        {
            InitializeComponent();
        }

        private void print1_Load(object sender, EventArgs e)
        {
            PrinterUtility.EscPosEpsonCommands.EscPosEpson EscPosEpson = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            //var BytesValue ;
            
        }
    }
}
