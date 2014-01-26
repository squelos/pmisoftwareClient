using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserIndiv.xaml
    /// </summary>
    public partial class UserIndiv : UserControl
    {
        private MainViewModel _mvm;

        public UserIndiv()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            _mvm = dataContext as MainViewModel;
            if (_mvm != null) _mvm.CalendarViewModel.PropertyChanged += CalendarViewModel_PropertyChanged;
            CalendarViewModel_PropertyChanged(this, null);
        }

        void CalendarViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //we refresh the tabs and their contents
            //this shows a weekly planning for each court in a different tab
            animatedTab.Items.Clear();
            foreach (var courtBookingse in _mvm.CalendarViewModel.BookingManager.CourtBookingses)
            {
                TabItem ti = new MetroTabItem(animatedTab);
                UserDay uDay = new UserDay(_mvm);
                uDay.WeekMode = true;
                //feed a CourtBooking
                uDay.CourtB = courtBookingse;
                ti.Header = courtBookingse.Court.number;
                ti.Content = uDay;
                animatedTab.Items.Add(ti);
            }
        }
    }
}
