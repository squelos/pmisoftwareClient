using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            _mvm = mainViewModel;
            _mvm.NewsViewModel.PropertyChanged +=NewsViewModelOnPropertyChanged;
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
