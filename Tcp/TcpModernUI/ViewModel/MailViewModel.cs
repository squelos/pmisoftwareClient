using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    public class MailViewModel : ViewModelBase
    {
        #region members

        private MainViewModel _mvm;
        private ICommand _sendCommand;
        private bool _players = false;
        private bool _clubMembers = false;
        private bool _administrators = false;
        private string _content;
        
        #endregion

        #region ctor

        public MailViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            _sendCommand = new RelayCommand(Send);
        }
        #endregion


        #region private

        private void Send()
        {
        
        }

        #endregion

        #region getters/setters

        public bool Players
        {
            get { return _players; }
            set
            {
                _players = value;
                RaisePropertyChangedEvent("players");
            }
        }

        public bool ClubMembers
        {
            get { return _clubMembers; }
            set
            {
                _clubMembers = value;
                RaisePropertyChangedEvent("club");
            }
        }

        public bool Administrators
        {
            get { return _administrators; }
            set
            {
                _administrators = value;
                RaisePropertyChangedEvent("admins");
            }
        }

        public string Content
        {
            get { return _content; }
            set
            {
                _content = value;
                //RaisePropertyChangedEvent("content");
            }
        }

        public ICommand SendCommand
        {
            get { return _sendCommand; }
        }
        #endregion
    }
}
