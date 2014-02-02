using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpDataModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for RecentPlayers.xaml
    /// </summary>
    public partial class RecentPlayers : UserControl
    {

        #region privates

        private Player _firstPlayer;
        private List<Player> _recentPlayers;
        private int _working = 0;
        #endregion

        #region ctor
        public RecentPlayers()
        {
            InitializeComponent();
        }
        #endregion


        #region getters/setters

        public Player FirstPlayer
        {
            get { return _firstPlayer; }
            set
            {
                _firstPlayer = value;
                //get recent players from here
                Task t = new Task(() =>
                {
                    Working++;
                    entityContainer cont = new entityContainer();
                    var res =
                        cont.BookingJeu.Where(booking => booking.Player1.ID == _firstPlayer.ID)
                            .OrderByDescending(booking => booking.creationDate)
                            .Distinct()
                            .Select(booking => booking.Player2).ToList().Take(5);
                    Dispatcher.Invoke(() => lb.ItemsSource = res);
                    Working--;
                });
                t.Start();

            }
        }

        public int Working
        {
            get { return _working; }
            set
            {
                _working = value;
                if (!Dispatcher.CheckAccess())
                {
                    Dispatcher.Invoke(() =>
                    {
                        if (_working != 0)
                        {
                            lb.Visibility = Visibility.Collapsed;
                            ProgressBar.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            lb.Visibility = Visibility.Visible;
                            ProgressBar.Visibility = Visibility.Collapsed;
                        }
                    });
                }
                else
                {
                    if (_working != 0)
                    {
                        lb.Visibility = Visibility.Collapsed;
                        ProgressBar.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lb.Visibility = Visibility.Visible;
                        ProgressBar.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }


        #endregion

        #region events

        public delegate void SelectedPlayerChanged(object sender, Player player);

        public event SelectedPlayerChanged Changed;

        private void RaiseChanged(Player p)
        {
            if (Changed != null)
            {
                Changed(this, p);
            }
        }

        #endregion

        private void Lb_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb.SelectedValue != null)
            {
                RaiseChanged(lb.SelectedValue as Player);
            }
        }

        public void PlayExpandStory()
        {
            this.BeginStoryboard(FindResource("Storyboard2") as Storyboard);
        }

        public void PlayRetractStory()
        {
            this.BeginStoryboard(FindResource("Storyboard1") as Storyboard);
        }
    }
}
