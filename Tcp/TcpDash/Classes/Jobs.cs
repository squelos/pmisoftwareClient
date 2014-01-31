using System.Threading;
using System.Threading.Tasks;
using TcpDash.Business;
using TcpDash.ViewModel;

namespace TcpDash.Classes
{
    public class Jobs
    {
        #region privates

        private MainViewModel _mvm;
        private CalendarViewModel _calendarViewModel;
        private NewsViewModel _newsViewModel;
        private BookingManager _bookingManager = BookingManager.Instance;
        private volatile bool _doJobs = false;
        private Task _refreshCalendarInfo;
        private Task _refreshNewsInfo;
        private Task _incrementNews;
        private Task _proxyRefresh;
        private Task _rotateDate;

        #endregion

        #region ctor

        public Jobs(CalendarViewModel calendar, NewsViewModel newsVm, MainViewModel mvm)
        {
            _mvm = mvm;
            _calendarViewModel = calendar;
            _newsViewModel = newsVm;
            _refreshCalendarInfo = new Task(RefreshCalendar);
            _refreshNewsInfo = new Task(RefreshNews);
            _incrementNews = new Task(IncrementNews);
            _proxyRefresh = new Task(ProxyRefresh);
            _rotateDate = new Task(RotateDate);
            
            //we also have to start refreshing the booking manager
            //TODO refresh the booking Manager from time to time
            //TODO force the booking manager to fetch for new courts
        }

        #endregion

        #region getters/setters


        #endregion

        #region commands

        #endregion

        #region privates
        private void RefreshNews()
        {
            while (_doJobs)
            {
                Thread.Sleep(300000);
                _newsViewModel.Refresh();
            }
        }

        private void RefreshCalendar()
        {
            while (_doJobs)
            {
                Thread.Sleep(150000);
                _calendarViewModel.Refresh();
            }
        }

        private void RefreshBookingManager()
        {
            while (_doJobs)
            {
                Thread.Sleep(300000);
                _bookingManager.Refresh();
            }
        }

        private void IncrementNews()
        {
            while (_doJobs)
            {
                Thread.Sleep(60000);
                _newsViewModel.Increment();
            }
        }

        private void ProxyRefresh()
        {
            while (_doJobs)
            {
                Thread.Sleep(120000);
                _bookingManager.Refresh();
            }
        }

        private void RotateDate()
        {
            while (_doJobs)
            {
                Thread.Sleep(60000);
                //TODO refresh date
            }
        }

        #endregion

        #region publics

        public bool DoJobs
        {
            get { return _doJobs; }
            set
            {
                _doJobs = value;
                if (value)
                {
                    switch (_incrementNews.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            {
                                _incrementNews = new Task(IncrementNews);
                                _incrementNews.Start();
                                break;
                            }
                        case TaskStatus.Created:
                            {
                                _incrementNews.Start();
                                break;
                            }
                    }
                    switch (_refreshCalendarInfo.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            {
                                _refreshCalendarInfo = new Task(RefreshCalendar);
                                _refreshCalendarInfo.Start();
                                break;
                            }
                        case TaskStatus.Created:
                            {
                                _refreshCalendarInfo.Start();
                                break;
                            }
                    }
                    switch (_refreshNewsInfo.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            {
                                _refreshNewsInfo = new Task(RefreshNews);
                                _refreshNewsInfo.Start();
                                break;
                            }
                        case TaskStatus.Created:
                            {
                                _refreshNewsInfo.Start();
                                break;
                            }
                    }
                    switch (_proxyRefresh.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            {
                                _proxyRefresh = new Task(ProxyRefresh);
                                _proxyRefresh.Start();
                                break;
                            }
                        case TaskStatus.Created:
                            {
                                _proxyRefresh.Start();
                                break;
                            }
                    }
                    switch (_rotateDate.Status)
                    {
                        case TaskStatus.RanToCompletion:
                            {
                                _rotateDate = new Task(RotateDate);
                                _rotateDate.Start();
                                break;
                            }
                        case TaskStatus.Created:
                            {
                                _rotateDate.Start();
                                break;
                            }
                    }
                    //we check to restart the threads if stopped

                }
            }
        }
        #endregion
    }
}