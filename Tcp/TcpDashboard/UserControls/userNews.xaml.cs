using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TcpDashboard.ViewModel;

namespace TcpDashboard.UserControls
{
    /// <summary>
    /// Interaction logic for userNews.xaml
    /// </summary>
    public partial class userNews : UserControl
    {
        private MainViewModel _mvm;

        public userNews()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataContext = DataContext;
                var mainViewModel = dataContext as MainViewModel;
                _mvm = mainViewModel;
                if (_mvm != null) _mvm.NewsViewModel.PropertyChanged += NewsViewModelOnPropertyChanged;
            }
            catch (Exception ex)
            {

                Console.Out.WriteLine(ex);
            }

        }

        private void NewsViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            web.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(LoadHtmlInWeb));
            //throw new NotImplementedException();
        }

        private void LoadHtmlInWeb()
        {
            web.NavigateToString("<head></head><body bgcolor=\"#D45B07\">" + _mvm.NewsViewModel.CurrentNews.Content + "</body>");

        }
    }
}
