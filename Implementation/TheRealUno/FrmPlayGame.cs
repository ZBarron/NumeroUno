using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TheRealUno.code;

namespace TheRealUno
{
    public enum PlayerType
    {
        CPU,
        PLAYER
    }

    public partial class FrmPlayGame : Form
    {
        private Deck deck;
        private Player cpu;
        private Player player;
        private List<PictureBox> cpuPics;
        private List<PictureBox> playerPics;
        private Stack<Card> discard;
        private PlayerType playerTurn;
        private Boolean isUno = false;

        public FrmPlayGame()
        {
            InitializeComponent();
        }

        private void FrmPlayGame_Load(object sender, EventArgs e)
        {
            NewGame();
            ShowCards();
        }

        private void NewGame()
        {
            // create new deck
            deck = new Deck();
            discard = new Stack<Card>();

            // create players
            cpuPics = new List<PictureBox>();
            playerPics = new List<PictureBox>();
            cpu = new Player(deck, deck.Draw(5), cpuPics); // note: be sure to change this to seven on launch, or implement an option to choose how many cards to start with
            player = new Player(deck, deck.Draw(5), playerPics);

            playerTurn = PlayerType.PLAYER;
            Discard(deck.Draw(1)[0]);
        }

        private PictureBox GenPictureBox(string name)
        {
            PictureBox pb = new PictureBox()
            {
                BackgroundImageLayout = ImageLayout.Stretch,
                Width = 100,
                Height = 140,
                Name = name,
            };
            pb.Click += Pb_Click;
            this.Controls.Add(pb);
            return pb;
        }

        // so this is the super-broken thing that stops defining cards after a certain point. 
        private void ShowCards()
        {
            int left = 97;
            int top = 21;
            const int SPACING = 60;
            for (int i = 0; i < cpu.NumCards; i++)
            {
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
            for (int i = 0; i < player.NumCards; i++)
            {
                Card card = player.GetCard(i);
                if (card.Pic == null)
                    card.Pic = GenPictureBox("player_" + i);
                card.Pic.BackgroundImage = GetCardBgImg(card);
                card.Pic.Left = left;
                card.Pic.Top = top;
                left += SPACING;
            }

            if (playerTurn == PlayerType.CPU)
            {
                lblCpu.ForeColor = Color.Cyan;
                lblPlayer.ForeColor = Color.White;
            }
            else
            {
                lblCpu.ForeColor = Color.White;
                lblPlayer.ForeColor = Color.Cyan;
            }
            this.Refresh();
            if (playerTurn == PlayerType.CPU)
            {
                TakeCpuTurn();
            }
        }

        private void TakeCpuTurn()
        {
            Thread.Sleep(500);
            for (int c = 0; c < cpu.NumCards; c++)
            {
                Card card = cpu.GetCard(c);
                if (CheckValidMove(card))
                {
                    playerTurn = PlayerType.PLAYER;
                    cpu.Discard(c);
                    Discard(card);
                    // handles UNO for CPU - Santiago
                    if (cpu.NumCards == 1)
                    {
                        String msg = "Your opponent has called UNO.";
                        MessageBox.Show(msg, "UNO Declared!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                    }
                    return;
                }
            }
            pbDeck_Click(null, null);
        }

        private Image GetCardBgImg(Card card)
        {
            return (Image)Properties.Resources.ResourceManager.GetObject(card.getBg());
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string[] nameParts = pb.Name.Split('_');
            int index = int.Parse(nameParts[1]);
            Card card;
            if (nameParts[0].ToLower() == "cpu")
            {
                if (playerTurn == PlayerType.CPU)
                {
                    card = cpu.GetCard(index);
                    if (CheckValidMove(card))
                    {
                        Discard(cpu.Discard(index));
                        playerTurn = PlayerType.PLAYER;
                    }
                    else
                    {
                    }
                }
            }
            else
            {
                if (playerTurn == PlayerType.PLAYER)
                {
                    card = player.GetCard(index);
                    if (CheckValidMove(card))
                    {
                        Discard(player.Discard(index));
                        if (player.NumCards == 1)
                        {
                            String msg = "You now have two seconds to call UNO.";
                            MessageBox.Show(msg, "One Card Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            Thread.Sleep(2000);
                            if (!isUno)
                            {
                                button1_Click(null, null);
                            }
                        }
                        if (player.NumCards > 1)
                        {
                            isUno = false;
                        }
                        playerTurn = PlayerType.CPU;
                    }
                    else
                    {
                        String msg = "Card must match in color, number or action. If you cannot play, click on deck to draw a new card and end your turn.";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            ShowCards();
        }

        private bool CheckValidMove(Card card)
        {
            return (card.Color == discard.Peek().Color) || (card.Value == discard.Peek().Value);
        }

        private void Discard(Card card)
        {
            discard.Push(card);
            this.Controls.Remove(card.Pic);
            pbDiscard.BackgroundImage = GetCardBgImg(card);
            ShowCards();
        }

        private void pbDeck_Click(object sender, EventArgs e)
        {
            if (playerTurn == PlayerType.PLAYER)
            {
                var newCards = deck.Draw(1);
                player.GiveCards(newCards);
                playerTurn = PlayerType.CPU;
            }
            else
            {
                var newCards = deck.Draw(1);
                cpu.GiveCards(newCards);
                playerTurn = PlayerType.PLAYER;
            }
            ShowCards();
        }

        // UNO button functionality - handles stories about UNO and what happens if you incorrectly call UNO
        private void button1_Click(object sender, EventArgs e)
        {
            if (playerTurn == PlayerType.PLAYER)
            {
                if (player.NumCards != 1)
                {
                    String msg = "You cannot call UNO if you don't have one card. Two cards will be drawn for you as penalty.";
                    MessageBox.Show(msg, "Invalid Play", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    isUno = false;
                    pbDeck_Click(null, null);
                    pbDeck_Click(null, null);
                }
                else if (player.NumCards == 1)
                {
                    String msg = "UNO";
                    MessageBox.Show(msg, "UNO declared!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    isUno = true;
                }
                else
                {
                    isUno = false;
                    pbDeck_Click(null, null);
                    pbDeck_Click(null, null);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.unorules.com/");
        }
    }
}
