using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class UnpaidViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private List<PaymentMethod> _methods;
        private Payment _newPayment = new Payment();
        #endregion

        #region ctor

        public UnpaidViewModel() 
        {
            _methods = new List<PaymentMethod>(_container.PaymentMethodSet.ToList());
        }
        #endregion

        #region props

        public IEnumerable<PaymentMethod> PaymentMethods
        {
            get { return _methods; }
        }

        #endregion

        #region privates
        
        #endregion

        #region publics

        #endregion
    }
}
