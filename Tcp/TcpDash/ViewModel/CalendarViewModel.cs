using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDash.Business;
using TcpDataModel;

namespace TcpDash.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        #region privates

        private MainViewModel _mvm;
        private bool _weekMode = true;

        private DateTime _selectedDay;
        private DateTime _firstDayOfWeek;
        private DateTime _lastDayOfWeek;
        private BookingManager _bookingManager = BookingManager.Instance;
        private int _working = 0;
        private readonly RelayCommand _incrementDateCommand;
        private readonly RelayCommand _decrementDateCommand;

        #endregion

        #region ctor

        public CalendarViewModel(MainViewModel mvm)
        {
            _mvm = mvm;

            _incrementDateCommand = new RelayCommand(IncrementDate);
            _decrementDateCommand = new RelayCommand(DecrementDate);

            //get the court bookings from the BM 

            // subscribe to Court Bookings changes from the manager
            //if the court bookings change, refresh
            _bookingManager.Changed += (sender, args) => RaisePropertyChanged("bookingManager");

        }

        #endregion

        #region getters/setters

        public bool WeekMode
        {
            get { return _weekMode; }
            set
            {
                _weekMode = value;
                RaisePropertyChanged("weekMode");
            }
        }

        public DateTime SelectedDay
        {
            get { return _selectedDay; }
            set
            {
                _selectedDay = value;
                _firstDayOfWeek = DateTime.Now.StartOfWeek();
                _lastDayOfWeek = DateTime.Now.StartOfWeek().AddDays(6);
                BookingManager.SelectedDateChanged(_selectedDay,_firstDayOfWeek,_lastDayOfWeek);
                RaisePropertyChanged("selectedDay");
            }
        }

        public DateTime FirstDayOfSelectedWeek
        {
            get { return _firstDayOfWeek; }
        }

        public DateTime LastDayOfSelectedWeek
        {
            get { return _lastDayOfWeek; }
        }

        public BookingManager BookingManager
        {
            get { return _bookingManager; }
        }

        public ICommand DecrementCommand
        {
            get { return _decrementDateCommand; }
        }

        public ICommand IncrementCommand
        {
            get { return _incrementDateCommand; }
        }
        #endregion

        #region commands

        #endregion


        #region events

        public delegate void CourtNumberEventHandler(object sender, EventArgs e);
        public event CourtNumberEventHandler CourtNumberChanged;
        private void RaiseCourtNumberChanged()
        {
            if (CourtNumberChanged != null)
            {
                CourtNumberChanged(this, new EventArgs());
            }
        }

        

        #endregion

        #region privates

        private void IncrementDate()
        {
            SelectedDay = SelectedDay.AddDays(1);
        }

        private void DecrementDate()
        {
            SelectedDay = SelectedDay.AddDays(-1);
        }

        #endregion

        #region publics
        public void Refresh()
        {
            //throw new NotImplementedException();
        }

        public void RefreshManagers()
        {

        }
        #endregion
    }
}