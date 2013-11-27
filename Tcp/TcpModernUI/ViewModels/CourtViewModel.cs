using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModels
{
    public class CourtViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private Court _currentCourt;
        private RelayCommand _saveCommand;
        #endregion

        #region ctor
        public CourtViewModel()
        {
            _saveCommand = new RelayCommand(() => Save());
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
