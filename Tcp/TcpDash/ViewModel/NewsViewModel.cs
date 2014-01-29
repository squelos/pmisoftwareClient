using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDataModel;

namespace TcpDash.ViewModel
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

        private RelayCommand _incrementCommand;
        private RelayCommand _decrementCommand;

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
            _currentNews = _newsCollection.FirstOrDefault();
            //TODO Crashes because CurrentNews is null
            _incrementCommand = new RelayCommand(Increment);
            _decrementCommand = new RelayCommand(Decrement);
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

        public ICommand DecrementCommand
        { get { return _decrementCommand; } }

        public ICommand IncrementCommand
        { get { return _incrementCommand; } }
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
            if (_newsI < RecentNews.Count - 1)
            {
                _newsI++;
                CurrentNews = RecentNews[_newsI];
            }
            else
            {
                _newsI = 0;
            }
        }
        public void Decrement()
        {
            //if the recentNews contains nothing
            if (RecentNews.Count == 0)
            {
                return;
            }
            if (_newsI > 0)
            {
                _newsI--;
                CurrentNews = RecentNews[_newsI];
            }
            else
            {
                _newsI = RecentNews.Count - 1;
            }
            CurrentNews = RecentNews[_newsI];
        }
        #endregion

        public void Dispose()
        {
            _threadRun = false;

        }
    }
}