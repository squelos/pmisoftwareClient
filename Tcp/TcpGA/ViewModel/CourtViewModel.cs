using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpGA.BaseClasses;


namespace TcpGA.ViewModel
{
    public class CourtViewModel : ViewModelBase
    {
        #region members

        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private Court _currentCourt;
        private Court _selectedCourt;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        private MainViewModel _mvm;

        #endregion

        #region ctor
        public CourtViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
            _updateCommand = new RelayCommand(Update);

            _courts = new ObservableCollection<Court>(Container.CourtJeu);
            _courts.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        Container.CourtJeu.Remove(old as Court);
                    }
                }
                RaisePropertyChangedEvent("courts");
            };

            Initialise();
        }
        #endregion

        #region getters/setters

        public Court SelectedCourt
        {
            get { return _selectedCourt; }
            set
            {
                _selectedCourt = value;
                RaisePropertyChangedEvent("selectedCourt");
            }
        }

        public Court CurrentCourt
        {
            get { return _currentCourt; }
            set
            {
                _currentCourt = value;
                RaisePropertyChangedEvent("currentCourt");
            }
        }

        public ObservableCollection<Court> Courts
        {
            get { return _courts; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }
        #endregion

        #region public methods

        public void Save()
        {
            Container.CourtJeu.Add(_currentCourt);
            CommitChanges();
            _courts.Add(_currentCourt);
            Initialise();
        }

        public void Cancel()
        {
            ResetContainer();
            _courts = new ObservableCollection<Court>(Container.CourtJeu);
            Initialise();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            CommitChanges();
        }
        #endregion

        #region private methods

        private void Initialise()
        {
            CurrentCourt = new Court();
        }
        #endregion
    }
}
