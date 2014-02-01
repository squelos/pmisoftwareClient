using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDash.Business
{
    /// <summary>
    /// class that contains all the bookings of a week
    /// </summary>
    public class WeeklyBookings
    {
        #region privates

        private List<DailyBookings> _dailyBookingses;
        private DateTime _weekStart;
        private DateTime _weekEnd;

        #endregion

        #region ctor

        public WeeklyBookings(List<DailyBookings> bList, DateTime start, DateTime end)
        {
            _dailyBookingses = bList;
        }

        #endregion

        #region getters/setters

        public List<DailyBookings> DailyBookingses
        {
            get { return _dailyBookingses; }
        }

        public DateTime WeekStart
        {
            get { return _weekStart; }
            set { _weekStart = value; }
        }

        public DateTime WeekEnd
        {
            get { return _weekEnd; }
            set { _weekEnd = value; }
        }

        #endregion

        #region private Methods

        #endregion

        #region publics

        #endregion
    }
}