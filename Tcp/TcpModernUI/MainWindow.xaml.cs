using System.Windows;
using MahApps.Metro.Controls;
using TcpModernUI.BaseClasses;
using TcpModernUI.Utility;

namespace TcpModernUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            
        }

        private void LaunchFlyoutDemo(object sender, RoutedEventArgs e)
        {
            new TestFlyout().Show();
        }
    }
}
