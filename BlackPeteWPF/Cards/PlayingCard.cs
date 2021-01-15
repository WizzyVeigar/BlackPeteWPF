using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }
    public class PlayingCard : Card
    {
        private Suit cardSuit;

        public PlayingCard(Suit suit, string name, int cardValue) : base(cardValue, name)
        {
            CardSuit = suit;
        }

        public Suit CardSuit
        {
            get { return cardSuit; }
            private set { cardSuit = value; }
        }

        public override string ToString()
        {
            return Name + " of " + CardSuit.ToString();
        }
    }
}
