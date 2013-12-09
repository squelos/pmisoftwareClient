using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        #region members
        private BadgesViewModel _badgesvm;
        private CourtViewModel _courtvm;
        private PlayersViewModel _playersvm;
        private SeasonsViewModel _seasonsvm;
        private UnpaidViewModel _unpaid;
        #endregion


        #region ctor
        public MainViewModel()
        {
            _badgesvm = new BadgesViewModel();
            _badgesvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _badgesvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
            _badgesvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("badgesvm");
            _badgesvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("badgesvm");
            
            _courtvm = new CourtViewModel();
            _courtvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _courtvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
            _courtvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("courtsvm");
            _courtvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("courtsvm");

            _playersvm = new PlayersViewModel();
            _playersvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _playersvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
            _playersvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("playersvm");
            _playersvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("playersvm");
            
            _seasonsvm = new SeasonsViewModel();
            _seasonsvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _seasonsvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
            _seasonsvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("seasonsvm");
            _seasonsvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("seasonsvm");

            _unpaid = new UnpaidViewModel();
            _unpaid.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
            _unpaid.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
            _unpaid.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("unpaid");
            _unpaid.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("unpaid");
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
            get { return _unpaid; }
        }

        #endregion
    }
}