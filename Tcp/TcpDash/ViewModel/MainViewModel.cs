using System.Configuration;
using System.Reflection;
using GalaSoft.MvvmLight;
using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using TcpDash.Classes;
using VcpDriver;

namespace TcpDash.ViewModel
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
        private Jobs _jobs;
        private NewsViewModel _newsViewModel;
        private CalendarViewModel _calendarViewModel;
        private ImageViewModel _imageViewModel;
        private bool _readerStatus;
        private Visibility _connected = Visibility.Collapsed;
        private Visibility _disconnected = Visibility.Visible;

        #endregion

        #region ctor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _driver.ConnectedStatusChanged += stat => ReaderStatus = stat;
            _readerStatus = _driver.Connected;
            _newsViewModel = new NewsViewModel(this);
            _calendarViewModel = new CalendarViewModel(this);
            _imageViewModel = new ImageViewModel(this);
            _jobs = new Jobs(_calendarViewModel, _newsViewModel, this);
            _jobs.DoJobs = true;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        #endregion

        #region getters/setters

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

        public ImageViewModel ImageViewModel
        {
            get { return _imageViewModel; }
            set
            {
                _imageViewModel = value;
                RaisePropertyChanged("imageViewModel");
            }
        }

        public NewsViewModel NewsViewModel
        {
            get { return _newsViewModel; }
            set
            {
                _newsViewModel = value;
                RaisePropertyChanged("newsViewModel");
            }
        }


        public CalendarViewModel CalendarViewModel
        {
            get { return _calendarViewModel; }
            set
            {
                _calendarViewModel = value;
                RaisePropertyChanged("calendarViewModel");
            }
        }

        public Visibility Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                RaisePropertyChanged("connected");
            }
        }

        public Visibility Disconnected
        {
            get { return _disconnected; }
            set
            {
                _disconnected = value;
                RaisePropertyChanged("disconnected");
            }
        }

        #endregion

        #region publics

        #endregion

        #region privates

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //clean up  and maybe log or show the error in a window for the user
            _driver.Dispose();
            _jobs.DoJobs = false;
        }

        #endregion
    }
}