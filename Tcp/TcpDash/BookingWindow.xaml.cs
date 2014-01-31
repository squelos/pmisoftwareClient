using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using TcpDash.Business;
using TcpDash.ViewModel;
using TcpDataModel;

namespace TcpDash
{
    /// <summary>
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : IDisposable
    {
        #region privates

        private List<Player> _playerList;

        private List<int> _startHours = new List<int>();
        private List<int> _endHours = new List<int>();
        private List<int> _mins = new List<int>();

        private int _selectedStartHour;
        private int _selectedEndHour;
        private int _selectedStartMin;
        private int _selectedEndMin;

        private Player _firstPlayer;
        private Player _secondPlayer;
        private string _playerSearch;
        private bool _filmed = false;

        private BookingManager _bm = BookingManager.Instance;
        private Court _currentCourt;
        private DateTime _dayDate;
        private MainViewModel _mvm;

        private int _desiredHour;

        #endregion

        #region ctor
        public BookingWindow(Court c, DateTime d, MainViewModel mvm, int desiredHour)
        {
            InitializeComponent();

            int[] hours = new[] { 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            _startHours.AddRange(hours);

            int[] mins = new[] { 0, 30 };
            _mins.AddRange(mins);

            int[] endHours = new int[] { 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 0 };
            _endHours.AddRange(endHours);

            _currentCourt = c;
            _dayDate = d;
            _mvm = mvm;
            _desiredHour = desiredHour;
            _playerList = _bm.Players;

            cbEndHour.ItemsSource = _endHours;
            cbEndMin.ItemsSource = _mins;
            cbStartHour.ItemsSource = _startHours;
            cbStartHour.SelectedValue = desiredHour;
            cbEndHour.SelectedIndex = cbStartHour.SelectedIndex;
            cbEndMin.SelectedIndex = 0;

            cbStartMin.ItemsSource = _mins;
            cbStartMin.SelectedIndex = 0;
            cbSecondPlayer.ItemsSource = _playerList;

            lDate.Content = _dayDate.ToShortDateString();
            lTerrain.Content = _currentCourt.number;

            _mvm.BadgeScanner.BadgeScanned += BadgeScanner_BadgeScanned;
        }

        void BadgeScanner_BadgeScanned(int badgeId)
        {
            _firstPlayer = _bm.Players.FirstOrDefault(player => player.Badge.Any(badge => badge.ID == badgeId));
            lFirstPlayer.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                new ThreadStart(() =>
                {
                    if (_firstPlayer == null)
                    {
                        lFirstPlayer.Content = "Badge non assigné";
                    }
                    else
                    {
                        lFirstPlayer.Content = _firstPlayer;
                    }
                    ProgressRing.Visibility = Visibility.Collapsed;
                }));
        }

        #endregion

        #region getters/setters

        public List<Player> Players
        {
            get { return _playerList; }

        }
        #endregion

        #region publics

        #endregion


        #region events
        private void ValidateClick(object sender, RoutedEventArgs e)
        {

            //we try to book
            //first verify if all is filled
            //if not, show error message
            //for test only HACKS
            _firstPlayer = _secondPlayer;
            int result = _bm.TryBooking(_dayDate, _selectedStartHour, _selectedStartMin, _selectedEndHour,
                _selectedEndMin, _currentCourt, _firstPlayer, _secondPlayer, _filmed, null);
            //if not possible show error message

            //else : book and exit
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbStartHour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStartHour.SelectedValue != null) _selectedStartHour = (int)cbStartHour.SelectedValue;
        }

        private void CbStartMin_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStartMin.SelectedValue != null) _selectedStartMin = (int)cbStartMin.SelectedValue;
        }

        private void CbEndHour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEndHour.SelectedValue != null) _selectedEndHour = (int)cbEndHour.SelectedValue;
        }

        private void CbEndMin_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEndMin.SelectedValue != null) _selectedEndMin = (int)cbEndMin.SelectedValue;
        }

        private void CbSecondPlayer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSecondPlayer.SelectedValue != null) _secondPlayer = (Player)cbSecondPlayer.SelectedValue;
        }

        #endregion

        public void Dispose()
        {
            _mvm.BadgeScanner.BadgeScanned -= BadgeScanner_BadgeScanned;
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _playerSearch = sub.Text;


            if (_playerSearch.Length < 4)
            {
                cbSecondPlayer.ItemsSource = _playerList;
            }
            else
            {
                cbSecondPlayer.ItemsSource =
                    _playerList.Where(
                        player =>
                            player.firstName.Contains(_playerSearch) ||
                            player.lastName.Contains(_playerSearch));
                //cbSecondPlayer.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new ThreadStart(() => cbSecondPlayer.item))
            }
        }

        private void ToggleSwitch_OnChecked(object sender, RoutedEventArgs e)
        {
            _filmed = (bool) ToggleSwitch.IsChecked;
        }
    }
}
