using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TcpDash.Business;
using TcpDash.Classes;
using TcpDash.UI;
using TcpDash.ViewModel;
using TcpDataModel;

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
            //we only add to the first column
            if (dailyBookings != null)
            {
                foreach (var visualBooking in dailyBookings.VisualBookingList)
                {
                    //we add it to the appropriate row
                    ShowVisualBooking(visualBooking, 1);
                }
            }
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
            b.Tag = vb;

            b.PreviewMouseDown += b_PreviewMouseDown;

            TextBlock tb = new TextBlock();

            tb.TextWrapping = TextWrapping.Wrap;
            tb.Text = vb.Name;
            b.Content = tb;

            grid.Children.Add(b);
            Grid.SetColumn(b, col);
            Grid.SetRow(b, CalculateRowStart(vb));
            Grid.SetRowSpan(b, CalculateRowSpan(vb));
        }

        private void b_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // here we show the deletion window
            DeletionWindow win = new DeletionWindow((sender as Button).Tag as VisualBooking, _mvm);
            UIDispatcher.Instance.ShowDialogAndBlur(win);
        }


        private int CalculateRowStart(VisualBooking vb)
        {
            int ret = vb.StartHour - 8;
            if (ret != 0)
            {
                ret = ret*2;
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
            if (vb.EndHour < 8)
            {
                return 32;
            }
            int ret = vb.EndHour - 8;
            if (ret != 0)
            {
                ret = ret*2;
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
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            _mvm = mainViewModel;
        }


        private void PreviewLeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(grid);

            int row = 0;
            int col = 0;
            double accHeight = 0.0;
            double accWidth = 0.0;

            foreach (var rowDef in grid.RowDefinitions)
            {
                accHeight += rowDef.ActualHeight;
                if (accHeight >= point.Y)
                    break;
                row++;
            }

            foreach (var columnDefinition in grid.ColumnDefinitions)
            {
                accWidth += columnDefinition.ActualWidth;
                if (accWidth >= point.X)
                    break;
                col++;
            }
            //here thanks to col and row we can infer the selected Cell
            //we try to see if the selected cell contains anything. if it does, 
            // do nothing, or show appropriate dialog
            foreach (UIElement child in grid.Children)
            {
                if (Grid.GetColumn(child) == col && Grid.GetRow(child) == row)
                {
                    //then the row and col match and has an elem
                }
            }
            //infer selected cell
            //day is _mvm.CalendarViewModel.SelectedDay;
            //need row now
            // row 
            // row/2 + 8 = hour.round down = hour
            decimal hourDecimal = row/2 + 8;
            int hour = (int) Math.Floor(hourDecimal);

            DateTime day = _mvm.CalendarViewModel.SelectedDay;
            //determine if it is "selectable"
            //show a window that allows you to book 
            BookingWindow bw = new BookingWindow(_courtBookings.Court, day, _mvm, hour);
            UIDispatcher.Instance.ShowDialogAndBlur(bw);
            e.Handled = false;
        }
    }
}