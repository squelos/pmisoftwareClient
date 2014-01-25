using Dash.Business;
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

namespace Dash.UC
{
    /// <summary>
    /// Interaction logic for UserCourt.xaml
    /// </summary>
    public partial class UserCourt : UserControl
    {
        #region depProp
        public static readonly DependencyProperty WModeProperty = DependencyProperty.Register("WMode", typeof(bool), typeof(UserControl));

        public static readonly DependencyProperty CourtBProperty = DependencyProperty.Register("CourtB", typeof(CourtBookings), typeof(UserControl));


        #endregion

        #region ctor

        public UserCourt()
        {
            InitializeComponent();
        }

        #endregion

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
    }
}