﻿using System;
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
            int x = FrmTitle.x;
            // create new deck
            deck = new Deck();
            discard = new Stack<Card>();

            // create players
            cpuPics = new List<PictureBox>();
            playerPics = new List<PictureBox>();
            cpu = new Player(deck, deck.Draw(x), cpuPics); // note: be sure to change this to seven on launch, or implement an option to choose how many cards to start with
            player = new Player(deck, deck.Draw(x), playerPics);

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

        // so this is the super-broken thing that stops defining cards after a certain point. Or at least, part of what's broken.
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

                    // handles zero cards
                    if (cpu.NumCards == 0)
                    {
                        String msg = "Your opponent ran out of cards. You've lost the game.";
                        var result = MessageBox.Show(msg, "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.OK)
                        {
                            String rematch = "Would you like to continue?";
                            var grudgematch = MessageBox.Show(rematch, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            // cancel the closure of the form.

                            if (grudgematch == DialogResult.No)
                            {
                                Application.Exit();

                            }
                            else if (grudgematch == DialogResult.Yes)
                            {
                                NewGame();
                                ShowCards();
                            }

                        }

                    }
                    return;
                }

            }

            if (player.NumCards != 0)
            {
                pbDeck_Click(null, null);
            }
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
                        // actionCards(card);               MARKER - DAVIS
                        Discard(cpu.Discard(index));
                        playerTurn = PlayerType.PLAYER;
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
                        if (player.NumCards > 1)
                        {
                            isUno = false;
                        }
                        Discard(player.Discard(index));
                        if (player.NumCards == 1)
                        {
                            String msg = "You now have two seconds to call UNO.";
                            MessageBox.Show(msg, "One Card Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                            Thread.Sleep(2000);
                            if (!isUno)
                            {
                                button1_Click("click", null);
                            }
                        }                       

                        // zero cards
                        if (player.NumCards == 0)
                        {
                            String msg = "You've run out of cards. You've won the game!";
                            var result = MessageBox.Show(msg, "Game over!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);                                     

                            if (result == DialogResult.OK)
                            {
                                String rematch = "Would you like to continue?";
                                var grudgematch = MessageBox.Show(rematch, "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                // cancel the closure of the form.
                                if (grudgematch == DialogResult.No)
                                {
                                    Application.Exit();

                                }
                                else if(grudgematch == DialogResult.Yes)
                                {
                                    NewGame();
                                }
                            }
                        }

                        playerTurn = PlayerType.CPU;
                    }
                    else if (!CheckValidMove(card))
                    {
                        // If not a valid move and a WILD CARD is selected
                        if(card.Value == 13)
                        {
                            Discard(player.Discard(index));
                            // This opens a new form in which the player can define one of four colors 
                            FrmActionCard frmActionCard = new FrmActionCard();
                            if (frmActionCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string option = frmActionCard.selectedColor;
                                string msg = String.Format("Current Color: {0}", option);
                                MessageBox.Show(msg, "WILD CARD!");
                                // Change the color of the next card to the selected option

                                Console.WriteLine(option);
                                card = new Card((ColorType)Enum.Parse(typeof(ColorType), option), card.Value);
                                Console.WriteLine(card.Color);
                                discard.Push(card);


                            }
                        }

                        // If not a valid move and a WILD DRAW 4 is selected 
                        if (card.Value == 14)
                        {
                            Discard(player.Discard(index));
                            string msg = "A WILD DRAW FOUR card has been played. Draw 4 cards!";
                            MessageBox.Show(msg, "WILD CARD!");

                            // Insert some functionality to force the opposing player to draw four cards

                            FrmActionCard frmActionCard = new FrmActionCard();
                            if (frmActionCard.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                string option = frmActionCard.selectedColor;
                                string text = String.Format("Current Color: {0}", option);
                                MessageBox.Show(text, "WILD CARD!");
                                // Change the color of the next card to the selected option

                                Console.WriteLine(option);
                                card = new Card((ColorType)Enum.Parse(typeof(ColorType), option), card.Value);
                                Console.WriteLine(card.Color);
                                discard.Push(card);

                                var newCards = deck.Draw(4);
                                cpu.GiveCards(newCards);


                            }
                        }

                        // If not a valid move and the SKIP action card is played 
                        if(card.Value == 10 && card.Color == discard.Peek().Color)
                        {
                            Discard(player.Discard(index));
                            string msg = "A SKIP card has been played. The next player's turn is cancelled.";
                            MessageBox.Show(msg, "SKIP!");
                            // Cancel the next player's turn

                            playerTurn = PlayerType.PLAYER;

                            
                        }

                        // If not a valid move and the REVERSE action card is played.
                        if(card.Value == 11 && card.Color == discard.Peek().Color)
                        {
                            Discard(player.Discard(index));
                            string msg = "A REVERSE card has been played. The rotation order is now altered.";
                            MessageBox.Show(msg, "REVERSE!");

                            Discard(card);

                            playerTurn = PlayerType.PLAYER;
                        }

                        // If not a valid move and the DRAW +2 action card is played. 
                        if(card.Value == 12 && card.Color == discard.Peek().Color)
                        {
                            Discard(player.Discard(index));
                            string msg = "A DRAW +2 action card has been played. Draw 2 cards from the deck.";
                            MessageBox.Show(msg, "DRAW +2!");

                            var newCards = deck.Draw(2);
                            cpu.GiveCards(newCards);


                            playerTurn = PlayerType.PLAYER;

                        }

                    }
                    else
                    {
                        String msg = "Card must match in color, number or action. If you cannot play, click on deck to draw a new card and end your turn." + Environment.NewLine +  "Check if you can use any action cards.";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            ShowCards();
        }

        private bool CheckValidMove(Card card)
        {
            return ((card.Color == discard.Peek().Color && card.Color != ColorType.BLACK) || (card.Value == discard.Peek().Value && card.Value < 13));
        }

        //trying to implement action cards. if anyone has better ideas of how to do it, please do so in your own branch and let other review - Santiago
        private void actionCards(Card card)
        {
            if (card.Color == ColorType.BLACK)
            {
                if (card.Value == 14) // wild draw 4
                {
                    if (playerTurn == PlayerType.CPU)
                    {
                        // player draws four cards, a color is chosen, then CPU goes again
                        String msg = "Not implemented yet";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                    }
                    else if (playerTurn == PlayerType.PLAYER)
                    {
                        //cpu draws 4 cards, player chooses color, then player goes again
                        String msg = "Not implemented yet";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);


                    }
                }

                else if (card.Value == 13) // regular wild
                {
                    if (playerTurn == PlayerType.CPU)
                    {
                        // color becomes whichever color is next in cpu hands
                        String msg = "Not implemented yet";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);


                    }
                    else if (playerTurn == PlayerType.PLAYER)
                    {
                        // message box pops up for player to pick color
                        String msg = "Not implemented yet";
                        MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

                    }
                }
            }

            // other action cards
            else if (card.Value == 12 && (card.Color == discard.Peek().Color || (card.Value == discard.Peek().Value)))
            {
                // skip
                String msg = "Not implemented yet";
                MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

            }

            else if (card.Value == 11 && (card.Color == discard.Peek().Color || (card.Value == discard.Peek().Value)))
            {
                // reverse   
                String msg = "Not implemented yet";
                MessageBox.Show(msg, "Invalid Card", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);

            }

            else if (card.Value == 10 && (card.Color == discard.Peek().Color || (card.Value == discard.Peek().Value)))
            {
                // draw 2
                if (playerTurn == PlayerType.CPU)
                {
                    // player draws two cards, CPU goes again
                    pbDeck_Click("draw2", null);

                }
                else if (playerTurn == PlayerType.PLAYER)
                {
                    //cpu draws 2 cards, player goes again
                    pbDeck_Click("draw2", null);

                }
            }

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
            var newCards=deck.Draw(1); // make newCards a variable up here so I change it whenever I want in the program
            //I'll check here to see if this is the last card in the pile
            if(deck.GetSize() == 0)
            {
                EmptyDiscard();
            }
            if (playerTurn == PlayerType.PLAYER)
            {
                if (!(sender == null))
                {
                    if (sender.Equals("uno") || sender.Equals("draw2"))
                    {//in case it tries to draw 2 when there's one card left
                        if(deck.GetSize() == 1)
                        {
                            newCards = deck.Draw(1);
                            EmptyDiscard();
                        }
                        else
                        {
                            newCards = deck.Draw(2);
                            if(deck.GetSize() == 0)
                            {
                                EmptyDiscard();
                            }
                        }
                    }

                }

                player.GiveCards(newCards);
                playerTurn = PlayerType.CPU;
            }
            else
            {
                if (!(sender == null))
                {
                    if (sender.Equals("uno") || sender.Equals("draw2"))
                    {
                        newCards = deck.Draw(2);
                    }

                }
                
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
                    pbDeck_Click("uno", null);
                }
                else if (player.NumCards == 1 && sender != null)
                {
                    String msg = "UNO";
                    MessageBox.Show(msg, "UNO declared!", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    isUno = true;
                }
                
            }
        }

        //This method empties the discard pile and reshuffles it for the deck
        private void EmptyDiscard()
        {
            //keep the top card for the discard pile
            Card topCard = discard.Pop();
            //take all the cards in discard and add them to the deck
            while(discard.Count > 0)
            {
                deck.AddCards(discard.Pop(), 1);
            }
            deck.ShuffleDeck();
            //Bring the top card back to the discard pile
            Discard(topCard);
        }

        // help button - leads to official website
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.unorules.com/");
        }

        public void pictureBox4_Click_1(object sender, EventArgs e)
        {
                        // implement change player icon code here
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox4.BackgroundImage = new Bitmap(openFileDialog1.FileName);
                this.label1.Hide();
            }
        }
    }
}
