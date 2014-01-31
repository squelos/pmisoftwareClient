using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpDataModel;

namespace TcpDash.Business
{
    public class VisualBooking
    {
        #region privates

        private bool _special = false;
        private bool _filmed = false;
        private bool _aggregated = false;
        private DateTime _start;
        private DateTime _end;
        private string _name;
        private Booking _booking;
        
        #endregion

        #region ctor

        public VisualBooking()
        {

        }
        /// <summary>
        /// ctor that creates a VisualBooking from a booking
        /// </summary>
        /// <param name="b"></param>
        public VisualBooking(Booking b)
        {
            _booking = b;
            //we create a Visual Booking from a booking coming from the DataModel
            if (b.BookingAggregation == null)
            {
                // then its a regular booking
                _name = b.Player1.firstName.First() + " " + b.Player1.lastName +  " vs " + b.Player2.firstName.First() +
                        " " + b.Player2.lastName;
                _special = false;
                _start = b.start;
                _end = b.end;
                
            }
            else
            {
                //TODO handle reccuring bookings
                _name = b.BookingAggregation.name;
                _special = true;
            }
            _filmed = b.Filmed;
        }
        #endregion

        #region getters/setters

        public bool IsSpecial
        {
            get { return _special; }
            set { _special = value; }
        }

        public bool IsFilmed
        {
            get { return _filmed; }
            set
            {
                _filmed = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Aggregated
        {
            get { return _aggregated; }
            set { _aggregated = value; }
        }

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }

        public int StartHour
        {
            get { return _start.Hour; }
        }

        public int StartMin
        {
            get { return _start.Minute; }
        }

        public int EndHour
        {
            get { return _end.Hour; }
        }

        public int EndMin
        {
            get { return _end.Minute; }
        }

        public Booking Booking
        {
            get { return _booking; }
        }
        #endregion

        #region private Methods

        #endregion


        #region publics

        #endregion
    }
}
