using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TcpDash.Classes;
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

        private static readonly Lazy<BookingManager> lazy = new Lazy<BookingManager>(() => new BookingManager());

        public static BookingManager Instance
        {
            get { return lazy.Value; }
        }

        private BookingManager()
        {
            Init();
        }

        #endregion

        #region privates

        private entityContainer _container = new entityContainer();
        private ObservableCollection<CourtBookings> _courtBookings;
        private List<Booking> _bookingSnapshot;
        private IQueryable<Booking> _proxiedBookings;
        private DateTime _startProxy;
        private DateTime _endProxy;

        private DateTime _selectedDay;
        private DateTime _firstDayOfWeek;
        private DateTime _lastDayOfWeek;

        private List<Player> _players;

        private int _working;

        #endregion

        #region getters/setters
        public int Working
        {
            get { return _working; }
            set
            {
                _working = value;
                RaiseWorkingChanged();
            }
        }

        public ObservableCollection<CourtBookings> CourtBookingses
        {
            get { return _courtBookings; }
            set
            {
                _courtBookings = value;
                // maybe raise something here ? 
            }
        }

        public List<Player> Players
        {
            get { return _players; }
            set { _players = value; }
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

            RefreshProxy();

            Refresh();
        }


        /// <summary>
        /// uses the data in the proxy
        /// </summary>
        /// <param name="cb"></param>
        private void FillCourtBooking(CourtBookings cb)
        {
            //in here we fill the courtBooking with the appropriate data (from the selected Day and week)
            //get  the relevant Bookings for each day of the week
            List<Booking> nonRecurring =
                (_proxiedBookings.Where(
                    booking =>
                        booking.Court.ID == cb.Court.ID &&
                        booking.start > _firstDayOfWeek &&
                        booking.end < _lastDayOfWeek)).Include(booking => booking.Player1)
                    .Include(booking => booking.Player2)
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
            WeeklyBookings wBookings = new WeeklyBookings(dBookings, _firstDayOfWeek.Date, _lastDayOfWeek.Date);
            cb.WeeklyBookingses = wBookings;

            //feed the dailyBookings into a weekly Booking
        }

        private void RefreshProxy()
        {
            DateTime minStart = DateTime.Now.AddDays(-14);
            DateTime maxDate = DateTime.Now.AddDays(20);
            _startProxy = minStart;
            _endProxy = maxDate;

            _container = new entityContainer();

            _proxiedBookings =
                _container.BookingJeu.Where(booking => booking.start > minStart && booking.start < maxDate);
            _players = _container.PlayerJeu.Include(player => player.Badge).Include(player => player.Status).ToList();
        }

        private void RefreshProxy(DateTime s, DateTime e)
        {
            _startProxy = s;
            _endProxy = e;

            _proxiedBookings =
                _container.BookingJeu.Where(booking => booking.start > s && booking.start < e);
        }

        #endregion

        #region events

        public delegate void ChangedEventHandler(object sender, EventArgs e);

        public delegate void WorkingEventHandler(object sender, int value);

        public event ChangedEventHandler Changed;
        public event WorkingEventHandler WorkingChanged;

        private void RaiseChanged()
        {
            if (Changed != null)
            {
                Changed(this, new EventArgs());
            }
        }

        private void RaiseWorkingChanged()
        {
            if (WorkingChanged != null)
            {
                WorkingChanged(this, _working);
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
            if (first < _startProxy || last > _endProxy)
            {
                RefreshProxy(first, last);
            }

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
            }
            //most fail code ever
            //lock (this)
            //{
            //    Working++;
            //    Task t = new Task(() =>
            //    {
            //        _selectedDay = selectedD;
            //        _firstDayOfWeek = first;
            //        _lastDayOfWeek = last;
            //        if (first < _startProxy || last > _endProxy)
            //        {
            //            RefreshProxy(first, last);
            //        }

            //        //must refresh the Data
            //        foreach (var bookingse in CourtBookingses)
            //        {
            //            int y = 0;
            //            foreach (var daily in bookingse.WeeklyBookingses.DailyBookingses)
            //            {
            //                daily.DayDateTime = _firstDayOfWeek.AddDays(y);
            //                y++;
            //            }
            //            FillCourtBooking(bookingse);
            //        }
            //        Working--;
            //    });
            //    t.Start();
            //}

        }

        /// <summary>
        /// this method should refresh the proxy
        /// </summary>
        public void Refresh()
        {
            if (UIDispatcher.Instance.GetMainWindow == null)
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
                    CourtBookingses = new ObservableCollection<CourtBookings>(tmpBookings);
                }
                RefreshProxy();
                RaiseChanged();

                return;
            }
            UIDispatcher.Instance.GetMainWindow.Dispatcher.Invoke(() =>
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
                    CourtBookingses = new ObservableCollection<CourtBookings>(tmpBookings);
                }
                RefreshProxy();
                RaiseChanged();
            });
        }

        public int TryBooking(DateTime day, int sHour, int sMin, int eHour, int eMin, Court court, Player p1, Player p2,
            bool filmed, int? bookingAggregId)
        {
            DateTime start = new DateTime(day.Year, day.Month, day.Day, sHour, sMin, 0);
            DateTime end = new DateTime(day.Year, day.Month, day.Day, eHour, eMin, 0);
            if (eHour < 8)
            {
                end.AddDays(1);
            }
            var res = _container.tryPeriodBooking("Perso", false, start, end, filmed, bookingAggregId, court.ID, p1.ID,
                p2.ID);

            int ret = (int)res.FirstOrDefault();
            if (ret == 1)
            {
                Refresh();
            }


            return ret;
        }

        public bool DeleteBooking(Booking b)
        {
            bool ret = false;
            var bToDelete = _container.BookingJeu.First(booking => booking.ID == b.ID);
            //TODO Crash
            _container.BookingJeu.Remove(bToDelete);
            _container.SaveChanges();
            Refresh();
            ret = true;
            return ret;
        }

        #endregion
    }
}
