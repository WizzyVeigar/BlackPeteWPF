using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BlackPete;

namespace BlackPeteWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BlackPeteGameWpf<PlayingCardImg> blackPeteGame;

        public MainWindow()
        {
            InitializeComponent();

            List<Player> players = new List<Player>();
            BlackPetePlayer<PlayingCardImg> player = new BlackPetePlayer<PlayingCardImg>("Kenneth", false);
            BlackPetePlayer<PlayingCardImg> ai = new BlackPetePlayer<PlayingCardImg>("Kripp", true);

            players.Add(player);
            players.Add(ai);

            List<Card> cards = CardFactory.Instance.CreateImagePlayingCardDeck();


            blackPeteGame = new BlackPeteGameWpf<PlayingCardImg>(players, new TestLogger(), cards);
            blackPeteGame.Setup();
            try
            {
                foreach (PlayingCardImg card in ((BlackPetePlayer<PlayingCardImg>)blackPeteGame.Players[0]).CardsInHand)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "/assets/" + card.ImgSource));
                    Image img = new Image();
                    img.Width = 50;
                    img.Height = 50;
                    img.Source = bitmap;
                    listBox_PlayerCards.Items.Add(img);
                }
                listBox_PlayerCards.Visibility = Visibility.Hidden;
            }
            catch (Exception e)
            {

                throw e;
            }

            try
            {
                foreach (PlayingCardImg card in ((BlackPetePlayer<PlayingCardImg>)blackPeteGame.Players[1]).CardsInHand)
                {

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //panel_AiCards.Items.Add()
        }

        private void ClickStart(object sender, RoutedEventArgs e)
        {
            listBox_PlayerCards.Visibility = Visibility.Visible;
            btn_StartGame.Visibility = Visibility.Hidden;
            btn_StartGame.IsEnabled = false;

            //blackPeteGame.StartGame();
        }

        private void btn_PlayerConfirm_Click(object sender, RoutedEventArgs e)
        {
            //Update view when stuff is being done
            //((BlackPetePlayer<PlayingCardImg>)blackPeteGame.Players[0]).CardsInHand.RemoveAt(0);
        }
    }


    //Amount of times I had to correct old code : 3
}
