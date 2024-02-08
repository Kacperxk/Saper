using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void easyMode_Click(object sender, EventArgs e)
        {
            LevelEasy easyLevel = new LevelEasy();
            easyLevel.Show();
            this.Hide();
        }

    }
}
