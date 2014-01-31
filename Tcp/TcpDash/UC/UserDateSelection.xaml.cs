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
using TcpDash.Classes;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserDateSelection.xaml
    /// </summary>
    public partial class UserDateSelection : UserControl
    {
        private TouchPoint _touchStart;
        private SwipeHelper _helper = new SwipeHelper();
        public UserDateSelection()
        {
            InitializeComponent();
        }

        private void UserDateSelection_OnTouchMove(object sender, TouchEventArgs e)
        {
            if (!_helper.Swipped)
            {
                var Touch = e.GetTouchPoint(this);
                //right now a swipe is 200 pixels 

                //Swipe Left
                if (_touchStart != null && Touch.Position.X > (_touchStart.Position.X + 200))
                {
                    //swipe left
                    var dataContext = DataContext;
                    var mainViewModel = dataContext as MainViewModel;
                    mainViewModel.NewsViewModel.DecrementCommand.Execute(null);
                    _helper.Swipped = true;
                }

                //Swipe Right

                if (_touchStart != null && Touch.Position.X < (_touchStart.Position.X - 200))
                {
                    //swipe right
                    var dataContext = DataContext;
                    var mainViewModel = dataContext as MainViewModel;
                    mainViewModel.NewsViewModel.IncrementCommand.Execute(null);
                    _helper.Swipped = true;
                }
            }
            e.Handled = true;
        }

        private void UserDateSelection_OnTouchDown(object sender, TouchEventArgs e)
        {
            _touchStart = e.GetTouchPoint(this);
        }
    }
}
