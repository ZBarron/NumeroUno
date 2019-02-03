using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheRealUno.code {
  public class Player {
    private Deck deck;
    private List<Card> hand;
    private List<PictureBox> pics;

    public int NumCards {
      get { return hand.Count; }
    }

    public Player(Deck deck, List<Card> hand, List<PictureBox> pics) {
      this.hand = hand;
      this.deck = deck;
      this.pics = pics;
    }

    public string GetCardBg(int index) {
      return hand[index].getBg();
    }

    public Card Discard(int index) {
      Card card = null;
      if (index >= 0 && index < hand.Count) {
        card = hand[index];
        hand.RemoveAt(index);
      }
      return card;
    }

    public Card GetCard(int index) {
      return hand[index];
    }

    public void GiveCards(List<Card> givenCards) {
      hand.AddRange(givenCards);
    }
  }
}
