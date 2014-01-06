using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        #region members

        private int _playersCount;
        private int _unpaidCount;
        private int _nonRenewCount;
        private int _paidlayers;

        #endregion

        #region ctor

        #endregion

        #region props

        #endregion

        #region publics

        public int PlayersCount
        {
            get { return _playersCount; }
            set
            {
                _playersCount = value;
                RaisePropertyChangedEvent("playersCount");
            }
        }
        public int UnpaidCount
        {
            get { return _unpaidCount; }
            set
            {
                _unpaidCount = value;
                RaisePropertyChangedEvent("playersCount");
            }
        }
        public int NonRenewCount
        {
            get { return _nonRenewCount; }
            set
            {
                _nonRenewCount = value;
                RaisePropertyChangedEvent("playersCount");
            }
        }
        public int PaidPlayers
        {
            get { return _paidlayers; }
            set
            {
                _paidlayers = value;
                RaisePropertyChangedEvent("playersCount");
            }
        }
        #endregion

        #region private

        #endregion
    }
}
