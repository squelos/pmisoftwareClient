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

        private List<VisualBooking> _visualBookings;

        #endregion

        #region ctor

        public DailyBookings()
        {

        }
        #endregion

        #region getters/setters

        public List<VisualBooking> VisualBookingList
        {
            get { return _visualBookings; }
        }

        #endregion

        #region private Methods

        #endregion


        #region publics

        #endregion
    }
}
