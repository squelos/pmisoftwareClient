using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows;
using TcpGA.BaseClasses;
using VcpDriver;

namespace TcpGA.ViewModel
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
        private MailViewModel _mailvm;
        private NonRenewViewModel _nonRenewvm;
        private Driver _driver = new Driver();
        private bool _readerStatus;
        private Visibility _connected = Visibility.Collapsed;
        private Visibility _disconnected = Visibility.Visible;

        private int _selectedGeneralIndex;

        #endregion

        #region ctor
        public MainViewModel()
        {
           
            _driver.ConnectedStatusChanged += stat => ReaderStatus = stat;
            _readerStatus = _driver.Connected;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }


        #endregion

        #region privates
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //clean up here in the event of an exception, and maybe log or open up a window
            _driver.Dispose();
        }

        
        #endregion

        #region props

        public Driver BadgeDriver
        {
            get { return _driver; }
        }

        public int SelectedGeneralIndex
        {
            get { return _selectedGeneralIndex; }
            set
            {
                _selectedGeneralIndex = value;
                RaisePropertyChangedEvent("selectedGeneralIndex");
            }
        }

        public BadgesViewModel BadgesViewModel
        {
            get
            {
                if (_badgesvm == null)
                {
                    _badgesvm = new BadgesViewModel(this);
                    _badgesvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _badgesvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _badgesvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("badgesvm");
                    _badgesvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("badgesvm");
                }
                return _badgesvm;
            }
        }

        public CourtViewModel CourtViewModel
        {
            get
            {
                if (_courtvm == null)
                {
                    _courtvm = new CourtViewModel(this);
                    _courtvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _courtvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _courtvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("courtsvm");
                    _courtvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("courtsvm");
                }
                return _courtvm;
            }
        }

        public PlayersViewModel PlayersViewModel
        {
            get
            {
                if (_playersvm == null)
                {
                    _playersvm = new PlayersViewModel(this);
                    _playersvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _playersvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _playersvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("playersvm");
                    _playersvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("playersvm");
                }
                return _playersvm;
            }
        }

        public SeasonsViewModel SeasonsViewModel
        {
            get
            {
                if (_seasonsvm == null)
                {
                    _seasonsvm = new SeasonsViewModel(this);
                    _seasonsvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _seasonsvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _seasonsvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("seasonsvm");
                    _seasonsvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("seasonsvm");
                }
                return _seasonsvm;
            }
        }

        public UnpaidViewModel UnpaidViewModel
        {
            get
            {
                if (_unpaid == null)
                {
                    _unpaid = new UnpaidViewModel(this);
                    _unpaid.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _unpaid.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _unpaid.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("unpaid");
                    _unpaid.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("unpaid");
                }
                return _unpaid;
            }
        }

        public MailViewModel MailViewModel
        {
            get
            {
                if (_mailvm == null)
                {
                    _mailvm = new MailViewModel(this);
                    _mailvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _mailvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _mailvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("mail");
                    _mailvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("mail");
                }
                return _mailvm;
            }
        }
        public NonRenewViewModel NonRenewViewModel
        {
            get
            {
                if (_nonRenewvm == null)
                {
                    _nonRenewvm = new NonRenewViewModel(this);
                    _nonRenewvm.ValidationErrorsChanged += (sender, exception) => RaiseValidationErrorsEvent(exception);
                    _nonRenewvm.CustomErrorsChanged += (sender, s) => RaiseCustomError(s);
                    _nonRenewvm.PropertyChanged += (sender, args) => RaisePropertyChangedEvent("nonrenew");
                    _nonRenewvm.PropertyChanging += (sender, args) => RaisePropertyChangingEvent("nonrenew");
                }
                return _nonRenewvm;
            }
        }

        public bool ReaderStatus
        {
            get { return _readerStatus; }
            set
            {
                _readerStatus = value;
                if (value)
                {
                    Connected = Visibility.Visible;
                    Disconnected = Visibility.Collapsed;
                }
                else
                {
                    Connected = Visibility.Collapsed;
                    Disconnected = Visibility.Visible;
                }
                RaisePropertyChangedEvent("readerStatus");
            }
        }

        public Visibility Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                RaisePropertyChangedEvent("connected");
            }
        }

        public Visibility Disconnected
        {
            get { return _disconnected; }
            set
            {
                _disconnected = value;
                RaisePropertyChangedEvent("disconnected");
            }
        }

        #endregion
    }
}