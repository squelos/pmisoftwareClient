using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Command;
using Microsoft.QualityTools.Testing.Fakes;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class PlayersViewModel : ViewModelBase
    {
        #region members

        private Player _player;
        private Player _selectedPlayer;
        private ObservableCollection<Player> _players;
        private List<Player> _viewPlayers = new List<Player>();
        private ObservableCollection<Player> _unpaidPlayers = new ObservableCollection<Player>();
        private List<BallLevel> _ballLevels;
        private List<Status> _statuses;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        private List<Category> _categories;
        private MainViewModel _mvm;

        #endregion

        #region ctor

        public PlayersViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            _players =
                new ObservableCollection<Player>(Container.PlayerJeu.ToList());

            _players.CollectionChanged += (sender, args) =>
                                          {
                                              if (args.Action == NotifyCollectionChangedAction.Remove)
                                              {
                                                  foreach (var old in args.OldItems)
                                                  {
                                                      Container.PlayerJeu.Remove(old as Player);
                                                      CustomDispatcher.Instance.BeginInvoke(
                                                          () => Unpaid.Remove(old as Player));
                                                  }
                                              }
                                              else if (args.Action == NotifyCollectionChangedAction.Add)
                                              {
                                                  foreach (Player p in args.OldItems)
                                                  {
                                                      if (p.Payment.Count() == 0 ||
                                                          p.Payment.Last().Semester.Last().end < DateTime.Now)
                                                      {
                                                          CustomDispatcher.Instance.BeginInvoke(() => Unpaid.Add(p));
                                                      }
                                                  }
                                              }
                                              RaisePropertyChangedEvent("players");
                                          };


            Task t = new Task(() =>
            {
                foreach (Player p in Players)
                {
                    if (p.Payment.Count == 0)
                    {
                        CustomDispatcher.Instance.BeginInvoke(() => Unpaid.Add(p));
                    }
                    else
                    {
                        if (
                            !p.Payment.Any(
                                payment =>
                                    payment.Semester.Any(semester => semester.end > DateTime.Now)))
                        {
                            CustomDispatcher.Instance.BeginInvoke(() => Unpaid.Add(p));
                        }
                    }
                }
            });

            t.Start();


            _ballLevels = (from a in Container.BallLevelSet select a).ToList();
            _statuses = (from a in Container.StatusSet select a).ToList();
            _categories = (from a in Container.CategorySet select a).ToList();
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
            _updateCommand = new RelayCommand(Update);
            InitializePlayers();
        }

        #endregion

        #region getters/setters

        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                //_selectedPlayer = value;
                //RaisePropertyChangedEvent("selectedPlayer");

                Task t = new Task(() =>
                                  {
                                      //_selectedPlayer =
                                      //    Container.PlayerJeu.Where(p => p.ID == value.ID)
                                      //        .Include(p => p.Payment)
                                      //        .First();
                                      _selectedPlayer = value;
                                      RaisePropertyChangedEvent("selectedPlayer");
                                  });
                t.Start();
            }
        }

        public List<Category> Categories
        {
            get { return _categories; }
        }

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

        public ObservableCollection<Player> Unpaid
        {
            get { return _unpaidPlayers; }
            set
            {
                _unpaidPlayers = value;
                RaisePropertyChangedEvent("unpaid");
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
            if (CurrentPlayer.login != null)
            {
                if (Players.Count(player => player.login.ToLower() == CurrentPlayer.login.ToLower()) != 0)
                {
                    RaiseCustomError("Login déjà existant");
                    return;
                }
            }
            Container.PlayerJeu.Add(CurrentPlayer);

            //RaisePropertyChangedEvent("container");
            if (CommitChanges())
            {
                Players.Add(CurrentPlayer);
                InitializePlayers();
            }
        }

        public void Cancel()
        {
            ResetContainer();
            _players = new ObservableCollection<Player>(Container.PlayerJeu);
            SelectedPlayer = null;
            InitializePlayers();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            CommitChanges();
        }

        #endregion

        #region private methods

        private void InitializePlayers()
        {
            Task t = new Task(() =>
                              {
                                  CurrentPlayer = new Player(DateTime.Now, DateTime.Now);
                                  CurrentPlayer.isEnabled = true;
                                  CurrentPlayer.passwordHash = "00000";
                              });
            t.Start();
        }

        #endregion
    }
}