using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    public sealed class MasterViewModel : ViewModelBase
    {

        #region members

        private BadgesViewModel _badgesvm;
        private CourtViewModel _courtvm;
        private PlayersViewModel _playersvm;
        private SeasonsViewModel _seasonsvm;
        private UnpaidViewModel _unpaidvm;
        
        #endregion


        #region ctor
        public MasterViewModel()
        {
            _badgesvm = new BadgesViewModel();
            _badgesvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _badgesvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("badgesvm");
            _badgesvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("badgesvm");
            
            _courtvm = new CourtViewModel();
            _courtvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _courtvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("courtsvm");
            _courtvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("courtsvm");

            _playersvm = new PlayersViewModel();
            _playersvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _playersvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("playersvm");
            _playersvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("playersvm");
            
            _seasonsvm = new SeasonsViewModel();
            _seasonsvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _seasonsvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("seasonsvm");
            _seasonsvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("seasonsvm");

            _unpaidvm = new UnpaidViewModel();
            _unpaidvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _unpaidvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("unpaidvm");
            _unpaidvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("unpaidvm");
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

        public UnpaidViewModel UnpaidViewModel
        {
            get { return _unpaidvm; }
        }

        #endregion
    }
}
