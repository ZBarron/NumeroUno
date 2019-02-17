using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRealUno.code {
  public class Deck {
    private List<Card> cards;
    private Random rand;

    public Deck() {
      cards = new List<Card>(110);
      rand = new Random(DateTime.Now.Millisecond);
      NewDeck();
      ShuffleDeck();
    }

    public override string ToString() {
      string s = "";
      foreach (Card card in cards) {
        s += card.ToString() + Environment.NewLine;
      }
      return s;
    }

    private void NewDeck() {
      AddCards(new Card(ColorType.BLACK, 13), 4);
      AddCards(new Card(ColorType.BLACK, 14), 4);
      AddCards(new Card(ColorType.RED, 0), 1);
      AddCards(new Card(ColorType.BLUE, 0), 1);
      AddCards(new Card(ColorType.GREEN, 0), 1);
      AddCards(new Card(ColorType.YELLOW, 0), 1);

      foreach (ColorType colorType in Enum.GetValues(typeof(ColorType))) {
        if (colorType == ColorType.BLACK)
          continue;
        for (int v = 1; v <= 12; v++) {
          AddCards(new Card(colorType, v), 1);
        }
      }
    }

    public void AddCards(Card card, int dups) {
      for (int i = 0; i < dups; i++) {
        cards.Add((Card)card.Clone());
      }
    }

    public void ShuffleDeck() {
      List<Card> shuffledDeck = new List<Card>(cards.Count);
      while (cards.Count > 0) {
        int randIndex = rand.Next(cards.Count);
        shuffledDeck.Add(cards[randIndex]);
        cards.RemoveAt(randIndex);
      }
      cards = shuffledDeck;
    }

    public List<Card> Draw(int amount) {
      if (cards.Count >= amount) {
        List<Card> hand = new List<Card>();
        for (int i = 0; i < amount; i++) {
          Card card = cards[cards.Count - 1];
          hand.Add(card);
          cards.RemoveAt(cards.Count - 1);
        }
        return hand;
      }
      else {
        //TODO: worry about this later
        return null;
      }
    }
    //need to know the size to see if it's empty or is about to be empty
    public int GetSize()
    {
        return cards.Count;
    }
  
  }
}
