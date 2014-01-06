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
using TcpModernUI.BaseClasses;

namespace TcpModernUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : UserControl
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void OnClickPlayers(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.SetActiveTab(1);
          //  throw new NotImplementedException();
        }

        private void OnClickUnpaid(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.SetActiveTab(3);
            //throw new NotImplementedException();
        }
        private void OnClickNonRenew(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.SetActiveTab(4);
            //throw new NotImplementedException();
        }
        private void OnClickSeasons(object sender, RoutedEventArgs e)
        {
            CustomDispatcher.Instance.SetActiveTab(6);
            //throw new NotImplementedException();
        }
    }
}
