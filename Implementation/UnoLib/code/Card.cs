using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheRealUno.code {
  public enum ColorType {
    YELLOW,
    BLUE,
    RED,
    GREEN,
    BLACK
  }

  /// <summary>
  /// Represents a card in the game of UNO
  /// </summary>
  public class Card : ICloneable {
    /// <summary>
    /// 
    /// </summary>
    public ColorType Color { get; private set; }
    public int Value { get; private set; }
    public PictureBox Pic { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="value"></param>
    public Card(ColorType color, int value) {
      Color = color;
      Value = value;
      Pic = null;
    }

    public object Clone() {
      Card card = new Card(Color, Value);
      return card;
    }

    public override string ToString() {
      return Color.ToString() + ":" + Value.ToString();
    }

    /// <summary>
    /// Returns the string that can be used to lookup the card texture
    /// </summary>
    /// <returns>String for card texture</returns>
    public string getBg() {
      return Color.ToString().ToLower() + "_" + Value.ToString();
    }
  }
}
