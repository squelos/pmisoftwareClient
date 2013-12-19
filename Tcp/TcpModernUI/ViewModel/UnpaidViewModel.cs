using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class UnpaidViewModel : ViewModelBase
    {
        #region members
        
        private readonly List<PaymentMethod> _methods;
        private Payment _newPayment;
        private ICommand _saveCommand;
        private ICommand _cancelCommand;
        private readonly MainViewModel _mvm;
        #endregion

        #region ctor

        public UnpaidViewModel(MainViewModel mvm)
        {
            _newPayment = new Payment();
            _newPayment.date = DateTime.Now;
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

        public ICommand SaveCommand
        { get { return _saveCommand; } }

        public ICommand CancelCommand
        { get { return _cancelCommand; } }

        #endregion

        #region privates
        
        #endregion

        #region publics

        public void Save()
        {
            _mvm.PlayersViewModel.SelectedPlayer.Payment.Add(_newPayment);
            _mvm.PlayersViewModel.Update();
            NewPayment = new Payment {date = DateTime.Now};
        }

        public void Cancel()
        {
            
        }
        #endregion
    }
}
