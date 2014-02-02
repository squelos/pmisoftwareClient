using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TcpDash.Business;
using TcpDash.Classes;
using TcpDash.ViewModel;
using TcpDataModel;

namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for DeletionWindow.xaml
    /// </summary>
    public partial class DeletionWindow : IDisposable
    {
        #region privates

        private VisualBooking _vb;
        private MainViewModel _mvm;
        private BookingManager _bm = BookingManager.Instance;
        private bool _canDelete = false;
        private Player _player;
        private int _working = 0;

        #endregion

        #region ctor

        public DeletionWindow(VisualBooking vb, MainViewModel mvm)
        {
            InitializeComponent();
            _vb = vb;
            _mvm = mvm;

            lDate.Content = _vb.Start.ToShortDateString();
            lCourt.Content = _vb.Booking.Court.number;
            string deb = _vb.StartHour + "h" + _vb.StartMin + "min";
            lStartTime.Content = deb;
            string end = _vb.EndHour + "h" + _vb.EndMin + "min";
            lEndTime.Content = end;
            lP1.Content = _vb.Booking.Player1;
            lP2.Content = _vb.Booking.Player2;
            _mvm.BadgeScanner.BadgeScanned += OnBadgeScanned;
        }

        private void OnBadgeScanned(int badgeId)
        {
            // here we get the user associated with the badge
            Player p = _bm.Players.FirstOrDefault(player => player.Badge.Any(badge => badge.number == badgeId));


            if (p != null)
            {
                // if the user is one of the players, he can delete    
                if (p.ID == _vb.Booking.Player1.ID || p.ID == _vb.Booking.Player2.ID)
                    CanDelete = true;
                if (p.Status.Id > 1)
                    CanDelete = true;
                // if the user is an admin, he can also delete
            }
        }

        #endregion

        #region publics

        #endregion

        #region events

        #endregion

        #region getters/setters

        public int Working
        {
            get { return _working; }
            set
            {
                _working = value;
                if (_working != 0)
                {
                    Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                        new ThreadStart(() => ProgressBar.Visibility = Visibility.Visible));
                }
                else
                {
                    Dispatcher.Invoke(DispatcherPriority.ApplicationIdle,
                        new ThreadStart(() => ProgressBar.Visibility = Visibility.Hidden));
                }
            }
        }

        #endregion

        #region private Methods

        #endregion

        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                _canDelete = value;
                UIDispatcher.Instance.BeginInvoke(() =>
                {
                    bDelete.IsEnabled = value;
                    Ring.IsActive = !value;
                    if (value)
                    {
                        TextBlock.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        TextBlock.Visibility = Visibility.Visible;
                    }
                });
            }
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            Working++;
            Task t = new Task(() =>
            {
                //TODO do this in another thread
                //try to delete
                _bm.DeleteBooking(_vb.Booking);
                //cant delete, show error

                //delete
                Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new ThreadStart(() =>
                {
                    DialogResult = true;
                    Close();
                }));
                Working--;
            });
            t.Start();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public void Dispose()
        {
            //_mvm.BadgeScanner.BadgeScanned -= OnBadgeScanned;
            // remove evepnt handler for the scan
        }

        private void DeletionWindow_OnClosing(object sender, CancelEventArgs e)
        {
            

            e.Cancel = _working != 0;
            if(!e.Cancel)
                _mvm.BadgeScanner.BadgeScanned -= OnBadgeScanned;
        }
    }
}