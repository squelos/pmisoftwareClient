using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using TcpModernUI.BaseClasses;
using TcpModernUI.Utility;

namespace TcpModernUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            
        }

        private void LaunchFlyoutDemo(object sender, RoutedEventArgs e)
        {
            new TestFlyout().Show();
        }

        private void PlayerDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItems.Count == 1)
            {
                expanderModif.IsExpanded = true;
            }
        }

        private void PLayerClickBadges(object sender, RoutedEventArgs e)
        {

        }

        private void PlayerClickBookings(object sender, RoutedEventArgs e)
        {

        }
    }
}
