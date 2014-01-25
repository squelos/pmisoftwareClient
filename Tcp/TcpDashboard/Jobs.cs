using System.Threading;
using System.Threading.Tasks;
using TcpDashboard.ViewModel;

namespace TcpDashboard
{
    public class Jobs
    {
        #region privates

        private MainViewModel _mvm;
        private CalendarViewModel _calendarViewModel;
        private NewsViewModel _newsViewModel;
        private volatile bool _doJobs = false;
        private Task _refreshCalendarInfo;
        private Task _refreshNewsInfo;
        private Task _incrementNews;
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

        private void IncrementNews()
        {
            while (_doJobs)
            {
                Thread.Sleep(60000);
                _newsViewModel.Increment();
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
                    //we check to restart the threads if stopped

                }
            }
        }
        #endregion
    }
}