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
        
        #endregion
 
        #region ctor

        public WeeklyBookings(List<DailyBookings>  bList)
        {
            _dailyBookingses = bList;
        }
        #endregion

        #region getters/setters

        public List<DailyBookings> DailyBookingses
        {
            get { return _dailyBookingses; }
        }
        #endregion

        #region private Methods

        #endregion


        #region publics

        #endregion
    }
}
