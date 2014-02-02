using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Odbc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using TcpDash.Business;
using TcpDash.Classes;
using TcpDash.ViewModel;
using TcpDataModel;

namespace TcpDash.UI
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
        private bool _firstScan = false;

        private BookingManager _bm = BookingManager.Instance;
        private Court _currentCourt;
        private DateTime _dayDate;
        private MainViewModel _mvm;

        private int _working = 0;

        private int _desiredHour;

        #endregion

        #region ctor

        public BookingWindow(Court c, DateTime d, MainViewModel mvm, int desiredHour)
        {
            InitializeComponent();

            int[] hours = new[] {8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23};
            _startHours.AddRange(hours);

            int[] mins = new[] {0, 30};
            _mins.AddRange(mins);

            int[] endHours = new int[] {9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 0};
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
            cbStartHour.SelectedValue = cbStartHour.SelectedValue;
            cbEndHour.SelectedIndex = cbStartHour.SelectedIndex;
            cbEndHour.SelectedValue = cbEndHour.SelectedValue;
            cbEndMin.SelectedIndex = 0;

            ucRecent.Changed += ucRecent_Changed;

            cbStartMin.ItemsSource = _mins;
            cbStartMin.SelectedIndex = 0;
            cbSecondPlayer.ItemsSource = _playerList;
            //cbSecondPlayer.SelectionChanged += cbSecondPlayer_SelectionChanged;

            lDate.Content = _dayDate.ToShortDateString();
            lTerrain.Content = _currentCourt.number;

            _mvm.BadgeScanner.BadgeScanned += BadgeScanner_BadgeScanned;
        }

        void ucRecent_Changed(object sender, Player player)
        {
            _secondPlayer = player;
            cbSecondPlayer.SelectedValue = player;
            cbSecondPlayer.Text = player.ToString();
        }

        //void cbSecondPlayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    _secondPlayer = 
        //}

        private void BadgeScanner_BadgeScanned(int badgeId)
        {
            if (!_firstScan)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                {
                    BeginStoryboard(FindResource("Storyboard1") as Storyboard);
                    _firstScan = true;
                }));

            }
            _firstPlayer = _bm.Players.FirstOrDefault(player => player.Badge.Any(badge => badge.number == badgeId));
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
                        ucRecent.FirstPlayer = _firstPlayer;
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

        public int Working
        {
            get { return _working; }
            set
            {
                _working = value;
                if (_working != 0)
                {
                    Dispatcher.Invoke(() => { ProgressBar.Visibility = Visibility.Visible; });
                }
                else
                {
                    Dispatcher.Invoke(() => { ProgressBar.Visibility = Visibility.Hidden; });
                }
            }
        }

        #endregion

        #region publics

        #endregion

        #region events

        private void ValidateClick(object sender, RoutedEventArgs e)
        {
            _selectedStartHour = (int) cbStartHour.SelectedValue;
            _selectedStartMin = (int) cbStartMin.SelectedValue;
            _selectedEndHour = (int) cbEndHour.SelectedValue;
            _selectedEndMin = (int) cbEndMin.SelectedValue;
            bool errors = false;
            //we try to book
            //first verify if all is filled
            //if not, show error message
            if (_dayDate < DateTime.Now.Date)
            {
                errors = true;
                UIDispatcher.Instance.ShowMessageDialog(this, "Erreur", "Impossible de réserver dans le passé");
            }
            if (_firstPlayer == null)
            {
                errors = true;
                UIDispatcher.Instance.ShowMessageDialog(this, "Erreur", "Aucun premier joueur n'est sélectionné");
                return;
            }
            if (_secondPlayer == null)
            {
                errors = true;
                UIDispatcher.Instance.ShowMessageDialog(this, "Erreur", "Aucun second joueur n'est sélectionné");
                return;
            }
            DateTime start = new DateTime(_dayDate.Year, _dayDate.Month, _dayDate.Day, _selectedStartHour,
                _selectedStartMin, 0);
            DateTime end = new DateTime(_dayDate.Year, _dayDate.Month, _dayDate.Day, _selectedEndHour, _selectedEndMin,
                0);
            if (start.AddHours(1) != end)
            {
                //then the first player must be an admin
                if (_firstPlayer.Status.Id < 2)
                {
                    errors = true;
                    UIDispatcher.Instance.ShowMessageDialog(this, "Erreur",
                        "Seul un administrateur peut effectuer des réservations de plus d'une heure");
                }
            }
            if (errors)
            {
                return;
            }

            Task t1 = new Task(() =>
            {
                Working++;
                //TODO split this in another thread
                int result = _bm.TryBooking(_dayDate, _selectedStartHour, _selectedStartMin, _selectedEndHour,
                    _selectedEndMin, _currentCourt, _firstPlayer, _secondPlayer, _filmed, null);
                //if not possible show error message
                Working--;

                switch (result)
                {
                    case 1:
                        UIDispatcher.Instance.ShowMessageDialog(this, "Réservation effectuée avec succès",
                            "Votre réservation a été effectuée avec succès");
                        Task t2 = new Task(() =>
                        {
                            Thread.Sleep(10000);
                            UIDispatcher.Instance.BeginInvoke(Close);
                        });
                        t2.Start();
                        break;
                    case 2:
                        UIDispatcher.Instance.ShowMessageDialog(this, "Echec", "Le terrain n'existe pas");
                        break;
                    case 3:
                        UIDispatcher.Instance.ShowMessageDialog(this, "Echec",
                            "Le quota de réservations pour la semaine a été dépassé");
                        break;
                    case 4:
                        UIDispatcher.Instance.ShowMessageDialog(this, "Echec",
                            "Une réservation sur ce créneau horaire est déjà existante");
                        break;
                    case 5:
                        UIDispatcher.Instance.ShowMessageDialog(this, "Echec",
                            "Un des joueurs n'a pas payé pour le semestre");
                        break;
                }
            });

            t1.Start();

            //else : book and exit
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CbStartHour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStartHour.SelectedValue != null)
            {
                _selectedStartHour = (int) cbStartHour.SelectedValue;
                cbEndHour.SelectedIndex = cbStartHour.SelectedIndex;
            }
        }

        private void CbStartMin_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbStartMin.SelectedValue != null) _selectedStartMin = (int) cbStartMin.SelectedValue;
        }

        private void CbEndHour_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEndHour.SelectedValue != null) _selectedEndHour = (int) cbEndHour.SelectedValue;
        }

        private void CbEndMin_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbEndMin.SelectedValue != null) _selectedEndMin = (int) cbEndMin.SelectedValue;
        }

        private void CbSecondPlayer_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSecondPlayer.SelectedValue != null) _secondPlayer = (Player) cbSecondPlayer.SelectedValue;
        }

        #endregion

        public void Dispose()
        {
            _mvm.BadgeScanner.BadgeScanned -= BadgeScanner_BadgeScanned;
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            //_playerSearch = sub.Text.ToLower();


            if (_playerSearch.Length < 4)
            {
                cbSecondPlayer.ItemsSource = _playerList;
            }
            else
            {
                Task t = new Task(() =>
                {
                    Working++;
                    Dispatcher.Invoke(() =>
                    {
                        cbSecondPlayer.ItemsSource =
                      _playerList.Where(
                          player =>
                              player.firstName.ToLower().Contains(_playerSearch) ||
                              player.lastName.ToLower().Contains(_playerSearch)).OrderBy(player => player.lastName);
                    });
                    Working--;
                });
                t.Start();
            }
        }

        private void ToggleSwitch_OnChecked(object sender, RoutedEventArgs e)
        {
            _filmed = (bool) ToggleSwitch.IsChecked;
        }

        private void BookingWindow_OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = _working != 0;
        }
    }
}