using System.Windows;
using MahApps.Metro.Controls;

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