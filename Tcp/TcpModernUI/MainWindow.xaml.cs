using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using TcpDataModel;
using TcpModernUI.BaseClasses;
using TcpModernUI.ViewModel;


namespace TcpModernUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private CustomDispatcher _dispatcher;
        private MainViewModel _mainViewModel;
       

        public MainWindow()
        {
            _dispatcher = CustomDispatcher.Instance;
            _dispatcher.RegisterUI(this);

            _dispatcher.BadgeRequest += text => OpenPlayerBadges();
            _dispatcher.BookingPrefRequest += text => OpenPlayerBookingPrefs();
            _dispatcher.BookingRequest += text => OpenPlayerBookings();
            _dispatcher.CategoriesRequest += text => OpenPlayerCategories();
            _dispatcher.TrainingRequest += text => OpenPlayerTraining();
        }

        private void LaunchFlyoutDemo(object sender, RoutedEventArgs e)
        {
            BrowserWindow win = new BrowserWindow();
            win.Show();
        }

        private void OpenPlayerBadges()
        {
            ToggleFlyout(0);
        }

        private void OpenPlayerBookings()
        {
            ToggleFlyout(1);
        }

        private void OpenPlayerBookingPrefs()
        {
            ToggleFlyout(2);
        }

        private void OpenPlayerTraining()
        {
            ToggleFlyout(3);
        }

        private void OpenPlayerCategories()
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
            _dispatcher = CustomDispatcher.Instance;
            _dispatcher.RegisterUI(this);

            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.ValidationErrorsChanged +=
                    (o, exception) => ViewModelBase_OnValidationErrorsChanged(o, exception);
                mainViewModel.CustomErrorsChanged += (o, s) => ViewModelBase_CustomErrorsChanged(o, s);
                _mainViewModel = mainViewModel;
            }
        }

        private void ViewModelBase_CustomErrorsChanged(object sender, string s)
        {
            this.ShowMessageAsync("Erreur de validation", s,
                MahApps.Metro.Controls.MessageDialogStyle.Affirmative);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainViewModel.BadgeDriver.Dispose();
        }

        
    }
}