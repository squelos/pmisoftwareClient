using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TcpDashboard.Business;


namespace TcpDashboard.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        #region privates

        private MainViewModel _mvm;
        private bool _weekMode = true;
        private bool _dayMode = false;
        private DateTime _selectedDay;
        private DateTime _firstDayOfWeek;
        private DateTime _lastDayOfWeek;
        private List<CourtBookings> _courtBookings = new List<CourtBookings>(); 

        #endregion
       

        #region ctor

        public CalendarViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
        }

        #endregion

        #region getters/setters

        public bool WeekMode
        {
            get { return _weekMode; }
            set
            {
                _weekMode = value;
                _dayMode = !value;
                RaisePropertyChanged("weekMode");
            }
        }

        public bool DayMode
        {
            get { return _dayMode; }
            set
            {
                _dayMode = value;
                _weekMode = !value; 
                RaisePropertyChanged("dayMode");
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
        #endregion

        #region commands

        #endregion

        #region privates

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