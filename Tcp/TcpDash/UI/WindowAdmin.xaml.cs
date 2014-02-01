using System.ComponentModel;
using System.Windows;

namespace TcpDash.UI
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
            if (DialogResult != true)
                this.DialogResult = false;
        }
    }
}