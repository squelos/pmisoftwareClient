using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModel
{
    public class SeasonsViewModel : ViewModelBase
    {
        #region members
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Season> _seasons;
        private Season _season;
        private Semester _firstSemester;
        private Semester _secondSemester;
        private RelayCommand _saveCommand;
        private RelayCommand _cancelCommand;
        private RelayCommand _updateCommand;
        
        #endregion

        #region ctor
        public SeasonsViewModel()
        {
           InitialiseSeasons();
            _saveCommand = new RelayCommand(Save);
            _cancelCommand = new RelayCommand(Cancel);
            _updateCommand = new RelayCommand(Update);

            _seasons.CollectionChanged += (sender, args) =>
            {
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (var old in args.OldItems)
                    {
                        _container.SeasonJeu.Remove(old as Season);
                    }
                }
                RaisePropertyChangedEvent("seasons");

            };
            
            _seasons = new ObservableCollection<Season>(_container.SeasonJeu);
        }
        #endregion

        #region getters/setters
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
            _container.SeasonJeu.Add(_season);
            _container.SemesterJeu.Add(_firstSemester);
            _container.SemesterJeu.Add(_secondSemester);
            _container.SaveChanges();
            InitialiseSeasons();
        }

        public void Cancel()
        {
            _container = new entityContainer();
            InitialiseSeasons();
            RaisePropertyChangedEvent("container");
        }

        public void Update()
        {
            _container.SaveChanges();
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
