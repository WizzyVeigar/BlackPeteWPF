using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public abstract class Player
    {
        private string name;
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        private bool isAi;

        public bool IsAi
        {
            get { return isAi; }
            private set { isAi = value; }
        }

        public Player(string name, bool isAi)
        {
            if (isAi)
            {
                Name += name + " (Ai)";
            }
            IsAi = isAi;
        }
    }
}
