using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FirstFloor.ModernUI.Presentation;
using TcpDataModel;
using TcpModernUI.BaseClasses;


namespace TcpModernUI.ViewModels
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
        
        #endregion

        #region ctor
        public SeasonsViewModel()
        {
           InitialiseSeasons();
            _saveCommand = new RelayCommand(o => Save());
            _cancelCommand = new RelayCommand(o => Cancel());
            
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
            InitialiseSeasons();
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
