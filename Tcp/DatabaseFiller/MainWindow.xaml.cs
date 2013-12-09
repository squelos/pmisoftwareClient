using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using TcpDataModel;

namespace DatabaseFiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rand = new Random();
        private entityContainer _container = new entityContainer();
        public MainWindow()
        {
            InitializeComponent();
            _container.Configuration.AutoDetectChangesEnabled = false;
            _container.Configuration.ValidateOnSaveEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(Wrapper);
            t.Start();


        }

        private void Wrapper()
        {
            CreateBallLevels();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 1));
            CreateCategories();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 2));
            CreateDays();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 3));
            CreatePaymentMethods();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 4));
            CreateStatus();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 5));
            createBadges();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 10));
            createTerrains();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 11));
            createSeasons();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 12));
            createPlayers();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 40));
            createBookingPrefs();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 60));
            createBookings();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 70));
            createPayments();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 80));
            createTraining();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 90));
            AssignBadges();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 100));
            _container.SaveChanges();
            Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => prog.Value = 0));
        }





        private void createBadges()
        {
            List<Badge> badges = new List<Badge>();
            badges.Add(new Badge(24245252, true, false));
            badges.Add(new Badge(835623535, false, false));
            badges.Add(new Badge(13535356, true, true));
            badges.Add(new Badge(7353634, false, false));
            badges.Add(new Badge(2353556, false, true));
            badges.Add(new Badge(353534245, true, false));

            for (int i = 0; i < 200; i++)
            {
                badges.Add(new Badge(GetBadgeNumber(), true, false));
            }
            _container.BadgeJeu.AddRange(badges);
            _container.SaveChanges();
        }

        private void createTerrains()
        {
            List<Court> courts = new List<Court>();
            courts.Add(new Court("terrain 1", true));
            courts.Add(new Court("terrain 2", false));
            courts.Add(new Court("Intérieur 1", true));
            courts.Add(new Court("Extérieur 3", false));
            _container.CourtJeu.AddRange(courts);
            _container.SaveChanges();
        }

        private void createSeasons()
        {
            List<Season> seasons = new List<Season>();
            List<Semester> semesters = new List<Semester>();
            Semester sem;
            semesters.Add(new Semester(DateTime.Now.AddMonths(-12), DateTime.Now.AddMonths(-11)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(-10), DateTime.Now.AddMonths(-9)));

            semesters.Add(new Semester(DateTime.Now.AddMonths(-8), DateTime.Now.AddMonths(-7)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(-5)));

            semesters.Add(new Semester(DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(-3)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(-1)));

            semesters.Add(new Semester(DateTime.Now.AddMonths(0), DateTime.Now.AddMonths(1)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(3)));

            semesters.Add(new Semester(DateTime.Now.AddMonths(4), DateTime.Now.AddMonths(5)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(6), DateTime.Now.AddMonths(7)));

            semesters.Add(new Semester(DateTime.Now.AddMonths(8), DateTime.Now.AddMonths(9)));
            semesters.Add(new Semester(DateTime.Now.AddMonths(10), DateTime.Now.AddMonths(11)));

            Season sea;
            for (int i = 0; i < 12; i++)
            {
                sea = new Season(semesters[i], semesters[i + 1]);
                //sea.Semester1.Add(semesters[i]);
                //sea.Semester1.Add(semesters[i+1]);
                //semesters[i + 1].Season1 = sea;
                // semesters[i].Season1 = sea;
                seasons.Add(sea);
                i++;
            }

            //seasons.Add(new Season(semesters[0], semesters[1]));

            //seasons.Add(new Season(semesters[2], semesters[3]));
            //seasons.Add(new Season(semesters[4], semesters[5]));
            //seasons.Add(new Season(semesters[6], semesters[7]));
            //seasons.Add(new Season(semesters[8], semesters[9]));
            //seasons.Add(new Season(semesters[10], semesters[11]));

            //_container.SemesterJeu.AddRange(semesters);
            _container.SeasonJeu.AddRange(seasons);
            _container.SaveChanges();


        }

        private void createPlayers()
        {
            List<Player> players = new List<Player>();

            List<string> prenoms = new List<string>(new[]
            {
                "Christopher", "luke", "Nathan", "Olivier", "Frederic", 
                "Manon","Louise","Sarah","Emma","Lea","Enzo",
                "Camille","Gabriel","Ethan"
            });
            //14

            List<string> noms = new List<string>(new[]
            {
                "Tremblay", "Gagnon", "Roy","Côté", "Bouchard","Gauthier","Morin",
                "Lavoie","Fortin","Gagné","Ouellet","Pelletier","Bélanger","Lévesque","Bergeron"
            });
            //15
            List<string> cp = new List<string>(new[]
            {
                "01067", "01445", "01454 ","01465 ", "01468","01558 ","01609 ",
                "01616 ","01621","01631","01662","01683 ","09376 ","09456 ","09526 "
            });
            //15
            List<string> listRue = new List<string>(new[]
            {
                "Rue de l'eglise", "Place de l'eglise", "Grande Rue ","Rue du moulin ", "Place de la mairie","Rue du chateau ","Rue des ecoles ",
                "Rue de la gare ","Rue de la mairie","rue principale","Rue secondaire","Rue des acacias ","Rue de la fontaine ","Rue Pasteur ","Rue des juifs "
            });
            //15
            List<string> listVilles = new List<string>(new[]
            {
                "Paris", "Nancy", "Metz ","Longwy", "Luxembourg","Montreal","Quebec "
                
            });
            //7

            List<BallLevel> ballLevels = new List<BallLevel>(_container.BallLevelSet);
            List<Category> categories = new List<Category>(_container.CategorySet);
            List<Status> statuses = new List<Status>(_container.StatusSet);


            for (int i = 0; i < 300; i++)
            {
                int p = GetRandom(0, prenoms.Count);
                int n = GetRandom(0, noms.Count);
                Player player = new Player(prenoms[p], noms[n],
                    DateTime.Now.AddYears(GetRandom(-50, -10)),
                    "30/" + GetRandom(1, 5), prenoms[p] + "." + noms[n] + "@gmail.com",
                    GetRandom(1, 120).ToString() + " " + listRue[GetRandom(0, 14)], cp[GetRandom(0, 14)],
                    listVilles[GetRandom(0, 6)],
                    GetRandom(100000000, 900000000).ToString(), GetRandom(100000000, 900000000).ToString(), "00000",
                    GetRandom(100000000, 900000000).ToString(),
                    prenoms[GetRandom(0, 13)] + "." + noms[GetRandom(0, 14)] + i + "@gmail.com");
                player.lastLogin = DateTime.Now;
                player.BallLevel = ballLevels[GetRandom(0, 9)];
                player.Status = statuses[GetRandom(0, 2)];
                player.Category.Add(categories[GetRandom(0, 3)]);

                players.Add(player);
            }

            _container.PlayerJeu.AddRange(players);
            _container.SaveChanges();
        }

        private void createBookings()
        {

            List<Player> players = new List<Player>(_container.PlayerJeu);
            List<Court> courts = new List<Court>(_container.CourtJeu);
            List<Booking> bookings = new List<Booking>();
            Booking booking;

            for (int i = 0; i < 600; i++)
            {
                booking = new Booking();
                booking.Court = courts[GetRandom(0, courts.Count - 1)];
                booking.Player1 = players[GetRandom(0, players.Count - 1)];
                booking.Player2 = players[GetRandom(0, players.Count - 1)];
                booking.name = i.ToString();
                booking.isSpecial = false;
                booking.start = DateTime.Now.AddDays(GetRandom(-200, 100)).AddHours(GetRandom(-5, 5));
                booking.end = booking.start.AddHours(1);
                booking.creationDate = booking.start.AddDays(-7);
                bookings.Add(booking);
            }

            _container.BookingJeu.AddRange(bookings);
            _container.SaveChanges();
        }

        private void createPayments()
        {
            List<Player> players = new List<Player>(_container.PlayerJeu);
            List<Semester> semesters = new List<Semester>(_container.SemesterJeu);
            List<PaymentMethod> methods = new List<PaymentMethod>(_container.PaymentMethodSet);
            List<Payment> payments = new List<Payment>();
            Payment payment;

            for (int i = 0; i < 80; i++)
            {
                payment = new Payment();
                payment.Player = players[GetRandom(0, players.Count - 1)];
                payment.date = DateTime.Now.AddMonths(GetRandom(-20, 0));
                payment.amount = GetRandom(10, 200);
                payment.PaymentMethod = methods[GetRandom(0, 2)];
                payment.Semester = new ObservableCollection<Semester> { semesters[GetRandom(0, semesters.Count - 1)] };
                payments.Add(payment);
            }

            _container.PaymentJeu.AddRange(payments);
            _container.SaveChanges();
        }

        private void createTraining()
        {
            List<Player> players = new List<Player>(_container.PlayerJeu);
            List<Day> days = new List<Day>(_container.DaySet);
            List<TrainingPreferences> preferenceses = new List<TrainingPreferences>(_container.TrainingPreferencesSet);
            TrainingPreferences pref;

            foreach (var player in players)
            {
                for (int i = 0; i < 4; i++)
                {
                    pref = new TrainingPreferences();
                    pref.Day = days[GetRandom(0, 6)];
                    pref.beginning = GetRandom(8, 23);
                    pref.end = pref.beginning + GetRandom(1, 4);

                    player.TrainingPreferences.Add(pref);
                }
            }

            _container.SaveChanges();
        }

        private void createBookingPrefs()
        {
            List<Player> players = new List<Player>(_container.PlayerJeu);
            List<Day> days = new List<Day>(_container.DaySet);
            List<PreferencePeriod> pref = new List<PreferencePeriod>(_container.PreferencePeriodJeu);
            PreferencePeriod p;

            foreach (var player in players)
            {
                for (int i = 0; i < 3; i++)
                {
                    p = new PreferencePeriod();
                    p.Day = days[GetRandom(0, 6)];
                    p.beginningHour = GetRandom(16, 23);
                    p.endHour = p.beginningHour + GetRandom(1, 3);
                    p.beginningMin = 30;
                    p.endmin = 0;

                    player.PreferencePeriod.Add(p);
                }

            }

            _container.SaveChanges();

        }

        private int GetRandom(int min, int max)
        {
            return rand.Next(min, max);
        }

        private Int64 GetBadgeNumber()
        {
            return (long)(rand.NextDouble() * 100000000);
        }



        private void AssignBadges()
        {
            List<Badge> badges = new List<Badge>(_container.BadgeJeu);
            List<Player> players = new List<Player>(_container.PlayerJeu);

            foreach (var badge in badges)
            {
                badge.Player = players[GetRandom(0, players.Count)];
            }


            _container.SaveChanges();
        }

        #region static
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
                _container.BallLevelSet.AddRange(new[] { blanche, jaune, orange, verte, rouge, raquette, mousse, souple, intermediaire });
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
                _container.StatusSet.AddRange(new[] { utilisateur, club, admin });
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
                _container.PaymentMethodSet.AddRange(new PaymentMethod[] { argentComptant, cheque, chequeVacance });
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

                _container.DaySet.AddRange(new Day[] { lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche });
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

                _container.CategorySet.AddRange(new[] { loisir, competition, ecoleDeTennis, entrainement });
            }
        }
        #endregion


    }
}
