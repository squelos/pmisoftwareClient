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
using TcpDashboard.Business;

namespace TcpDashboard.UserControls
{
    /// <summary>
    /// Interaction logic for UserCourt.xaml
    /// </summary>
    public partial class UserCourt : UserControl
    {
        #region depProp

        public static readonly DependencyProperty CourtBookingsProperty =
            DependencyProperty.Register("CourtBookings", typeof(CourtBookings), typeof(UserCourt));

        #endregion

        #region ctor
        public UserCourt()
        {
            InitializeComponent();
        }
        #endregion

        #region getters/setters

        public CourtBookings CourtBooking
        {
            get { return (CourtBookings)GetValue(CourtBookingsProperty); }
            set { SetValue(CourtBookingsProperty, value); }
        }
        #endregion
    }
}
