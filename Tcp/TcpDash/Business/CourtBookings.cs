using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpDataModel;

namespace TcpDash.Business
{
    public class CourtBookings : ViewModelBase
    {
        #region privates

        private WeeklyBookings _selectedWeeklyBookings;
        private Court _court;

        #endregion

        #region ctor

        public CourtBookings(Court court)
        {
            _court = court;
        }
        #endregion

        #region getters/setters


        public Court Court
        {
            get { return _court; }
        }

        public WeeklyBookings WeeklyBookingses
        {
            get
            {
                return _selectedWeeklyBookings;
            }
            set
            {
                _selectedWeeklyBookings = value;
                RaisePropertyChanged("weeklyBookings");
            }
        }



        #endregion

        #region events
        #endregion

        #region private Methods

        #endregion


        #region publics

        #endregion
    }
}
