using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackPete;

namespace BlackPete
{
    public class PlayingCardImg : PlayingCard
    {
        private string imgSource;

        public string ImgSource
        {
            get { return imgSource; }
            set { imgSource = value; }
        }


        public PlayingCardImg(Suit suit, string name, int cardValue, string imgSource) : base(suit, name, cardValue)
        {
            ImgSource = imgSource;
        }
    }
}
