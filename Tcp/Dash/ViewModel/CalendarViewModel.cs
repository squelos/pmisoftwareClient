using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Dash.Business;
using TcpDataModel;


namespace Dash.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        #region privates

        private MainViewModel _mvm;
        private bool _weekMode = true;

        private DateTime _selectedDay;
        private DateTime _firstDayOfWeek;
        private DateTime _lastDayOfWeek;
        private ObservableCollection<CourtBookings> _courtBookings = new ObservableCollection<CourtBookings>();
        private BookingManager _bookingManager;
        private RelayCommand _incrementDateCommand;
        private RelayCommand _decrementDateCommand;

        #endregion


        #region ctor

        public CalendarViewModel(MainViewModel mvm)
        {
            _mvm = mvm;

            _incrementDateCommand = new RelayCommand(IncrementDate);
            _decrementDateCommand = new RelayCommand(DecrementDate);

            _bookingManager = new BookingManager();
            using (entityContainer container = new entityContainer())
            {
                List<Court> tmpList = (from b in container.CourtJeu select b).ToList();
                List<CourtBookings> tmpBookings = new List<CourtBookings>();
                foreach (var court in tmpList)
                {
                    tmpBookings.Add(new CourtBookings(court));
                }
                CourtBookings = new ObservableCollection<CourtBookings>(tmpBookings);
            }

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

        public ObservableCollection<CourtBookings> CourtBookings
        {
            get { return _courtBookings; }
            set
            {
                _courtBookings = value;
                RaisePropertyChanged("courtBookings");
            }
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