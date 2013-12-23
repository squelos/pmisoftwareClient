using System.Windows.Controls;
using TcpDataModel;
using TcpModernUI.ViewModel;

namespace TcpModernUI.UserControls
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
