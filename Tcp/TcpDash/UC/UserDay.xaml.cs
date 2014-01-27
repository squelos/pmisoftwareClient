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
using TcpDash.Business;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserDay.xaml
    /// </summary>
    public partial class UserDay : UserControl
    {

        #region privates

        private MainViewModel _mvm;
        private CourtBookings _courtBookings;
        #endregion


        #region ctor
        public UserDay(MainViewModel mvm)
        {
            InitializeComponent();
            _mvm = mvm;
        }

        #endregion

        #region getters/setters



        public CourtBookings CourtB
        {
            get { return _courtBookings; }
            set
            {
                _courtBookings = value;
                //refresh here
                Refresh();
            }
        }

        #endregion

        #region publics

        #endregion

        #region privates

        private void Refresh()
        {
            if (_courtBookings == null)
            {
                return;
            }
            //get the visual bookings
            DateTime day = _mvm.CalendarViewModel.SelectedDay;

            //we must only show the current day
            DailyBookings dailyBookings =
                _courtBookings.WeeklyBookingses.DailyBookingses.FirstOrDefault(bookings => bookings.DayDateTime == day);
            //TODO maybe the date ?
            //we only add to the first column
            if (dailyBookings != null)
            {
                foreach (var visualBooking in dailyBookings.VisualBookingList)
                {
                    //we add it to the appropriate row
                    ShowVisualBooking(visualBooking, 0);
                }
            }
            //TODO seems bugged
            //TODO check if bookings contains info

        }

        private void ShowVisualBooking(VisualBooking vb, int col)
        {
            if (vb.StartHour < 8 || vb.EndHour > 23)
            {
                //we dont show if out of hours
                return;
            }
            Button b = new Button();

            b.HorizontalAlignment = HorizontalAlignment.Stretch;
            b.VerticalAlignment = VerticalAlignment.Stretch;
            b.Content = vb.Name;
            grid.Children.Add(b);
            Grid.SetColumn(b, col);
            Grid.SetRow(b, CalculateRowStart(vb));
            Grid.SetRowSpan(b, CalculateRowSpan(vb));
        }

        private int CalculateRowStart(VisualBooking vb)
        {

            int ret = vb.StartHour - 8;
            if (ret != 0)
            {
                ret = ret * 2;
            }
            if (vb.StartMin >= 30)
            {
                ret++;
            }
            return ret;
        }

        private int CalculateRowSpan(VisualBooking vb)
        {
            //default at 1
            return CalculateRowEnd(vb) - CalculateRowStart(vb);
        }

        private int CalculateRowEnd(VisualBooking vb)
        {
            int ret = vb.EndHour - 8;
            if (ret != 0)
            {
                ret = ret * 2;
            }
            if (vb.EndMin >= 30)
            {
                ret++;
            }
            return ret;
        }
        #endregion

        private void UserDay_OnLoaded(object sender, RoutedEventArgs e)
        {
            //var dataContext = DataContext;
            //var mainViewModel = dataContext as MainViewModel;
            //_mvm = mainViewModel;
        }
    }
}
