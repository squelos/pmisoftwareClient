using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TcpDash.ViewModel
{
    public class VideoViewModel : ViewModelBase
    {
        #region privates
        private MainViewModel _mvm;
        private Uri _videoSource;
        #endregion

        #region ctor

        public VideoViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
        }
        #endregion

        #region getters/setters

        public Uri Source
        {
            get { return _videoSource; }
            set
            {
                _videoSource = value;
                RaisePropertyChanged("videoSource");
            }
        }

        #endregion

        #region publics

        #endregion

        #region privateMethods

        #endregion

        #region events
        #endregion
    }
}
