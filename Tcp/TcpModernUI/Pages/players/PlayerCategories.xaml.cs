using System.Windows.Controls;
using System.Windows.Input;
using TcpModernUI.ViewModel;

namespace TcpModernUI.Pages.players
{
    /// <summary>
    /// Interaction logic for PlayerCategories.xaml
    /// </summary>
    public partial class PlayerCategories : UserControl
    {
        public PlayerCategories()
        {
            InitializeComponent();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //add here
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
           // mainViewModel.PlayersViewModel.SelectedPlayer.Category.Add(sender);
        }

        private void Control1_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // remove here
            // throw new System.NotImplementedException();
        }
    }
}
