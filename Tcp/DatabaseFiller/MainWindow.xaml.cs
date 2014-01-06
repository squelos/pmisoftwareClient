using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
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
using System.Data.Entity;
using TcpDataModel;

namespace DatabaseFiller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rand = new Random();
        // private entityContainer _container = new entityContainer();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(Wrapper);
            t.Start();


        }

        private void Wrapper()
        {
           FixedPart();
            Task tBadges = new Task(()=> createBadges(pCreateBadges));
            Task tPlayers = new Task(() => createPlayers(pCreatePlayers));

            tPlayers.ContinueWith(task => createBookingPrefs(pCreateBookingPrefs));
            tPlayers.ContinueWith(task => createBookings(pCreateBookings));
            tPlayers.ContinueWith(task => createPayments(pCreatePayments));
            tPlayers.ContinueWith(task => createTraining(pCreateTraining));
            Task tAssignBadges = new Task(() => AssignBadges());
            tBadges.Start();
            tPlayers.Start();
            Task.WaitAll(new[] {tBadges, tPlayers, tPlayers});
            tAssignBadges.Start();

        }

        

        private void FixedPart()
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
            createTerrains();
            createSeasons(pCreateSeasons);
        }





        private void createBadges(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;

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
                    bar.Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => bar.Value = i / 200 * 100));
                }
                container.BadgeJeu.AddRange(badges);
                container.SaveChanges();

            }


        }

        private void createTerrains()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Court> courts = new List<Court>();
                courts.Add(new Court("terrain 1", true));
                courts.Add(new Court("terrain 2", false));
                courts.Add(new Court("Intérieur 1", true));
                courts.Add(new Court("Extérieur 3", false));
                container.CourtJeu.AddRange(courts);
                container.SaveChanges();
            }
        }

        private void createSeasons(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;

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

                semesters.Add(new Semester(DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(1)));
                semesters.Add(new Semester(DateTime.Now.AddMonths(2), DateTime.Now.AddMonths(3)));

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
                    bar.Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => bar.Value = i / 12 * 100));
                }

                //seasons.Add(new Season(semesters[0], semesters[1]));

                //seasons.Add(new Season(semesters[2], semesters[3]));
                //seasons.Add(new Season(semesters[4], semesters[5]));
                //seasons.Add(new Season(semesters[6], semesters[7]));
                //seasons.Add(new Season(semesters[8], semesters[9]));
                //seasons.Add(new Season(semesters[10], semesters[11]));

                //_container.SemesterJeu.AddRange(semesters);
                container.SeasonJeu.AddRange(seasons);
                container.SaveChanges();
            }

        }

        private void createPlayers(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Player> players = new List<Player>();

                List<string> prenoms = new List<string>(new[]
                                                        {
                                                            "Christopher", "luke", "Nathan", "Olivier", "Frederic",
                                                            "Manon", "Louise", "Sarah", "Emma", "Lea", "Enzo",
                                                            "Camille", "Gabriel", "Ethan", "Abraham", "Hodiya ",
                                                            "Hédèr ",
                                                            "Laviv", "Achebèl ", "Èliêzèr  ", "Èlnatane ", "Guil",
                                                            "Néhèmia",
                                                            "Brendan", "Alan", "Allan", "Brice", "Bryan", "Erwann",
                                                            "Fiacre", "Gael", "Nigel", "Nelly", "Nolann", "Rohan",
                                                            "Gwladys", "Goulwen", "Tangi", "Gwendoline", "Rowena",
                                                            "Roween",
                                                        });
                //14

                List<string> noms = new List<string>(new[]
                                                     {
                                                         "Tremblay", "Gagnon", "Roy", "Côté", "Bouchard", "Gauthier",
                                                         "Morin",
                                                         "Lavoie", "Fortin", "Gagné", "Ouellet", "Pelletier", "Bélanger",
                                                         "Lévesque", "Bergeron",
                                                         "Bernard", "Schmitt", "Martin", "Klein", "Byche", "Simon",
                                                         "Michel", "Jacob",
                                                         "Mayer", "Meyer", "Koch", "Wolf", "Wolff", "Kirsch", "Raymond",
                                                         "Guyot",
                                                         "Hamm", "Scherer", "Grosse", "Marx", "Thiel", "Rodriguez",
                                                         "Tritz", "Robert",
                                                         "Beck", "Philippe", "Weiss", "Ricard", "Picard", "Husson",
                                                         "Lefort", "Barthel",
                                                     });
                //15
                List<string> cp = new List<string>(new[]
                                                   {
                                                       "01067", "01445", "01454 ", "01465 ", "01468", "01558 ", "01609 ",
                                                       "01616 ", "01621", "01631", "01662", "01683 ", "09376 ", "09456 ",
                                                       "09526 "
                                                   });
                //15
                List<string> listRue = new List<string>(new[]
                                                        {
                                                            "Rue de l'eglise", "Place de l'eglise", "Grande Rue ",
                                                            "Rue du moulin ", "Place de la mairie", "Rue du chateau ",
                                                            "Rue des ecoles ",
                                                            "Rue de la gare ", "Rue de la mairie", "rue principale",
                                                            "Rue secondaire", "Rue des acacias ", "Rue de la fontaine ",
                                                            "Rue Pasteur ", "Rue des juifs "
                                                        });
                //15
                List<string> listVilles = new List<string>(new[]
                                                           {
                                                               "Paris", "Nancy", "Metz ", "Longwy", "Luxembourg",
                                                               "Montreal", "Quebec"
                                                               , "Montpellier", "Aix"

                                                           });
                //7

                List<BallLevel> ballLevels = new List<BallLevel>(container.BallLevelSet);
                List<Category> categories = new List<Category>(container.CategorySet);
                List<Status> statuses = new List<Status>(container.StatusSet);
                RandomString stringGen = new RandomString();
                string pass;

                for (int i = 0; i < 600; i++)
                {
                    int p = GetRandom(0, prenoms.Count);
                    int n = GetRandom(0, noms.Count);
                    Player player = new Player(prenoms[p], noms[n],
                        DateTime.Now.AddYears(GetRandom(-50, -10)),
                        "30/" + GetRandom(1, 5), prenoms[p] + "." + noms[n] + "@gmail.com",
                        GetRandom(1, 120).ToString() + " " + listRue[GetRandom(0, 14)], cp[GetRandom(0, 14)],
                        listVilles[GetRandom(0, listVilles.Count)],
                        GetRandom(100000000, 900000000).ToString(), GetRandom(100000000, 900000000).ToString(), "00000",
                        GetRandom(100000000, 900000000).ToString(),
                        prenoms[p] + "." + noms[n] + i + "@gmail.com");
<<<<<<< HEAD
                    
=======
                    //player.lastLogin = DateTime.Now;
                    player.passwordReset = stringGen.GetRandomString(8);
>>>>>>> bd55e95d2ab39f94d28a6cbfe7b2ab28720a2610
                    player.BallLevel = ballLevels[GetRandom(0, 9)];
                    player.Status = statuses[GetRandom(0, 2)];
                    player.Category.Add(categories[GetRandom(0, 3)]);
                    player.salt = stringGen.GetRandomString(32);
                    pass = "password" + i;
                    player.passwordHash = GenerateSaltedHash(pass, player.salt);
                    players.Add(player);
                    bar.Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => bar.Value = i / 600 * 100));
                }

                container.PlayerJeu.AddRange(players);
                container.SaveChanges();
            }
        }

        static string GenerateSaltedHash(string text,string saltStr)
        {
            byte[] plainText = Encoding.UTF8.GetBytes(text);
            byte[] salt = Encoding.UTF8.GetBytes(saltStr);
            HashAlgorithm algo = new SHA256Managed();
            byte[] plainTextWithSaltBytes =
                new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return Encoding.UTF8.GetString(algo.ComputeHash(plainTextWithSaltBytes)); 
        }

        public static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CompareStrings(string str1, string str2)
        {
            byte[] array1 = Encoding.UTF8.GetBytes(str1);
            byte[] array2 = Encoding.UTF8.GetBytes(str2);
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void createBookings(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Player> players = new List<Player>(container.PlayerJeu);
                List<Court> courts = new List<Court>(container.CourtJeu);
                List<Booking> bookings = new List<Booking>();
                Booking booking;

                for (int i = 0; i < 500; i++)
                {
                    booking = new Booking();
                    booking.Court = courts[GetRandom(0, courts.Count - 1)];
                    booking.Player1 = players[GetRandom(0, players.Count - 1)];
                    booking.Player2 = players[GetRandom(0, players.Count - 1)];
                    booking.name = i.ToString();
                    booking.isSpecial = false;
                    booking.start = DateTime.Now.AddDays(GetRandom(-200, 100)).AddHours(GetRandom(-5, 5));
                    booking.end = booking.start.AddHours(1);
                    booking.creationDate = booking.start.AddDays(GetRandom(-20, -4));
                    booking.Filmed = false;
                    bookings.Add(booking);
                }

                container.BookingJeu.AddRange(bookings);
                container.SaveChanges();
            }
        }

        private void createPayments(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Player> players = new List<Player>(container.PlayerJeu);
                List<Semester> semesters = new List<Semester>(container.SemesterJeu);
                List<PaymentMethod> methods = new List<PaymentMethod>(container.PaymentMethodSet);
                List<Payment> payments = new List<Payment>();
                Payment payment;

                List<string> listRaisons = new List<string>(new[]
                                                            {
                                                                "Veteran", "Junion ", "Jeune", "Enfant école de tennis",
                                                                "Veteran compétition", "Enfant entraînement"

                                                            });
                for (int i = 0; i < 600; i++)
                {
                    payment = new Payment();
                    payment.Player = players[GetRandom(0, players.Count - 1)];
                    payment.date = DateTime.Now.AddMonths(GetRandom(-20, 0));
                    payment.amount = GetRandom(10, 200);
                    payment.invalid = false;
                    payment.comment = "";
                    payment.PaymentMethod = methods[GetRandom(0, 2)];
                    payment.raison = listRaisons[GetRandom(0, listRaisons.Count)];
                    payment.Semester = new ObservableCollection<Semester> { semesters[GetRandom(0, semesters.Count - 1)] };
                    payments.Add(payment);
                    bar.Dispatcher.BeginInvoke(DispatcherPriority.Background, (ThreadStart)(() => bar.Value = i / 1200 * 100));
                }

                container.PaymentJeu.AddRange(payments);
                container.SaveChanges();
            }
        }

        private void createTraining(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Player> players = new List<Player>(container.PlayerJeu);
                List<Day> days = new List<Day>(container.DaySet);
                List<TrainingPreferences> preferenceses =
                    new List<TrainingPreferences>(container.TrainingPreferencesSet);
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

                container.SaveChanges();
            }
        }

        private void createBookingPrefs(ProgressBar bar)
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Player> players = new List<Player>(container.PlayerJeu);
                List<Day> days = new List<Day>(container.DaySet);
                List<PreferencePeriod> pref = new List<PreferencePeriod>(container.PreferencePeriodJeu);
                PreferencePeriod p;
                int numPlayers = players.Count;
                int y = 0;

                foreach (var player in players)
                {
                    y++;
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
                    bar.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                        (ThreadStart)(() => bar.Value = y / numPlayers * 100));
                }
                container.SaveChanges();
            }
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
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                List<Badge> badges = new List<Badge>(container.BadgeJeu);
                List<Player> players = new List<Player>(container.PlayerJeu);
                int numBadges = badges.Count;
                badges.Add(new Badge(4151116, true, false));
                badges.Add(new Badge(4127606, true, false));
                badges.Add(new Badge(4088790, true, false));
                int i = 0;

                foreach (var badge in badges)
                {
                    var pl = players[GetRandom(0, players.Count)];
                    badge.Player = pl;
                    pl.Badge.Add(badge);
                    
                    i++;
                   
                }


                container.SaveChanges();
            }
        }

        #region static
        private void CreateBallLevels()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                if (container.BallLevelSet.Count() == 0)
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
                    container.BallLevelSet.AddRange(new[]
                                                     {
                                                         blanche, jaune, orange, verte, rouge, raquette, mousse, souple,
                                                         intermediaire
                                                     });
                    container.SaveChanges();
                }
                
            }


        }

        private void CreateStatus()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                if (container.StatusSet.Count() == 0)
                {
                    Status utilisateur = new Status();
                    utilisateur.statusName = "Utilisateur";
                    Status club = new Status();
                    club.statusName = "Club";
                    Status admin = new Status();
                    admin.statusName = "Administrateur";
                    container.StatusSet.AddRange(new[] { utilisateur, club, admin });
                    container.SaveChanges();
                }
            }
        }

        private void CreatePaymentMethods()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                if (container.PaymentMethodSet.Count() == 0)
                {
                    PaymentMethod argentComptant = new PaymentMethod();
                    argentComptant.methodName = "Argent comptant";
                    PaymentMethod cheque = new PaymentMethod();
                    cheque.methodName = "Chèque";
                    PaymentMethod chequeVacance = new PaymentMethod();
                    chequeVacance.methodName = "Chèque vacance";
                    container.PaymentMethodSet.AddRange(new PaymentMethod[] { argentComptant, cheque, chequeVacance });
                    container.SaveChanges();
                }
            }
        }

        private void CreateDays()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                if (container.DaySet.Count() == 0)
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

                    container.DaySet.AddRange(new Day[] { lundi, mardi, mercredi, jeudi, vendredi, samedi, dimanche });
                    container.SaveChanges();
                }
            }
        }

        private void CreateCategories()
        {
            using (entityContainer container = new entityContainer())
            {
                container.Configuration.AutoDetectChangesEnabled = false;
                if (container.CategorySet.Count() == 0)
                {
                    Category loisir = new Category();
                    loisir.categoryName = "Loisir";
                    Category competition = new Category();
                    competition.categoryName = "Compétition";
                    Category ecoleDeTennis = new Category();
                    ecoleDeTennis.categoryName = "Ecole de Tennis";
                    Category entrainement = new Category();
                    entrainement.categoryName = "Entraînement";

                    container.CategorySet.AddRange(new[] { loisir, competition, ecoleDeTennis, entrainement });
                    container.SaveChanges();
                }
            }
        }
        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            createBookings(pCreateBookings);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            createPayments(pCreatePayments);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (entityContainer container = new entityContainer())
            {
                List<Player> players =  new List<Player>(container.PlayerJeu);
                Player p = (from a in container.PlayerJeu where a.ID == 1 select a).First();

                if(CompareStrings(GenerateSaltedHash("password0",p.salt), p.passwordHash))
                {
                    Console.Out.WriteLine("Yes");
                }
                else
                {
                    Console.Out.WriteLine("No");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AssignBadges();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            using (entityContainer container = new entityContainer())
            { 
                List<Badge> badges = new List<Badge>();
                badges.Add(new Badge(4151116, true, false));
                badges.Add(new Badge(4253563, true, false));
                badges.Add(new Badge(4086466, true, false));
                badges.Add(new Badge(4139734, true, false));
                badges.Add(new Badge(4115639, true, false));
                container.BadgeJeu.AddRange(badges);

                List<Player> players = new List<Player>(container.PlayerJeu.Include(player => player.Badge));
                for (int i = 0; i < 5; i++)
                {
                    players[i].Badge.Add(badges[i]);
                }
                container.SaveChanges();
            }
        }




    }
}
