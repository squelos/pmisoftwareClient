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
using TcpModernUI.Commands;

namespace TcpModernUI.ViewModels
{
    public class BadgesViewModel : INotifyPropertyChanged
    {
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Badge> _badges = new ObservableCollection<Badge>();
        private ICommand _saveCommand;
        private Badge _badge;

        public BadgesViewModel()
        {
            _saveCommand = new BadgeSaveCommand(this);
            _badges = _container.BadgeJeu.Local;
            InitialiseBadges();
        }

        public Badge CurrentBadge
        {
            get { return _badge; }
            set
            {
                _badge = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public void Save()
        {
            _container.BadgeJeu.Add(_badge);
            _container.SaveChanges();
            InitialiseBadges();
        }

        private void InitialiseBadges()
        {
            _badge = new Badge();
            _badge.isEnabled = true;
            _badge.isMaster = false;
            CurrentBadge = _badge;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
