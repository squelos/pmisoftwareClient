using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
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
            BrowserWindow win = new BrowserWindow();
            win.Show();
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

        private void ViewModelBase_OnValidationErrorsChanged(object sender, DbEntityValidationException e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var entry in e.EntityValidationErrors)
            {
                builder.AppendLine(entry.Entry.State + " : " + entry.Entry.Entity);
                foreach (var VARIABLE in entry.ValidationErrors)
                {
                    builder.AppendLine(VARIABLE.ErrorMessage);
                }
            }
            this.ShowMessageAsync("Erreur de validation", builder.ToString(),
                MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
        }

       
    }
}
