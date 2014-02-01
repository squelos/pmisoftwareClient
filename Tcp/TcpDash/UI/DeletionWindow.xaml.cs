using System;
using System.Linq;
using System.Windows;
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
            //try to delete
            _bm.DeleteBooking(_vb.Booking);
            //cant delete, show error

            //delete
            DialogResult = true;
            Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        public void Dispose()
        {
            _mvm.BadgeScanner.BadgeScanned -= OnBadgeScanned;
            // remove evepnt handler for the scan
        }
    }
}
