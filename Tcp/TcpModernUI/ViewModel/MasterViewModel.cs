using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        #region members

        private BadgesViewModel _badgesvm = new BadgesViewModel();
        private CourtViewModel _courtvm = new CourtViewModel();
        private PlayersViewModel _playersvm = new PlayersViewModel();
        private SeasonsViewModel _seasonsvm = new SeasonsViewModel();
        
        #endregion


        #region ctor
        public MasterViewModel()
        {
            
        }
        #endregion

        #region props

        public BadgesViewModel BadgesViewModel
        {
            get { return _badgesvm; }
        }

        public CourtViewModel CourtViewModel
        {
            get { return _courtvm; }
        }

        public PlayersViewModel PlayersViewModel
        {
            get { return _playersvm; }
        }

        public SeasonsViewModel SeasonsViewModel
        {
            get { return _seasonsvm; }
        }

        #endregion
    }
}
