using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDataModel;
using TcpModernUI.BaseClasses;
using TcpModernUI.Commands;

namespace TcpModernUI.ViewModels
{
    public class CourtViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Court> _courts = new ObservableCollection<Court>();
        private Court _currentCourt;
        private ICommand _saveCommand;
        #endregion

        #region ctor
        public CourtViewModel()
        {
            _saveCommand = new CourtSaveCommand(this);
            
            _courts = new ObservableCollection<Court>(_container.CourtJeu);
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

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }
        #endregion

        #region public methods

        public void Save()
        {
            _container.SaveChanges();
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
