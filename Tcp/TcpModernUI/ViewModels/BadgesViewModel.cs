using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDataModel;
using TcpDataModel.Annotations;
using TcpModernUI.BaseClasses;
using TcpModernUI.Commands;

namespace TcpModernUI.ViewModels
{
    public class BadgesViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Badge> _badges = new ObservableCollection<Badge>();
        private ICommand _saveCommand;
        private Badge _badge;
        #endregion

        #region ctor
        public BadgesViewModel()
        {
            _saveCommand = new BadgeSaveCommand(this);
            _badges = new ObservableCollection<Badge>(_container.BadgeJeu);
            InitialiseBadges();
        }
        #endregion

        #region getters/setters
        public Badge CurrentBadge
        {
            get { return _badge; }
            set
            {
                _badge = value;
               RaisePropertyChangedEvent("currentBadge");
            }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ObservableCollection<Badge> Badges
        {
            get { return _badges; }
            set
            {
                _badges = value;
                RaisePropertyChangedEvent("badges");
            }
        }
        #endregion


        #region public methods
        public void Save()
        {
            _container.BadgeJeu.Add(_badge);
            _container.SaveChanges();
            InitialiseBadges();
        }
        #endregion

        #region privates
        private void InitialiseBadges()
        {
            _badge = new Badge();
            _badge.isEnabled = true;
            _badge.isMaster = false;
            CurrentBadge = _badge;
        }
        #endregion
    }
}
