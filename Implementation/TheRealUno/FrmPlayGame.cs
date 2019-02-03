using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TheRealUno.code;

namespace TheRealUno {
  public enum PlayerType {
    CPU,
    PLAYER
  }

  public partial class FrmPlayGame : Form {
    private Deck deck;
    private Player cpu;
    private Player player;
    private List<PictureBox> cpuPics;
    private List<PictureBox> playerPics;
    private Stack<Card> discard;
    private PlayerType playerTurn;

    public FrmPlayGame() {
      InitializeComponent();
    }

    private void FrmPlayGame_Load(object sender, EventArgs e) {
      NewGame();
      ShowCards();
    }

    private void NewGame() {
      // create new deck
      deck = new Deck();
      discard = new Stack<Card>();

      // create players
      cpuPics = new List<PictureBox>();
      playerPics = new List<PictureBox>();
      cpu = new Player(deck, deck.Draw(5), cpuPics);
      player = new Player(deck, deck.Draw(5), playerPics);

      playerTurn = PlayerType.PLAYER;
      Discard(deck.Draw(1)[0]);
    }

    private PictureBox GenPictureBox(string name) {
      PictureBox pb = new PictureBox() {
        BackgroundImageLayout = ImageLayout.Stretch,
        Width = 100,
        Height = 140,
        Name = name,
      };
      pb.Click += Pb_Click;
      this.Controls.Add(pb);
      return pb;
    }

    private void ShowCards() {
      int left = 97;
      int top = 21;
      const int SPACING = 127;
      for (int i = 0; i < cpu.NumCards; i++) {
        Card card = cpu.GetCard(i);
        if (card.Pic == null)
          card.Pic = GenPictureBox("cpu_" + i);
        card.Pic.BackgroundImage = GetCardBgImg(card);
        card.Pic.Left = left;
        card.Pic.Top = top;
        left += SPACING;
      }
      top = 438;
      left = 97;
      for (int i = 0; i < player.NumCards; i++) {
        Card card = player.GetCard(i);
        if (card.Pic == null)
          card.Pic = GenPictureBox("player_" + i);
        card.Pic.BackgroundImage = GetCardBgImg(card);
        card.Pic.Left = left;
        card.Pic.Top = top;
        left += SPACING;
      }

      if (playerTurn == PlayerType.CPU) {
        lblCpu.ForeColor = Color.Cyan;
        lblPlayer.ForeColor = Color.White;
      }
      else {
        lblCpu.ForeColor = Color.White;
        lblPlayer.ForeColor = Color.Cyan;
      }
      this.Refresh();
      if (playerTurn == PlayerType.CPU) {
        TakeCpuTurn();
      }
    }

    private void TakeCpuTurn() {
      Thread.Sleep(500);
      for (int c = 0; c < cpu.NumCards; c++) {
        Card card = cpu.GetCard(c);
        if (CheckValidMove(card)) {
          playerTurn = PlayerType.PLAYER;
          cpu.Discard(c);
          Discard(card);
          return;
        }
      }
      pbDeck_Click(null, null);
    }

    private Image GetCardBgImg(Card card) {
      return (Image)Properties.Resources.ResourceManager.GetObject(card.getBg());
    }

    private void Pb_Click(object sender, EventArgs e) {
      PictureBox pb = (PictureBox)sender;
      string[] nameParts = pb.Name.Split('_');
      int index = int.Parse(nameParts[1]);
      Card card;
      if (nameParts[0].ToLower() == "cpu") {
        if (playerTurn == PlayerType.CPU) {
          card = cpu.GetCard(index);
          if (CheckValidMove(card)) {
            Discard(cpu.Discard(index));
            playerTurn = PlayerType.PLAYER;
          }
          else {
          }
        }
      }
      else {
        if (playerTurn == PlayerType.PLAYER) {
          card = player.GetCard(index);
          if (CheckValidMove(card)) {
            Discard(player.Discard(index));
            playerTurn = PlayerType.CPU;
          }
          else {
            String msg = "Card must match in color, number or action. If you cannot play, click on deck to draw a new card and end your turn.";
            MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
          }
        }
      }
      ShowCards();
    }

    private bool CheckValidMove(Card card) {
      return (card.Color == discard.Peek().Color) || (card.Value == discard.Peek().Value);
    }

    private void Discard(Card card) {
      discard.Push(card);
      this.Controls.Remove(card.Pic);
      pbDiscard.BackgroundImage = GetCardBgImg(card);
      ShowCards();
    }

    private void pbDeck_Click(object sender, EventArgs e) {
      if (playerTurn == PlayerType.PLAYER) {
        var newCards = deck.Draw(1);
        player.GiveCards(newCards);
        playerTurn = PlayerType.CPU;
      }
      else {
        var newCards = deck.Draw(1);
        cpu.GiveCards(newCards);
        playerTurn = PlayerType.PLAYER;
      }
      ShowCards();
    }
  }
}
