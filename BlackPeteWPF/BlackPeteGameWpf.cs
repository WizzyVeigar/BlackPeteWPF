using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackPete;

namespace BlackPeteWPF
{
    //Instanced object of a BlackPete game in WPF
    class BlackPeteGameWpf<T> : CardGame, IDealCards, IExcludeFromList
    {
        public BlackPeteGameWpf(List<Player> players, ILogger logger, List<Card> cardsToPlayWith) : base(players, logger, cardsToPlayWith)
        {
        }

        public void AddCardsToPlayers()
        {
            do
            {
                for (int i = 0; i < Players.Count; i++)
                {
                    if (Cards.Count != 0)
                    {
                        ((BlackPetePlayer<T>)Players[i]).CardsInHand.Add(Cards.First());
                        Cards.Remove(Cards.First());
                    }
                }

            } while (Cards.Count != 0);
        }

        public override void EndGame()
        {
            throw new NotImplementedException();
        }


        public override void Setup()
        {
            ShuffleCards(Cards);
            //RemoveItemsFromList();
            AddCardsToPlayers();
        }

        public override void StartGame()
        {
            throw new NotImplementedException();
        }
        public void RemoveItemsFromList()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (!Players[i].Equals(typeof(BlackPetePlayer<T>)))
                {
                    Players.RemoveAt(i);
                }
            }
        }
    }
}
