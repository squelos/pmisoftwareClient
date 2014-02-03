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
using TcpDash.Classes;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserCalendar.xaml
    /// </summary>
    public partial class UserCalendar : UserControl
    {
        private TouchPoint _touchStart;
        private SwipeHelper _helper = new SwipeHelper();
        private MainViewModel _mvm;

        public UserCalendar()
        {
            InitializeComponent();
        }

        private void UserCalendar_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            _mvm = dataContext as MainViewModel;
            _mvm.CalendarViewModel.RequestSent += CalendarViewModelOnRequestSent;
        }

        private void CalendarViewModelOnRequestSent(object sender, EventArgs eventArgs)
        {
            tab.SelectedIndex = 0;
        }
    }
}