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
            _threadNewsChanger = new Thread(Start);
            _threadRun = true;
            _threadNewsChanger.Start();
        }

        private void Start()
        {
            int i = 0;
            int y = _newsCollection.Count;
            while (_threadRun)
            {
                Thread.Sleep(6000);
                CurrentNews = _newsCollection[i];
                i++;
                if (i == y)
                {
                    i = 0;
                }
            }
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

        #endregion

        public void Dispose()
        {
            _threadRun = false;
            
        }
    }
}