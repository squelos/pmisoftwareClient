﻿using System.Data.Entity.Validation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using TcpModernUI.ViewModel;


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
            ToggleFlyout(0);
        }

        private void PlayerClickBookings(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(1);
        }

        private void PlayerClickPrefBooking(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(2);
        }

        private void PlayerClickTraining(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(3);
        }

        private void PlayerClickCategories(object sender, RoutedEventArgs e)
        {
            
            ToggleFlyout(4);
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

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            if (mainViewModel != null)
                mainViewModel.ValidationErrorsChanged +=
                    (o, exception) => ViewModelBase_OnValidationErrorsChanged(o, exception);
        }
    }
}