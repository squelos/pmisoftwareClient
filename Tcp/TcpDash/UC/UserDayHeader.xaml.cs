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
    /// Interaction logic for UserDayHeader.xaml
    /// </summary>
    public partial class UserDayHeader : UserControl
    {
        private DateTime _firstDayOfWeek;
        public UserDayHeader()
        {
            InitializeComponent();
        }

        public DateTime FirstDayOfWeek
        {
            get { return _firstDayOfWeek; }
            set
            {
                _firstDayOfWeek = value;
                Refresh();    
            }
        }

        private void Refresh()
        {
            lMonday.Content = _firstDayOfWeek.ToShortDateString();

            lTuesday.Content = _firstDayOfWeek.AddDays(1).ToShortDateString();

            lWednesday.Content = _firstDayOfWeek.AddDays(2).ToShortDateString() ;

            lThursday.Content = _firstDayOfWeek.AddDays(3).ToShortDateString() ;

            lFriday.Content = _firstDayOfWeek.AddDays(4).ToShortDateString() ;

            lSaturday.Content = _firstDayOfWeek.AddDays(5).ToShortDateString() ;

            lSunday.Content = _firstDayOfWeek.AddDays(6).ToShortDateString();
        }
    }
}