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
using TcpDataModel;
using TcpGA.ViewModel;

namespace TcpGA.UserControls
{
    /// <summary>
    /// Interaction logic for UserNonRenew.xaml
    /// </summary>
    public partial class UserNonRenew : UserControl
    {
        private MainViewModel _mainViewModel;
        public UserNonRenew()
        {
            InitializeComponent();
            var dataContext = DataContext;
            _mainViewModel = dataContext as MainViewModel;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _mainViewModel.NonRenewViewModel.NewPayment.Semester.Clear();

            foreach (var item in (sender as ListBox).SelectedItems)
            {
                _mainViewModel.NonRenewViewModel.NewPayment.Semester.Add((Semester)item);
            }
        }
    }
}
