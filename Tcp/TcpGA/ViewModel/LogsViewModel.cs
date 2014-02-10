using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpGA.BaseClasses;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.SqlServer;


namespace TcpGA.ViewModel
{
    public class LogsViewModel : ViewModelBase
    {
        #region members

        private ObservableCollection<LogEntry> _logEntries = new ObservableCollection<LogEntry>();
        private LogEntry _selectedLogEntry;
        private LogEntry _logEntry;
        private DateTime _startDate;
        private DateTime _endDate;

        private int _itemsPerPage = 30;
        private int _currentPage;
        private int _lastPage;
        private string _playerSearch = "";
        //private string _dateSearch;
        private string _readerSearch = "";
        private string _tagSearch = "";
        public ICommand _previousPageCommand;
        public ICommand _nextPageCommand;
        public ICommand _firstPageCommand;
        public ICommand _lastPageCommand;


        private MainViewModel _mvm;

        #endregion

        #region ctor
        public LogsViewModel(MainViewModel mvm)
        {
            _mvm = mvm;

            _endDate = DateTime.Now;
            _startDate = _endDate.AddDays(-2);

            _logEntries.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        Container.LogEntry.Remove(old as LogEntry);
                    }
                }
                RaisePropertyChangedEvent("badges");
            };

            _lastPage = 1;
            CurrentPage = 1;
            _firstPageCommand = new RelayCommand(() => ChangePage(1));
            _lastPageCommand = new RelayCommand(() => ChangePage(LastPage));
            _nextPageCommand = new RelayCommand(() => ChangePage(CurrentPage+1));
            _previousPageCommand = new RelayCommand(() => ChangePage(CurrentPage-1));

            InitialiseLogEntries();

        }
        #endregion

        #region getters/setters
        public LogEntry CurrentLogEntry
        {
            get { return _logEntry; }
            set
            {
                _logEntry = value;
                RaisePropertyChangedEvent("currentLogEntry");
            }
        }


        public LogEntry SelectedLogEntry
        {
            get { return _selectedLogEntry; }
            set
            {
                _selectedLogEntry = value;
                RaisePropertyChangedEvent("selectedLogEntry");
            }
        }


        public string PlayerSearch
        {
            get { return _playerSearch; }
            set
            {
                _playerSearch = value;
                CurrentPage = 1;
            }
        }

        public string ReaderSearch
        {
            get { return _readerSearch; }
            set
            {
                _readerSearch = value;
                CurrentPage = 1;
            }
        }

        public string TagSearch
        {
            get { return _tagSearch; } 
            
            set
            {
                _tagSearch = value;
                CurrentPage = 1;
            }
        }

        public ObservableCollection<LogEntry> LogEntries
        {
            get { return _logEntries; }
            set
            {
                _logEntries = value;
                RaisePropertyChangedEvent("logEntries");
            }
        }

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (!(value < 1 || value > LastPage))
                {
                    _currentPage = value;
                    RaisePropertyChangedEvent("CurrentPage");
                    UpdateData();
                }
            }
        }

        public int LastPage {
            get { return _lastPage; }
            set { _lastPage = value; } 
            }

        public DateTime StartDate {
            get { return _startDate; }
            set 
            { 
                _startDate = value;
                RaisePropertyChangedEvent("StartDate");
                UpdateData();
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                RaisePropertyChangedEvent("EndDate");
                UpdateData();
            }
        }

        public ICommand PreviousPageCommand
        {
            get { return _previousPageCommand; } 
        }

        public ICommand NextPageCommand
        {
            get { return _nextPageCommand; }
        }

        public ICommand FirstPageCommand
        {
            get { return _firstPageCommand; } 
        }

        public ICommand LastPageCommand
        {
            get { return _lastPageCommand; }
        }

        #endregion


        #region public methods
        public void Save()
        {
            Container.LogEntry.Add(_logEntry);
            _logEntries.Add(_logEntry);
            InitialiseLogEntries();
            Update();
        }

        public void Update()
        {
            CommitChanges();
        }

        public void Cancel()
        {
            ResetContainer();
            CurrentLogEntry = new LogEntry();
            _logEntries = new ObservableCollection<LogEntry>(Container.LogEntry);
            RaisePropertyChangedEvent("container");
        }   
        #endregion

        #region privates
        private void InitialiseLogEntries()
        {
            _logEntry = new LogEntry();
            CurrentLogEntry = _logEntry;
        }

        private void ChangePage(int pageNumber)
        {
            CurrentPage = pageNumber;
        }

        private void UpdateFilteredCollection()
        {
         /*   _logEntries.Clear();
            var foundEntries = _data.FindAll(
                entry => ((_playerSearch == "" && entry.PlayerJeu == null) || 
                    entry.PlayerJeu != null && (entry.PlayerJeu.firstName.ToLower().Contains(_playerSearch.ToLower()) || entry.PlayerJeu.lastName.ToLower().Contains(_playerSearch.ToLower()))
                    )
                && entry.reader_name.ToLower().Contains(_readerSearch)
                && entry.tag_number.ToString().Contains(_tagSearch));

            foreach (var item in foundEntries)
            {
                _logEntries.Add(item);
            }

            LastPage = (int)(_logEntries.Count / _itemsPerPage);
            LastPage = _lastPage == 0 ? 1 : _lastPage;
            if (_logEntries.Count > 30)
                LastPage = LastPage % _itemsPerPage != 0 ? LastPage + 1 : LastPage;

            RaisePropertyChangedEvent("logEntries");
            RaisePropertyChangedEvent("LastPage");*/
        }

        private void UpdateData()
        {
            _logEntries = new ObservableCollection<LogEntry>((from l in Container.LogEntry
                     join p in Container.PlayerJeu on l.Player_ID equals p.ID into g from p in g.DefaultIfEmpty()
                     orderby l.timestamp
                     where (l.timestamp >= StartDate && l.timestamp <= EndDate) 
                        && ((_playerSearch == "") || l.PlayerJeu != null && (l.PlayerJeu.firstName.ToLower().Contains(_playerSearch.ToLower()) || l.PlayerJeu.lastName.ToLower().Contains(_playerSearch.ToLower()))
                        && l.reader_name.ToLower().Contains(_readerSearch)
                        && SqlFunctions.StringConvert((double)l.tag_number).Contains(_tagSearch))
                     select l).Skip((CurrentPage-1)*_itemsPerPage).Take(_itemsPerPage).ToList<LogEntry>());

            int count = (from l in Container.LogEntry
                         join p in Container.PlayerJeu on l.Player_ID equals p.ID into g
                         from p in g.DefaultIfEmpty()
                         orderby l.timestamp
                         where (l.timestamp >= StartDate && l.timestamp <= EndDate)
                            && ((_playerSearch == "") || l.PlayerJeu != null && (l.PlayerJeu.firstName.ToLower().Contains(_playerSearch.ToLower()) || l.PlayerJeu.lastName.ToLower().Contains(_playerSearch.ToLower()))
                            && l.reader_name.ToLower().Contains(_readerSearch)
                            && SqlFunctions.StringConvert((double)l.tag_number).Contains(_tagSearch))
                         select l).Count();

            LastPage = (int)(count / _itemsPerPage);
            LastPage = _lastPage == 0 ? 1 : _lastPage;
            if (count > 30)
                LastPage = LastPage % _itemsPerPage != 0 ? LastPage + 1 : LastPage;

            RaisePropertyChangedEvent("LogEntries");
            RaisePropertyChangedEvent("LastPage");

        }
        #endregion



    }
}
