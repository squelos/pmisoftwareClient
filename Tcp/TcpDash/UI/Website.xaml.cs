using System;
using System.Collections.Generic;
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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TcpDash.Business;

namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for Website.xaml
    /// </summary>
    public partial class Website
    {
        public Website()
        {
            InitializeComponent();
            AutoClose();
        }

        private void AutoClose()
        {
            Task t = new Task(() =>
            {
                Thread.Sleep(30000);
                if (Utility.GetLastInputTimeMinutes() > 2)
                {
                    Dispatcher.Invoke(Close);
                }
            });
        }
    }
}
