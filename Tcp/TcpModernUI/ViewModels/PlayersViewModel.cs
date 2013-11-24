﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDataModel;
using TcpModernUI.BaseClasses;
using TcpModernUI.Commands;

namespace TcpModernUI.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private Player _player;
        private ObservableCollection<Player> _players = new ObservableCollection<Player>();
        private List<BallLevel> _ballLevels;
        private List<Status> _statuses;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        #endregion

        #region ctor
        public PlayersViewModel()
        {
            _players = _container.PlayerJeu.Local;
            _ballLevels = (from a in _container.BallLevelSet select a).ToList();
            _statuses = (from a in _container.StatusSet select a).ToList(); 
            _saveCommand = new PlayerSaveCommand(this);
            _cancelCommand = new PlayerCancelCommand(this);
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
            
        }
        #endregion


        #region private methods
        private void  InitializePlayers()
        {
            CurrentPlayer = new Player(DateTime.Now) ;
            

        }

        #endregion

    }
}
