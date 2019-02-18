using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheRealUno
{
    public partial class FrmActionCard : Form
    {
        public string selectedColor { get; set; }
        public FrmActionCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void COLOR_RED_Click(object sender, EventArgs e)
        {
             selectedColor = this.COLOR_RED.Text;
        }

        private void COLOR_GREEN_Click(object sender, EventArgs e)
        {
             selectedColor = this.COLOR_GREEN.Text;

        }

        private void COLOR_BLUE_Click(object sender, EventArgs e)
        {
             selectedColor = this.COLOR_BLUE.Text;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void COLOR_YELLOW_Click(object sender, EventArgs e)
        {
             selectedColor = this.COLOR_YELLOW.Text;
        }

        private void COLOR_BLUE_Click_1(object sender, EventArgs e)
        {
            selectedColor = this.COLOR_BLUE.Text;
        }
    }
}
