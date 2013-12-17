using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Documents;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class SeasonsViewModel : ViewModelBase
    {
        #region members

        private ObservableCollection<Season> _seasons;
        private ObservableCollection<Semester> _semesters;
        private Season _season;
        private Semester _firstSemester;
        private Semester _secondSemester;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        private MainViewModel _mvm;

        #endregion

        #region ctor

        public SeasonsViewModel(MainViewModel mvm)
        {
            _mvm = mvm;
            InitialiseSeasons();
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
            _updateCommand = new RelayCommand(Update);
            _seasons = new ObservableCollection<Season>(Container.SeasonJeu);
            _semesters = new ObservableCollection<Semester>(Container.SemesterJeu);

            _seasons.CollectionChanged += (sender, args) =>
                                          {
                                              if (args.Action == NotifyCollectionChangedAction.Remove)
                                              {
                                                  foreach (var old in args.OldItems)
                                                  {
                                                      Container.SeasonJeu.Remove(old as Season);
                                                  }
                                              }
                                              RaisePropertyChangedEvent("seasons");
                                          };

            _semesters.CollectionChanged += (sender, args) =>
                                            {
                                                if (args.Action == NotifyCollectionChangedAction.Remove)
                                                {
                                                    foreach (var se in args.OldItems)
                                                    {
                                                        Container.SemesterJeu.Remove(se as Semester);
                                                    }
                                                }
                                                RaisePropertyChangedEvent("semesters");
                                            };

            _seasons = new ObservableCollection<Season>(Container.SeasonJeu);
        }

        #endregion

        #region getters/setters

        public ObservableCollection<Semester> Semesters
        {
            get { return _semesters; }
        }
        public Season Season
        {
            get { return _season; }
            set
            {
                _season = value;
                RaisePropertyChangedEvent("season");
            }
        }

        public Semester FirstSemester
        {
            get { return _firstSemester; }
            set
            {
                _firstSemester = value;
                RaisePropertyChangedEvent("firstSemester");
            }
        }

        public Semester SecondSemester
        {
            get { return _secondSemester; }
            set
            {
                _secondSemester = value;
                RaisePropertyChangedEvent("secondSemester");
            }
        }

        public ObservableCollection<Season> Seasons
        {
            get { return _seasons; }
            set
            {
                _seasons = value;
                RaisePropertyChangedEvent("seasons");
            }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand; }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand; }
        }

        #endregion

        #region public methods

        public void Save()
        {
            Container.SeasonJeu.Add(_season);
            Container.SemesterJeu.Add(_firstSemester);
            Container.SemesterJeu.Add(_secondSemester);
            CommitChanges();
            _seasons.Add(_season);
            InitialiseSeasons();
        }

        public void Cancel()
        {
            ResetContainer();
            _seasons = new ObservableCollection<Season>(Container.SeasonJeu);
            InitialiseSeasons();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            CommitChanges();
        }

        #endregion

        #region private methods

        private void InitialiseSeasons()
        {
            FirstSemester = new Semester(DateTime.Now, DateTime.Now);
            SecondSemester = new Semester(DateTime.Now, DateTime.Now);
            Season = new Season(_firstSemester, _secondSemester);
        }

        #endregion
    }
}