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
    /// Interaction logic for UserWeek.xaml
    /// </summary>
    public partial class UserWeek : UserControl
    {

        #region privates

        private MainViewModel _mvm;
        private CourtBookings _courtBookings;

        #endregion

        #region ctor
        public UserWeek(MainViewModel mvm)
        {
            InitializeComponent();
            _mvm = mvm;
            //for (int i = 0; i < 6; i++)
            //{
            //    for (int j = 0; j < 31; j++)
            //    {
            //        Rectangle rect = new Rectangle();
            //        rect.Stroke = new SolidColorBrush(Color.FromRgb(43, 00, 06));
            //        rect.Fill = Brushes.Transparent;
            //        grid.Children.Add(rect);
            //        Grid.SetColumn(rect, i);
            //        Grid.SetRow(rect, j);
            //    }
            //}
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

            //we must show the whole week planning
            List<DailyBookings> listBookings = _courtBookings.WeeklyBookingses.DailyBookingses;

            //grid has 7 columnsn and 30 rows
            for (int i = 0; i < 7; i++)
            {
                if (listBookings[i].VisualBookingList.Count() != 0)
                {
                    foreach (var dailyBookingse in listBookings[i].VisualBookingList)
                    {
                        ShowVisualBooking(dailyBookingse, i);
                    }
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
            TextBlock tb = new TextBlock();
            tb.TextWrapping = TextWrapping.Wrap;
            
            tb.Text = vb.Name;
            b.Content = tb;
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
            //TODO sometimes get neg values
            //default at 1
            return CalculateRowEnd(vb) - CalculateRowStart(vb);
        }

        private int CalculateRowEnd(VisualBooking vb)
        {
            if (vb.EndHour < 8)
            {
                return 32;
                //TODO prone to failure
            }
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

        private void UserWeek_OnLoaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void GridMouseDown(object sender, MouseButtonEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
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
            decimal hourDecimal = row / 2 + 8;
            int hour = (int)Math.Floor(hourDecimal);

            DateTime day = _courtBookings.WeeklyBookingses.DailyBookingses[col].DayDateTime;
            //determine if it is "selectable"

            //if it is selectable, show a new window to do the booking

            //
        }
    }
}
