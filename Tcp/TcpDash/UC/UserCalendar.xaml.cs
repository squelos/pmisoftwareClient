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

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserCalendar.xaml
    /// </summary>
    public partial class UserCalendar : UserControl
    {
        private TouchPoint _touchStart;
        private SwipeHelper _helper = new SwipeHelper();
        public UserCalendar()
        {
            InitializeComponent();
        }

        private void UserCalendar_OnTouchDown(object sender, TouchEventArgs e)
        {
            _touchStart = e.GetTouchPoint(this);
        }

        private void UserCalendar_OnTouchMove(object sender, TouchEventArgs e)
        {
            if (!_helper.Swipped)
            {
                var Touch = e.GetTouchPoint(this);
                //right now a swipe is 200 pixels 

                //Swipe Left
                if (_touchStart != null && Touch.Position.X > (_touchStart.Position.X + 200))
                {
                    //swipe left

                    tab.PreviousTab();
                    _helper.Swipped = true;
                }

                //Swipe Right

                if (_touchStart != null && Touch.Position.X < (_touchStart.Position.X - 200))
                {
                    //swipe right
                    tab.NextTab();
                    _helper.Swipped = true;
                }
            }
            e.Handled = true;
        }
    }
}
