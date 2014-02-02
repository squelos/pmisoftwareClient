using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpDash.Business
{
    /// <summary>
    /// Class that contains the bookings of a specific day
    /// </summary>
    public class DailyBookings
    {
        #region privates

        private List<VisualBooking> _visualBookings = new List<VisualBooking>();
        private DateTime _dayDateTime;

        #endregion

        #region ctor

        public DailyBookings(DateTime day)
        {
            _dayDateTime = day;
        }

        #endregion

        #region getters/setters

        public List<VisualBooking> VisualBookingList
        {
            get { return _visualBookings; }
        }

        public DateTime DayDateTime
        {
            get { return _dayDateTime; }
            set { _dayDateTime = value; }
        }

        #endregion

        #region private Methods

        #endregion

        #region publics

        #endregion
    }
}