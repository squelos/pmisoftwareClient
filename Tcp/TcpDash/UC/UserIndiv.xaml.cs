using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MahApps.Metro.Controls;
using TcpDash.Classes;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserIndiv.xaml
    /// </summary>
    public partial class UserIndiv : UserControl
    {
        private MainViewModel _mvm;
        private TouchPoint _touchStart;
        private SwipeHelper _helper = new SwipeHelper();

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

        private void CalendarViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //we refresh the tabs and their contents
            //this shows a weekly planning for each court in a different tab
            animatedTab.Items.Clear();
            foreach (var courtBookingse in _mvm.CalendarViewModel.BookingManager.CourtBookingses)
            {
                TabItem ti = new MetroTabItem(animatedTab);
                UserWeek uWeek = new UserWeek(_mvm);

                //feed a CourtBooking
                uWeek.CourtB = courtBookingse;
                ti.Header = courtBookingse.Court.number;
                ti.Content = uWeek;
                animatedTab.Items.Add(ti);
            }
        }

        private void AnimatedTab_OnTouchMove(object sender, TouchEventArgs e)
        {
            if (!_helper.Swipped)
            {
                var Touch = e.GetTouchPoint(this);
                //right now a swipe is 200 pixels 

                //Swipe Left
                if (_touchStart != null && Touch.Position.X > (_touchStart.Position.X + 200))
                {
                    //swipe left

                    animatedTab.PreviousTab();
                    _helper.Swipped = true;
                }

                //Swipe Right

                if (_touchStart != null && Touch.Position.X < (_touchStart.Position.X - 200))
                {
                    //swipe right
                    animatedTab.NextTab();
                    _helper.Swipped = true;
                }
            }
            e.Handled = false;
        }

        private void AnimatedTab_OnTouchDown(object sender, TouchEventArgs e)
        {
            _touchStart = e.GetTouchPoint(this);
        }
    }
}