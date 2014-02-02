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


namespace TcpGA.ViewModel
{
    public class LogsViewModel : ViewModelBase
    {
        #region members

        private List<LogEntry> _data;
        private ObservableCollection<LogEntry> _logEntries = new ObservableCollection<LogEntry>();
        private LogEntry _selectedLogEntry;
        private LogEntry _logEntry;
        private string _playerSearch = "";
        //private string _dateSearch;
        private string _readerSearch = "";
        private string _tagSearch = "";


        private MainViewModel _mvm;

        #endregion

        #region ctor
        public LogsViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            
            _data = new List<LogEntry>(Container.LogEntry.Include(logEntry => logEntry.PlayerJeu));
            _logEntries = new ObservableCollection<LogEntry>(Container.LogEntry.Include(logEntry => logEntry.PlayerJeu));

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
                UpdateFilteredCollection();
            }
        }

        public string ReaderSearch
        {
            get { return _readerSearch; }
            set
            {
                _readerSearch = value;
                UpdateFilteredCollection();
            }
        }

        public string TagSearch
        {
            get { return _tagSearch; } 
            
            set
            {
                _tagSearch = value;
                UpdateFilteredCollection();
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


        private void UpdateFilteredCollection()
        {
            _logEntries.Clear();
            var foundEntries = _data.FindAll(
                entry => (entry.PlayerJeu.firstName.ToLower().Contains(_playerSearch.ToLower()) || entry.PlayerJeu.lastName.ToLower().Contains(_playerSearch.ToLower()))
                && entry.reader_name.ToLower().Contains(_readerSearch)
                && entry.tag_number.ToString().Contains(_tagSearch));

            foreach (var item in foundEntries)
            {
                _logEntries.Add(item);
            }

            RaisePropertyChangedEvent("logEntries");
        }
        #endregion


    }
}
