using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackPete
{
    public static class IListExtension
    {
        private static Random rng = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
            //n starts at list length and goes down by one each time
            int n = list.Count;
            //Only stops after we've been through the entire list
            while (n > 1)
            {
                //Make sure we stop at some point
                n--;
                //Pick a random spot in the list
                int k = rng.Next(n + 1);
                //Hold reference to card at k index
                T value = list[k];
                //Swaps places between N and K
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
