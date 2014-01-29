using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TcpDash.Business;

namespace TcpDash
{
    /// <summary>
    /// Interaction logic for WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin
    {

        private string _password = "Tennis1";
        public WindowAdmin()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //close
            this.DialogResult = false;
            this.Close();

        }

        private void ValidOnclick(object sender, RoutedEventArgs e)
        {
            //validate
            if (passwordBox.Password == _password)
            {
                //then password matches
                //Utility.StartExplorer();
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }

        private void WindowAdmin_OnClosing(object sender, CancelEventArgs e)
        {
            if(DialogResult != true)
            this.DialogResult = false;
        }

       
    }
}
