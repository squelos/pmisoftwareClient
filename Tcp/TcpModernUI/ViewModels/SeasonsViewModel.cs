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
        private entityContainer _container = new entityContainer();
        private ObservableCollection<Season> _seasons = new ObservableCollection<Season>(); 
        private Season _season;
        private Semester _firstSemester = new Semester();
        private Semester _secondSemester = new Semester();
        private ICommand _saveCommand;

        public SeasonsViewModel()
        {
            _season = new Season();
            _season.Semester.Add(FirstSemester);
            _season.Semester.Add(SecondSemester);
            _seasons = _container.SeasonJeu.Local;
        }

        public Season Season
        {
            get { return _season; }
        }

        public Semester FirstSemester
        {
            get { return _firstSemester; }
        }

        public Semester SecondSemester
        {
            get { return _secondSemester; }
        }

        public ObservableCollection<Season> Seasons
        {
            get { return _seasons; }
        }

        public ICommand SaveCommand
        {
            get { return _saveCommand; }
        }


    }
}
