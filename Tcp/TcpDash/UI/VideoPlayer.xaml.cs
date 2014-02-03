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
using System.Windows.Shapes;


namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for VideoPlayer.xaml
    /// </summary>
    public partial class VideoPlayer 
    {
        public VideoPlayer()
        {
            InitializeComponent();
            
            SetFullScreen();
        }

        private void SetFullScreen()
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
    }
}
