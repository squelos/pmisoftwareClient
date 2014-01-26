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
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserCombined.xaml
    /// </summary>
    public partial class UserCombined : UserControl
    {

        private MainViewModel _mvm;

        public UserCombined()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            _mvm = dataContext as MainViewModel;
            if (_mvm != null) _mvm.CalendarViewModel.PropertyChanged += CalendarViewModelOnPropertyChanged;
            CalendarViewModelOnPropertyChanged(this, null);
        }

        private void CalendarViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            //we refresh to show the current day per court
            wrap.Children.Clear();

            foreach (var courtBookingse in _mvm.CalendarViewModel.BookingManager.CourtBookingses)
            {
                GroupBox gb = new GroupBox();
                gb.Header = courtBookingse.Court.number;
                UserDay uDay = new UserDay(_mvm);
                
                //feed a CourtBooking
                //the courtBooking must contain the bookings of the day
                
                gb.Content = uDay;
                wrap.Children.Add(gb);
                uDay.WeekMode = false;
                uDay.CourtB = courtBookingse;
            }
        }
    }
}
