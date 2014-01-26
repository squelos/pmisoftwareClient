using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure.DependencyResolution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _firstDayOfWeek = DateTime.Now.StartOfWeek();
            _lastDayOfWeek = DateTime.Now.StartOfWeek().AddDays(6);

            using (entityContainer container = new entityContainer())
            {
                List<Court> tmpList = (from b in container.CourtJeu select b).ToList();
                List<CourtBookings> tmpBookings = new List<CourtBookings>();
                foreach (var court in tmpList)
                {
                    tmpBookings.Add(new CourtBookings(court));
                }
                // we must fill the tmpBookings with the real bookings

                
                CourtBookingses = new ObservableCollection<CourtBookings>(tmpBookings);
            }
        }

        private void Refresh()
        {
            
        }

        private void FillCourtBooking(CourtBookings cb)
        {
            //in here we fill the courtBooking with the appropriate data (from the selected Day and week)
        }

        #endregion

        #region events

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
        }
        #endregion
    }
}
