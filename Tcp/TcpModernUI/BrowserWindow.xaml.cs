using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using TcpModernUI.BaseClasses;
using TcpModernUI.Utility;

namespace TcpModernUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BrowserWindow : MetroWindow
    {
        public BrowserWindow()
        {
            InitializeComponent();
            
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //    this.Browser.Navigate("http://172.17.100.1/max/dev/");
            this.Browser.Navigate("http://www.google.fr");
            
        }

       
    }
}
