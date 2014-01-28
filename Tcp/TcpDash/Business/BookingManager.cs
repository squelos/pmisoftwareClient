using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TcpDataModel;
using TcpDash.ViewModel;

namespace TcpDash.Business
{
    /// <summary>
    /// Class that manages the bookings, simplifying the querying and acting as a simple proxy
    /// </summary>
    public sealed class BookingManager
    {
        #region singleton
        private static readonly  Lazy<BookingManager> lazy = new Lazy<BookingManager>(() => new BookingManager());
        public static BookingManager Instance
        { get { return lazy.Value; } }
        private BookingManager()
        {
           Init();
        }

        #endregion

        #region privates
        private entityContainer _container = new entityContainer();
        private ObservableCollection<CourtBookings> _courtBookings;
        private List<Booking> _bookingSnapshot; 

        private DateTime _selectedDay;
        private DateTime _firstDayOfWeek;
        private DateTime _lastDayOfWeek;

        #endregion

        #region getters/setters

        public ObservableCollection<CourtBookings> CourtBookingses
        {
            get { return _courtBookings; }
            set
            {
                _courtBookings = value; 
                // maybe raise something here ? 
            }
        }

        #endregion

        #region private Methods

        /// <summary>
        /// Initializes the booking Manager
        /// </summary>
        private void Init()
        {
            _selectedDay = DateTime.Now;
            _firstDayOfWeek = Utility.GetFirst(_selectedDay);
            _lastDayOfWeek = _firstDayOfWeek.AddDays(6);

            Refresh();
        }

        

        private void FillCourtBooking(CourtBookings cb)
        {
            //in here we fill the courtBooking with the appropriate data (from the selected Day and week)
            //get  the relevant Bookings for each day of the week
            //TODO cache in order to improve performance
            List<Booking> nonRecurring =
                (_container.BookingJeu.Where(
                    booking =>
                        booking.Court.ID == cb.Court.ID && booking.BookingAggregation == null &&
                        booking.start > _firstDayOfWeek &&
                        booking.end < _lastDayOfWeek)).Include(booking => booking.Player1).Include(booking => booking.Player2)
                        .Include(booking => booking.BookingAggregation).ToList();

            //transform them into Visual Bookings
            List<VisualBooking> vbList = new List<VisualBooking>();
            foreach (Booking booking in nonRecurring)
            {
                vbList.Add(new VisualBooking(booking));
            }
            //group them into Daily Bookings
            //first we get all the days we need
            List<DateTime> days = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                days.Add(_firstDayOfWeek.AddDays(i).Date);
            }
            List<DailyBookings> dBookings = new List<DailyBookings>();
            foreach (var dateTime in days)
            {
                DailyBookings tmp = new DailyBookings(dateTime.Date);
                var res = vbList.Where(booking => booking.Start.Date == dateTime).ToList();
                if (res.Count != 0)
                {
                    tmp.VisualBookingList.AddRange(res);    
                }
                
                dBookings.Add(tmp);
            }
            WeeklyBookings wBookings = new WeeklyBookings(dBookings, _firstDayOfWeek.Date,_lastDayOfWeek.Date);
            cb.WeeklyBookingses = wBookings;

            //feed the dailyBookings into a weekly Booking
        }

        #endregion

        #region events

        public delegate void ChangedEventHandler(object sender, EventArgs e);

        public event ChangedEventHandler Changed;

        private void RaiseChanged()
        {
            if (Changed != null)
            {
                Changed(this, new EventArgs());
            }
        }

        #endregion

        #region publics
        /// <summary>
        ///  Call this method when the selected date has changed
        /// </summary>
        public void SelectedDateChanged(DateTime selectedD, DateTime first, DateTime last)
        {
            _selectedDay = selectedD;
            _firstDayOfWeek = first;
            _lastDayOfWeek = last;

            //must refresh the Data
            foreach (var bookingse in CourtBookingses)
            {
                int y = 0;
                foreach (var daily in bookingse.WeeklyBookingses.DailyBookingses)
                {
                    daily.DayDateTime = _firstDayOfWeek.AddDays(y);
                    y++;
                }
                FillCourtBooking(bookingse);
            
                //TODO bug here
            }
            
            
        }

        public void Refresh()
        {
            using (entityContainer container = new entityContainer())
            {
                List<Court> tmpList = (from b in container.CourtJeu select b).ToList();
                List<CourtBookings> tmpBookings = new List<CourtBookings>();
                foreach (var court in tmpList)
                {
                    tmpBookings.Add(new CourtBookings(court));
                }
                // we must fill the tmpBookings with the real bookings
                foreach (CourtBookings tmpBooking in tmpBookings)
                {
                    FillCourtBooking(tmpBooking);
                }
                //TODO grab a snapshot of the DB for the caching
                CourtBookingses = new ObservableCollection<CourtBookings>(tmpBookings);
            }
            RaiseChanged();
        }
        #endregion
    }
}
