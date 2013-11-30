using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpDataModel;

namespace DatabaseFiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private entityContainer _container = new entityContainer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateBallLevels();
            CreateCategories();
            CreateDays();
            CreatePaymentMethods();
            CreateStatus();
            _container.SaveChanges();
        }

        private void CreateBallLevels()
        {
            if (_container.BallLevelSet.Count() == 0)
            {
                BallLevel blanche = new BallLevel();
                blanche.ballName = "Blanche";
                BallLevel jaune = new BallLevel();
                jaune.ballName = "Jaune";
                BallLevel orange = new BallLevel();
                orange.ballName = "Orange";
                BallLevel verte = new BallLevel();
                verte.ballName = "Verte";
                BallLevel rouge = new BallLevel();
                rouge.ballName = "Rouge";
                BallLevel raquette = new BallLevel();
                raquette.ballName = "Raquette";
                BallLevel mousse = new BallLevel();
                mousse.ballName = "Mousse";
                BallLevel souple = new BallLevel();
                souple.ballName = "Souple";
                BallLevel intermediaire = new BallLevel();
                intermediaire.ballName = "Intermédiaire";
                _container.BallLevelSet.AddRange(new[]
                {blanche, jaune, orange, verte, rouge, raquette, mousse, souple, intermediaire});
            }


        }

        private void CreateStatus()
        {
            if (_container.StatusSet.Count() == 0)
            {
                Status utilisateur = new Status();
                utilisateur.statusName = "Utilisateur";
                Status club = new Status();
                club.statusName = "Club";
                Status admin = new Status();
                admin.statusName = "Administrateur";
                _container.StatusSet.AddRange(new[] {utilisateur, club, admin});
            }

        }

        private void CreatePaymentMethods()
        {
            if (_container.PaymentMethodSet.Count() == 0)
            {
                PaymentMethod argentComptant = new PaymentMethod();
                argentComptant.methodName = "Argent comptant";
                PaymentMethod cheque = new PaymentMethod();
                cheque.methodName = "Chèque";
                PaymentMethod chequeVacance = new PaymentMethod();
                chequeVacance.methodName = "Chèque vacance";
                _container.PaymentMethodSet.AddRange(new PaymentMethod[] {argentComptant, cheque, chequeVacance});
            }
        }

        private void CreateDays()
        {
            if (_container.DaySet.Count() == 0)
            {
                Day lundi = new Day();
                lundi.name = "Lundi";
                Day mardi = new Day();
                mardi.name = "Mardi";
                Day mercredi = new Day();
                mercredi.name = "Mercredi";
                Day jeudi = new Day();
                jeudi.name = "Jeudi";
                Day vendredi = new Day();
                vendredi.name = "Vendredi";
                Day samedi = new Day();
                samedi.name = "Samedi";
                Day dimanche = new Day();
                dimanche.name = "Dimanche";

                _container.DaySet.AddRange(new Day[] {lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche});
            }
        }

        private void CreateCategories()
        {
            if (_container.CategorySet.Count() == 0)
            {
                Category loisir = new Category();
                loisir.categoryName = "Loisir";
                Category competition = new Category();
                competition.categoryName = "Compétition";
                Category ecoleDeTennis = new Category();
                ecoleDeTennis.categoryName = "Ecole de Tennis";
                Category entrainement = new Category();
                entrainement.categoryName = "Entraînement";

                _container.CategorySet.AddRange(new[] {loisir, competition, ecoleDeTennis, entrainement});
            }
        }


    }
}
