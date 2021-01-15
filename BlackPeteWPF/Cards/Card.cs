using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public abstract class Card : ICard
    {
        private int cardValue;
        public int CardValue
        {
            get
            {
                return cardValue;
            }
            private set
            {
                cardValue = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                name = value;
            }
        }

        //CardValue is not set yet, because it can be different what value is given, depending on the type of card
        protected Card(string name)
        {
            Name = name;
        }

        protected Card(int cardValue, string name) : this(name)
        {
            CardValue = cardValue;
        }
    }
}
