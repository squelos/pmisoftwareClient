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
    /// Interaction logic for UserDay.xaml
    /// </summary>
    public partial class UserDay : UserControl
    {

        #region privates

        private bool _weekMode = false;
        private CourtBookings _courtBookings;
        #endregion


        #region ctor
        public UserDay()
        {
            InitializeComponent();
        }

        #endregion

        #region getters/setters

        public bool WeekMode
        {
            get { return _weekMode; }
            set
            {
                _weekMode = value;
                //refresh
                Refresh();
            }
        }

        public CourtBookings CourtB
        {
            get { return _courtBookings; }
            set
            {
                _courtBookings = value;
                //refresh here
                Refresh();
            }
        }
       
        #endregion

        #region publics

        #endregion

        #region privates

        private void Refresh()
        {
            
        }
        #endregion
    }
}
