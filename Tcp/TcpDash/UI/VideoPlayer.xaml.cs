using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TcpDash.ViewModel;


namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer
    {

        private MainViewModel _mvm;
        public VideoPlayer()
        {
            InitializeComponent();
            if (Screen.AllScreens.Length > 1)
            {
                Screen s2 = Screen.AllScreens[1];
                System.Drawing.Rectangle r2 = s2.WorkingArea;
                this.Top = r2.Top;
                Left = r2.Left;

            }
           // SetFullScreen();
        }

        public void SetFullScreen()
        {
            var secondaryScreen = System.Windows.Forms.Screen.AllScreens.FirstOrDefault(s => !s.Primary);

            if (secondaryScreen != null)
            {
                if (!this.IsLoaded)
                    this.WindowStartupLocation = WindowStartupLocation.Manual;

                var workingArea = secondaryScreen.WorkingArea;
                this.Left = workingArea.Left;
                this.Top = workingArea.Top;
                this.Width = workingArea.Width;
                this.Height = workingArea.Height;
                // If window isn't loaded then maxmizing will result in the window displaying on the primary monitor
                if (this.IsLoaded)
                    this.WindowState = WindowState.Maximized;
            }

        }

        private void MediaElem_OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
           MediaElem.Play();
        }

        public void Play()
        {
            MediaElem.Play();
        }

        public void Play(Uri ui)
        {
            
            MediaElem.Source = ui;
            MediaElem.Play();
        }

        public void Pause()
        {
            MediaElem.Pause();
        }

        private void VideoPlayer_OnLoaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            _mvm = mainViewModel;
            

            
        }
        
    }
}
