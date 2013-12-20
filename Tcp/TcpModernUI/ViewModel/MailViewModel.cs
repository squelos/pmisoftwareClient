using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModel
{
    public class MailViewModel : ViewModelBase
    {
        #region members

        private MainViewModel _mvm;
        private ICommand _sendCommand;
        private ICommand _cancelCommand;
        private bool _players = false;
        private bool _clubMembers = false;
        private bool _administrators = false;
        private string _content;
        private string _subject;
        private List<Player> _playersList;
        private List<Status> _statuses; 
        
        #endregion

        #region ctor

        public MailViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            _sendCommand = new RelayCommand(Send);
            _cancelCommand = new RelayCommand(Cancel);
            _playersList = new List<Player>(Container.PlayerJeu);
            _statuses = new List<Status>(Container.StatusSet);
        }
        #endregion


        #region private

        private void Send()
        {
            MailMessage mail = new MailMessage("christopher.robert.test@gmail.com", "christopher.robert.test@gmail.com",Subject, Content);
            SmtpClient client = new SmtpClient();
            
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("christopher.robert.test@gmail.com", "Quickpass54");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = Subject;
            mail.BodyEncoding = Encoding.UTF8;
            
            mail.Body = Content;

            if (_players)
            {
                foreach (var pl in _playersList.Where(player => player.Status.statusName == "Utilisateur"))
                {
                    mail.To.Add(pl.email.Replace(" ", String.Empty));
                }
                
            }
            if (_clubMembers)
            {
                foreach (var pl in _playersList.Where(player => player.Status.statusName == "Club"))
                {
                    mail.To.Add(pl.email);
                }
            }
            if (_administrators)
            {
                foreach (var pl in _playersList.Where(player => player.Status.statusName == "Administrateur"))
                {
                    mail.To.Add(pl.email);
                }
            }
            //client.Send(mail);

            
        }

        private void Cancel()
        {
            Content = "";
            Subject = "";
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
                RaisePropertyChangedEvent("content");
            }
        }

        public string Subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                RaisePropertyChangedEvent("subject");
            }
        }

        public ICommand SendCommand
        {
            get { return _sendCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }
        #endregion
    }
}
