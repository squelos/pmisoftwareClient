using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserImageDisplay.xaml
    /// </summary>
    public partial class UserImageDisplay : UserControl
    {
        private MainViewModel _mvm;

        public UserImageDisplay()
        {
            InitializeComponent();
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            _mvm = mainViewModel;
            imageBox.Source = _mvm.ImageViewModel.Source;
            _mvm.ImageViewModel.MoveRight += ImageViewModel_MoveRight;
            _mvm.ImageViewModel.MoveLeft += ImageViewModel_MoveLeft;
            _mvm.ImageViewModel.Fade += ImageViewModelOnFade;
        }

        private void ImageViewModelOnFade(object sender, ImageSource imgSource)
        {
            BeginStoryboard(FindResource("Fade") as Storyboard);
            Task t = new Task(() =>
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(() =>
                {
                    imageBox.Source = imgSource;
                });
            });
            t.Start();
        }

        void ImageViewModel_MoveLeft(object sender, ImageSource imgSource)
        {
            BeginStoryboard(FindResource("Fade") as Storyboard);
            Task t = new Task(() =>
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(() =>
                {
                    imageBox.Source = imgSource;
                });
            });
            t.Start();
        }

        void ImageViewModel_MoveRight(object sender, ImageSource imgSource)
        {
            BeginStoryboard(FindResource("Fade") as Storyboard);
            Task t = new Task(() =>
            {
                Thread.Sleep(500);
                Dispatcher.Invoke(() =>
                {
                    imageBox.Source = imgSource;
                });
            });
            t.Start();
        }


        private void ImageBox_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
            BeginStoryboard(FindResource("Storyboard1") as Storyboard);
        }

        private void LeftClick(object sender, RoutedEventArgs e)
        {
            _mvm.ImageViewModel.Back();
        }

        private void RightClick(object sender, RoutedEventArgs e)
        {
            _mvm.ImageViewModel.Forward();
        }
    }
}
