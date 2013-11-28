using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private Player _player;
        private ObservableCollection<Player> _players;
        private List<BallLevel> _ballLevels;
        private List<Status> _statuses;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        #endregion

        #region ctor
        public PlayersViewModel()
        {
            _players = new ObservableCollection<Player>(_container.PlayerJeu);

            _players.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        _container.PlayerJeu.Remove(old as Player);
                    }
                }
                RaisePropertyChangedEvent("players");

            };
            _ballLevels = (from a in _container.BallLevelSet select a).ToList();
            _statuses = (from a in _container.StatusSet select a).ToList(); 
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
            _updateCommand = new RelayCommand(Update);
            InitializePlayers();
        }
        #endregion

        #region getters/setters

        public Player CurrentPlayer
        {
            get { return _player; }
            set
            {
                _player = value;
                RaisePropertyChangedEvent("currentPlayer");
            }
        }

        public ObservableCollection<Player> Players
        {
            get { return _players; }
            set
            {
                _players = value;
                RaisePropertyChangedEvent("players");
            }
        }

        public List<BallLevel> BallLevels
        {
            get { return _ballLevels; }
        }

        public List<Status> Statuses
        {
            get { return _statuses; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }
        #endregion

        #region public methods
        public void Save()
        {
            _container.PlayerJeu.Add(CurrentPlayer);
            _container.SaveChanges();
            InitializePlayers();
        }

        public void Cancel()
        {
            _container = new entityContainer();
            InitializePlayers();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            _container.SaveChanges();
        }
        #endregion

        #region private methods
        private void  InitializePlayers()
        {
            CurrentPlayer = new Player(DateTime.Now, DateTime.Now) ;
            CurrentPlayer.isEnabled = true;
            CurrentPlayer.passwordHash = "00000";
        }
        #endregion

    }
}
