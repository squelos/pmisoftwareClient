using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;
using System.Data.Entity;

namespace TcpModernUI.ViewModel
{
    public class NonRenewViewModel : ViewModelBase
    {
        #region members

        private List<Player> _players;
        private List<Player> _filteredPlayers = new List<Player>();
        private Player _selectedPlayer;
        private readonly List<PaymentMethod> _methods;
        private Payment _newPayment;
        private List<Semester> _semesters = new List<Semester>(); 
        private MainViewModel _mvm;
        private ICommand _saveCommand;
        private ICommand _updateCommand;
        private ICommand _cancelCommand;

        #endregion

        #region ctor
        public NonRenewViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            _saveCommand = new RelayCommand(Save);
            _updateCommand = new RelayCommand(Update);
            _cancelCommand = new RelayCommand(Cancel);
            _methods = new List<PaymentMethod>(Container.PaymentMethodSet.ToList());
            InitNewPayment();
            _semesters = Container.SemesterJeu.OrderByDescending(semester => semester.end).Take(6).ToList();
            DateTime time = DateTime.Now.AddMonths(-6);
            Task t = new Task(() =>
                              {
                                  _players = Container.PlayerJeu.Include(p => p.Payment.Select(payment => payment.Semester)).ToList();
                                  _filteredPlayers = _players.Where(
                                      player => player.Payment.Count != 0 && player.Payment.All(
                                          payment => !payment.Semester.Any(semester => semester.end > time))).ToList();
                                  _mvm.NonRenewCount = _filteredPlayers.Count;
                                  RaisePropertyChangedEvent("players");
                              });
            t.Start();
        }

        #endregion

        #region getters/Setters

        public IEnumerable<Player> Players
        {
            get { return _filteredPlayers; }
        }

        public IEnumerable<Semester> Semesters
        {
            get { return _semesters; }
        }

        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                RaisePropertyChangedEvent("selectedPlayer");
            }
        }
        public IEnumerable<PaymentMethod> PaymentMethods
        {
            get { return _methods; }
        }

        public Payment NewPayment
        {
            get { return _newPayment; }
            set
            {
                _newPayment = value;
                RaisePropertyChangedEvent("newPayment");
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

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }
        #endregion

        #region privates
        private void Save()
        {
            SelectedPlayer.Payment.Add(NewPayment);
            CommitChanges();
            InitNewPayment();
        }

        private void Cancel()
        {
            InitNewPayment();
        }

        private void Update()
        {
            CommitChanges();
        }

        private void InitNewPayment()
        {
           NewPayment = new Payment {date = DateTime.Now};
        }

        #endregion

        #region publics

        #endregion
    }
}
