using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using TcpDataModel;

namespace TcpDashboard.ViewModel
{
    public class NewsViewModel : ViewModelBase, IDisposable
    {
        #region privates

        private MainViewModel _mvm;
        private ObservableCollection<News> _newsCollection;
        private entityContainer _container = new entityContainer();
        private News _currentNews;
        private Thread _threadNewsChanger;
        private bool _threadRun = false;
        private bool _refreshThread = false;
        private int _newsI = 0;

        #endregion

        #region ctor

        public NewsViewModel(MainViewModel mvm)
        {
            DateTime now = DateTime.Now.AddMonths(-2);
            _mvm = mvm;
            _newsCollection =
                new ObservableCollection<News>(
                    _container.NewsSet.Where(news => news.Visibility && news.PublishDate > now)
                        .OrderByDescending(news => news.PublishDate)
                        .Take(15));
            _currentNews = _newsCollection.First();
           
        }

      

        #endregion

        #region getters/setters

        public ObservableCollection<News> RecentNews
        {
            get { return _newsCollection; }
            set
            {
                _newsCollection = value;
                RaisePropertyChanged("newsCollection");
            }
        }

        public News CurrentNews
        {
            get { return _currentNews; }
            set
            {
                _currentNews = value;
                RaisePropertyChanged("currentNews");
            }

        }
        #endregion

        #region commands

        #endregion

        #region privates
        
        #endregion

        #region publics

        public void Refresh()
        {
            DateTime now = DateTime.Now.AddMonths(-2);
            RecentNews = new ObservableCollection<News>(
                    _container.NewsSet.Where(news => news.Visibility && news.PublishDate > now)
                        .OrderByDescending(news => news.PublishDate)
                        .Take(15));
        }

        public void Increment()
        {
            //if the recentNews contains nothing
            if (RecentNews.Count == 0)
            {
                return;
            }
            if (_newsI < RecentNews.Count-1)
            {
                _newsI++;
                CurrentNews = RecentNews[_newsI];
            }
            else
            {
                _newsI = 0;
            }
        }
        #endregion

        public void Dispose()
        {
            _threadRun = false;
            
        }
    }
}