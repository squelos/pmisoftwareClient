using System.Collections.ObjectModel;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class CourtViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private Court _currentCourt;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        #endregion

        #region ctor
        public CourtViewModel()
        {
            _saveCommand = new RelayCommand(o => Save());
            _cancelCommand = new RelayCommand(o => Cancel());
            _updateCommand = new RelayCommand(o=>Update());
            _courts = new ObservableCollection<Court>(_container.CourtJeu);
            Initialise();
        }
        #endregion

        #region getters/setters

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
            _container.CourtJeu.Add(_currentCourt);
            _container.SaveChanges();
            Initialise();
        }

        public void Cancel()
        {
            _container = new entityContainer();
            Initialise();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            _container.SaveChanges();
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
