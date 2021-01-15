using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public class CardFactory
    {
        private static CardFactory instance;
        public static CardFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CardFactory();
                }
                return instance;
            }
        }

        /// <summary>
        /// Removes an extra jack from the deck, so we can have a black pete deck
        /// </summary>
        /// <returns>Returns a black pete playing card deck</returns>
        public List<Card> CreateBlackPeteDeck<T>()
        {
            List<Card> deck = null;
            Type cardType = typeof(T);
            if (cardType.Equals(typeof(PlayingCard)))
            {
                deck = CreatePlayingCardDeck();

                for (int i = 0; i < deck.Count(); i++)
                {
                    if (deck[i] is PlayingCard)
                    {
                        if (((PlayingCard)deck[i]).CardSuit == Suit.Spades && deck[i].CardValue == 11)
                        {
                            deck.RemoveAt(i);
                        }
                    }
                }
            }

            return deck;

        }
        /// <summary>
        /// Creates a normal playing card deck
        /// </summary>
        /// <returns>Returns a playing card deck with size 52</returns>
        public List<Card> CreatePlayingCardDeck()
        {
            List<Card> deck = new List<Card>();
            for (int i = 0; i < Enum.GetNames(typeof(Suit)).Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new PlayingCard((Suit)(i), CalculatePlayingCardName(j + 1), j));
                    //((List<PlayingCard>)Deck)[j + (i * 13)] = new PlayingCard((Suit)(i), CalculatePlayingCardName(j+1), j);
                }
            }

            return deck;
        }

        public List<Card> CreateImagePlayingCardDeck()
        {
            List<Card> deck = new List<Card>();
            for (int i = 0; i < Enum.GetNames(typeof(Suit)).Length; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    deck.Add(new PlayingCardImg((Suit)(i), CalculatePlayingCardName(j + 1), j,((Suit)i).ToString().First() + (j+1).ToString() + ".png"));
                    //((List<PlayingCard>)Deck)[j + (i * 13)] = new PlayingCard((Suit)(i), CalculatePlayingCardName(j+1), j);
                }
            }
            return deck;
        }


        /// <summary>
        /// Gives the card a name depending on the <paramref name="number"/>
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Returns the cards name if found. Otherwise returns UnknownCard</returns>
        private string CalculatePlayingCardName(int number)
        {
            switch (number)
            {
                case 1:
                    return "Ace";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return "NotaCard";
            }
        }
    }
}
