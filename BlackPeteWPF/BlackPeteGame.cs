using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    class BlackPeteGame<T> : CardGame, IDealCards, IExcludeFromList
    {
        public BlackPeteGame(List<Player> players, ILogger logger) : base(players, logger)
        {
            Cards = CardFactory.Instance.CreateBlackPeteDeck<T>();
        }

        public override void EndGame()
        {
            GameLogger.LogMessage("The loser is: " + Players.First().Name + "!");
        }

        public override void Setup()
        {
            ShuffleCards(Cards);
            RemoveItemsFromList();
            AddCardsToPlayers();
            //for (int i = 0; i < Cards.Count; i++)
            //{
            //    GameLogger.LogMessage(Cards[i].ToString());
            //}
        }

        public override void StartGame()
        {
            PairCheckAllPlayers();

            do
            {
                //Loops through each players turn
                for (int i = 0; i < Players.Count; i++)
                {
                    BlackPetePlayer<T> otherPlayer = (BlackPetePlayer<T>)Players[i == 0 ? Players.Count - 1 : i - 1];
                    Card stolenCard = null;
                    if (Players[i].IsAi)
                    {
                        try
                        {
                            stolenCard = ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer);
                        }
                        catch (Exception)
                        {
                            GameLogger.LogMessage("Something went wrong with the Ai");
                        }
                    }
                    else
                    {
                        //!Way too big a method probably
                        //!Gets a user input between 1 and the next players hand amount
                        string choice = "";
                            //((ConsoleLogger)GameLogger).GetUInput(
                            //Players[i].Name + ", it is your turn" + "\n" +
                            //"Choose a number between 1-" + otherPlayer.CardsInHand.Count);
                        try
                        {
                            stolenCard = ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer, Convert.ToInt32(choice));
                        }
                        catch (Exception)
                        {
                            stolenCard = ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer);
                            GameLogger.LogMessage("Your input was invalid and you instead took a random card! \n Try entering a valid number next time");
                        }
                    }
                    //Steal a card from your opponent, then check whether or not it makes a pair
                    if (((BlackPetePlayer<T>)Players[i]).CheckForNewPair(stolenCard))
                    {
                        GameLogger.LogMessage(Players[i].Name + " Stole " + ((BlackPetePlayer<T>)Players[i]).TakeCard(otherPlayer).ToString() + " from " + otherPlayer.Name);
                    }
                    else
                    {
                        GameLogger.LogMessage(Players[i].Name + " got a " + stolenCard.Name);
                    }

                    if (CheckIfPlayerDone((BlackPetePlayer<T>)Players[i]))
                    {
                        Players.RemoveAt(i);
                    }
                    else if (CheckIfPlayerDone(otherPlayer))
                    {
                        Players.Remove(otherPlayer);
                    }
                }
            } while (Players.Count != 1);
        }

        private bool CheckIfPlayerDone(BlackPetePlayer<T> player)
        {
            if (player.CardsInHand.Count == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks all players at the start of the game, to see if they have any pairs
        /// </summary>
        private void PairCheckAllPlayers()
        {
            foreach (BlackPetePlayer<T> player in Players)
            {
                foreach (string pair in player.CheckForPair())
                {
                    GameLogger.LogMessage(pair);
                }
            }
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

        /// <summary>
        /// Shows the hand of <paramref name="player"/>
        /// </summary>
        /// <param name="player"></param>
        public void ShowPlayerHand(BlackPetePlayer<T> player)
        {
            foreach (string item in player.ShowPlayerCards())
            {
                GameLogger.LogMessage(item);
            }
        }
    }
}
