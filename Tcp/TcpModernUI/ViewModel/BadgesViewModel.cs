using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class BadgesViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Badge> _badges = new ObservableCollection<Badge>();
        private RelayCommand _saveCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _cancelCommand;
        private Badge _badge;
        #endregion

        #region ctor
        public BadgesViewModel()
        {
            _saveCommand = new RelayCommand(Save);
            _updateCommand = new RelayCommand(Update);
            _cancelCommand = new RelayCommand(Cancel);
            _badges = new ObservableCollection<Badge>(_container.BadgeJeu);

            _badges.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        _container.BadgeJeu.Remove(old as Badge);
                    }
                }
                RaisePropertyChangedEvent("badges");
                
            };
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

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public RelayCommand CancelCommand
        {
            get { return _cancelCommand; }
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
            _badges.Add(_badge);
            _container.BadgeJeu.Add(_badge);
            InitialiseBadges();
            Update();
        }

        public void Update()
        {
            _container.SaveChanges();
            //InitialiseBadges();
        }

        public void Cancel()
        {
            _container = new entityContainer();
            CurrentBadge = new Badge();
            RaisePropertyChangedEvent("container");
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
