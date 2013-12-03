

using System.Windows;
using MahApps.Metro.Controls;

namespace TcpModernUI.BaseClasses
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TestFlyout
    {
        public TestFlyout()
        {
            InitializeComponent();
            
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            ToggleFlyout(0);
        }

        private void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
