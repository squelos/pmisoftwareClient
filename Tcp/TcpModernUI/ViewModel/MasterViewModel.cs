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

        private BadgesViewModel _badgesvm;
        private CourtViewModel _courtvm;
        private PlayersViewModel _playersvm;
        private SeasonsViewModel _seasonsvm;
        
        #endregion


        #region ctor
        public MasterViewModel()
        {
            _badgesvm = new BadgesViewModel();
            _badgesvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _courtvm = new CourtViewModel();
            _courtvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _playersvm = new PlayersViewModel();
            _playersvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _seasonsvm = new SeasonsViewModel();
            _seasonsvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
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
