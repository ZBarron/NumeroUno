using System;
using System.Windows.Forms;

namespace TheRealUno {
  public partial class FrmTitle : Form {
    public FrmTitle() {
      InitializeComponent();
    }

    private void FrmTitle_Load(object sender, EventArgs e) {

    }

    private void btnQuitGame_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void btnStartGame_Click(object sender, EventArgs e) {
      FrmPlayGame frmPlayGame = new FrmPlayGame();
      frmPlayGame.Show();
    }
  }
}
