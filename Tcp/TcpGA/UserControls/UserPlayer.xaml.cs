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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpGA.BaseClasses;

namespace TcpGA.UserControls
{
    /// <summary>
    /// Interaction logic for UserPlayer.xaml
    /// </summary>
    public partial class UserPlayer : UserControl
    {
        public UserPlayer()
        {
            InitializeComponent();
        }
        private void PlayerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItems.Count == 1)
            {
                this.playerModif.IsSelected = true;

            }
        }

        private void PlayerClickCategories(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.RequestFlyout("categories");
        }

        private void PlayerClickTraining(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.RequestFlyout("training");
        }

        private void PLayerClickBadges(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.RequestFlyout("badge");
        }

        private void PlayerClickBookings(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.RequestFlyout("booking");
        }

        private void PlayerClickPrefBooking(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.RequestFlyout("bookingPref");
        }
    }
}
