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
using MahApps.Metro.Controls;
using TcpDataModel;

namespace TcpDashboard.UserControls
{
    /// <summary>
    /// Interaction logic for userCalendar.xaml
    /// </summary>
    public partial class userCalendar : UserControl
    {
        public static readonly DependencyProperty CourtProperty =
            DependencyProperty.Register("Court", typeof(Court), typeof (MetroWindow));

        public userCalendar()
        {
            InitializeComponent();
        }
    }
}
