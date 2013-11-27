﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpDataModel;
using TcpDataModel.Annotations;
using TcpModernUI.BaseClasses;
using TcpModernUI.Commands;

namespace TcpModernUI.ViewModels
{
    public class BadgesViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Badge> _badges = new ObservableCollection<Badge>();
        private ICommand _saveCommand;
        private ICommand _updateCommand;
        private Badge _badge;
        #endregion

        #region ctor
        public BadgesViewModel()
        {
            _saveCommand = new BadgeSaveCommand(this);
            _updateCommand = new BadgesUpdateCommand(this);
            _badges = new ObservableCollection<Badge>(_container.BadgeJeu);
            _badges.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        _container.BadgeJeu.Remove(old as Badge);
                    }
                }
                RaisePropertyChangedEvent("badges");
                
            };
            InitialiseBadges();
        }
        #endregion

        #region getters/setters
        public Badge CurrentBadge
        {
            get { return _badge; }
            set
            {
                _badge = value;
               RaisePropertyChangedEvent("currentBadge");
            }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        public ObservableCollection<Badge> Badges
        {
            get { return _badges; }
            set
            {
                _badges = value;
                RaisePropertyChangedEvent("badges");
            }
        }
        #endregion


        #region public methods
        public void Save()
        {
            _badges.Add(_badge);
            _container.BadgeJeu.Add(_badge);
            Update();
        }

        public void Update()
        {
            _container.SaveChanges();
            InitialiseBadges();
        }
        #endregion

        #region privates
        private void InitialiseBadges()
        {
            _badge = new Badge();
            _badge.isEnabled = true;
            _badge.isMaster = false;
            CurrentBadge = _badge;
        }
        #endregion

        
    }
}
