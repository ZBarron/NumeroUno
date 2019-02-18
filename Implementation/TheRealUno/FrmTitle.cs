using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TheRealUno {
    public partial class FrmTitle : Form
    {
        public FrmTitle()
        {
            InitializeComponent();
        }
        public static int x;
        private void FrmTitle_Load(object sender, EventArgs e)
        {

        }

        private void btnQuitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            FrmPlayGame frmPlayGame = new FrmPlayGame();
            x = int.Parse(textBox1.Text);
            frmPlayGame.Show();
        }

        // help button - leads to official website
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.unorules.com/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // implement change player icon code here
        }

        private void button2_Click_1(object sender, EventArgs e)        // This is an obsolete button
        {
            //FrmPlayGame.pictureBox4_Click_1();
        }
    }
}
