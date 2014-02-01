using System.Windows;
using System.Windows.Controls;
using TcpDash.Business;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserWorking.xaml
    /// </summary>
    public partial class UserWorking : UserControl
    {
        private BookingManager _bm;

        public UserWorking()
        {
            InitializeComponent();
            _bm = BookingManager.Instance;
            _bm.WorkingChanged += _bm_WorkingChanged;
        }

        private void _bm_WorkingChanged(object sender, int value)
        {
            if (value != 0)
            {
                ProgressBar.Visibility = Visibility.Visible;
            }
            else
            {
                ProgressBar.Visibility = Visibility.Hidden;
            }
        }
    }
}