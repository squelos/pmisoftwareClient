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
using MahApps.Metro.Controls;
using TcpDataModel;

namespace TcpModernUI.Pages.players
{
    /// <summary>
    /// Interaction logic for creation.xaml
    /// </summary>
    public partial class creation 
    {
        public creation()
        {
            InitializeComponent();
            //currentPlayer = new Player();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItems.Count == 1)
            {
                expanderModif.IsExpanded = true;
            }
        }

        private void ClickBadges(object sender, RoutedEventArgs e)
        {

        }

        private void ClickBookings(object sender, RoutedEventArgs e)
        {

        }
    }

}
