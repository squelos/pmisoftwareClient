using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using System.Data.Entity;
using TcpModernUI.BaseClasses;



namespace TcpModernUI.ViewModel
{
    public class UnpaidViewModel : ViewModelBase
    {
        #region members

        private List<Player> _players;
        private List<Player> _filteredPlayers = new List<Player>();
        private Player _selectedPlayer;
        private readonly List<PaymentMethod> _methods;
        private Payment _newPayment;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private readonly MainViewModel _mvm;
        private List<Semester> _semesters; 

        #endregion

        #region ctor

        public UnpaidViewModel(MainViewModel mvm)
        {
            _semesters = Container.SemesterJeu.OrderByDescending(semester => semester.end).Take(6).ToList();
            Task t = new Task(() =>
                              {
                                  //must eager load here
                                  _players = Container.PlayerJeu.Include
                                      (p => p.Payment.Select(payment => payment.Semester)).ToList();

                                  _filteredPlayers = _players.Where(
                                      player => player.Payment.Count == 0 | player.Payment.All(
                                          payment => payment.Semester.Any(semester => semester.end > DateTime.Now))).ToList();
                                  RaisePropertyChangedEvent("players");
                              });
          
            t.Start();
            InitPayment();
            _mvm = mvm;
            _methods = new List<PaymentMethod>(Container.PaymentMethodSet.ToList());
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
        }
        #endregion

        #region props

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

        public Player SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                RaisePropertyChangedEvent("selectedPlayer");
            }
        }

        public IEnumerable<Semester> Semesters
        {
            get { return _semesters; }
        }

        public IEnumerable<Player> Players
        {
            get { return _filteredPlayers; }
        }

        public ICommand SaveCommand
        { get { return _saveCommand; } }

        public ICommand CancelCommand
        { get { return _cancelCommand; } }

        #endregion

        #region privates
        private void Save()
        {
            SelectedPlayer.Payment.Add(_newPayment);
            CommitChanges();
            InitPayment();
        }

        private void Cancel()
        {
            InitPayment();
        }

        private void InitPayment()
        {
            NewPayment = new Payment { date = DateTime.Now };
        }
        #endregion

        #region publics

        
        #endregion
    }
}
