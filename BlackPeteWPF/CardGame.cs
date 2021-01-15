using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public abstract class CardGame
    {
        private ILogger gameLogger;

        public ILogger GameLogger
        {
            get { return gameLogger; }
            set { gameLogger = value; }
        }

        private IList<Card> cards;

        public IList<Card> Cards
        {
            get { return cards; }
            set { cards = value; }
        }

        private IList<Player> players;

        public IList<Player> Players
        {
            get { return players; }
            set { players = value; }
        }
        /// <summary>
        /// Method for setting up the necessary things to start the game
        /// </summary>
        public abstract void Setup();
        /// <summary>
        /// Start and play of the game
        /// </summary>
        public abstract void StartGame();
        /// <summary>
        /// Method for when game is ending/ended
        /// </summary>
        public abstract void EndGame();

        public CardGame(IList<Player> players, ILogger logger)
        {
            Players = players;
            GameLogger = logger;
        }
        public CardGame(IList<Player> players, ILogger logger, List<Card> cardsToPlayWith) : this(players, logger)
        {
            Cards = cardsToPlayWith;
        }
        /// <summary>
        /// Shuffles the cards
        /// </summary>
        /// <param name="cards"></param>
        public void ShuffleCards(IList<Card> cards)
        {
            cards.Shuffle();
        }
    }
}
