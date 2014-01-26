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
using TcpDash.Business;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserCourt.xaml
    /// </summary>
    public partial class UserCourt : UserControl
    {
        #region getters/setters

        public bool WMode
        {
            get { return (bool)GetValue(WModeProperty); }
            set { SetValue(WModeProperty, value); }
        }

        public CourtBookings CourtB
        {
            get { return (CourtBookings)GetValue(CourtBProperty); }
            set { SetValue(CourtBProperty, value); }
        }




        #endregion

        #region depProp
        public static readonly DependencyProperty WModeProperty = DependencyProperty.Register("WMode", typeof(bool), typeof(UserCalendar),new PropertyMetadata(false));

        public static readonly DependencyProperty CourtBProperty = DependencyProperty.Register("CourtB", typeof(CourtBookings), typeof(UserCalendar), new PropertyMetadata(false));


        #endregion

        #region ctor

        public UserCourt()
        {
            InitializeComponent();
        }

        #endregion

     
    }
}