using GalaSoft.MvvmLight;
using VcpDriver;

namespace TcpDashboard.ViewModel
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

        #region privates
        private Driver _driver = new Driver();
        private bool _readerStatus;
        #endregion

        #region ctor
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _driver.ConnectedStatusChanged += stat => ReaderStatus = stat;
            _readerStatus = _driver.Connected;
        }
        #endregion

        #region getters/setters
        public bool ReaderStatus
        {
            get { return _readerStatus; }
            set
            {
                _readerStatus = value;
                RaisePropertyChanged("readerStatus");
            }
        }

        public Driver BadgeScanner
        {
            get { return _driver; }
            set
            {
                _driver = value;
                RaisePropertyChanged("driver");
            }
        }
        #endregion

        #region publics
        #endregion
    }
}