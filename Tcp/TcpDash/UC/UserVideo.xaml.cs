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
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserVideo.xaml
    /// </summary>
    public partial class UserVideo : UserControl
    {
        public UserVideo()
        {
            InitializeComponent();
        }
        private void Previous(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel) DataContext;
            vm.VideoViewModel.PreviousCommand.Execute(null);
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.VideoViewModel.PauseCommand.Execute(null);
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.VideoViewModel.PlayCommand.Execute(null);
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            var vm = (MainViewModel)DataContext;
            vm.VideoViewModel.NextCommand.Execute(null);
        }

    }
}
