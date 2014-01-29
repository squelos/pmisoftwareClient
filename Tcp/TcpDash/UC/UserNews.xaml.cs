using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserNews.xaml
    /// </summary>
    public partial class UserNews : UserControl
    {
        private MainViewModel _mvm;
        private TouchPoint _touchStart;
        private SwipeHelper _helper = new SwipeHelper();

        public UserNews()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataContext = DataContext;
                var mainViewModel = dataContext as MainViewModel;
                _mvm = mainViewModel;
                if (_mvm != null) _mvm.NewsViewModel.PropertyChanged += NewsViewModelOnPropertyChanged;
            }
            catch (Exception ex)
            {

                Console.Out.WriteLine(ex);
            }

        }

        private void NewsViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            web.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(LoadHtmlInWeb));
            //throw new NotImplementedException();
        }

        private void LoadHtmlInWeb()
        {
            web.NavigateToString("<head></head><body bgcolor=\"#D45B07\">" + _mvm.NewsViewModel.CurrentNews.Content + "</body>");
            //TODO crashes

        }

        private void UserNews_OnTouchDown(object sender, TouchEventArgs e)
        {
            _touchStart = e.GetTouchPoint(this);
        }

        private void UserNews_OnTouchMove(object sender, TouchEventArgs e)
        {
            if (!_helper.Swipped)
            {
                var Touch = e.GetTouchPoint(this);
                //right now a swipe is 200 pixels 

                //Swipe Left
                if (_touchStart != null && Touch.Position.X > (_touchStart.Position.X + 200))
                {
                    //swipe left
                    _mvm.CalendarViewModel.DecrementCommand.Execute(null);
                    
                    _helper.Swipped = true;
                }

                //Swipe Right

                if (_touchStart != null && Touch.Position.X < (_touchStart.Position.X - 200))
                {
                    //swipe right
                    _mvm.CalendarViewModel.IncrementCommand.Execute(null);
                    _helper.Swipped = true;
                }
            }
            e.Handled = true;
        }
    }
}