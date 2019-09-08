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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        public object ChartAreas { get; internal set; }
    }
}
