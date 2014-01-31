using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TcpDash.Business;

namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for DeletionWindow.xaml
    /// </summary>
    public partial class DeletionWindow
    {
        #region privates

        private VisualBooking _vb;
        #endregion


        #region ctor
        public DeletionWindow(VisualBooking vb)
        {
            InitializeComponent();
            _vb = vb;

            lDate.Content = _vb.Start.ToShortDateString();
            lCourt.Content = _vb.Booking.Court.number;
            string deb = _vb.StartHour + "h" + _vb.StartMin + "min";
            lStartTime.Content = deb;
            string end = _vb.EndHour + "h" + _vb.EndMin + "min";
            lEndTime.Content = end;
            lP1.Content = _vb.Booking.Player1;
            lP2.Content = _vb.Booking.Player2;
        }
        #endregion

        #region publics

        #endregion

        #region events

        #endregion

        #region private Methods

        #endregion

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            //try to delete

            //cant delete, show error

            //delete
            DialogResult = true;
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
