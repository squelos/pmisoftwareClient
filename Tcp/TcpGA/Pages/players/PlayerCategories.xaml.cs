using System.Windows.Controls;
using System.Windows.Input;
using TcpDataModel;
using TcpGA.ViewModel;

namespace TcpGA.Pages.players
{
    /// <summary>
    /// Interaction logic for PlayerCategories.xaml
    /// </summary>
    public partial class PlayerCategories : UserControl
    {
        private MainViewModel viewModel;
        public PlayerCategories()
        {
            InitializeComponent();
            var dataContext = DataContext;
            viewModel = dataContext as MainViewModel;
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //add here
            if (!CheckSelectedPlayer()) return;
            Category cat = listCats.SelectedValue as Category;

            if (!viewModel.PlayersViewModel.SelectedPlayer.Category.Contains(cat))
            {
                viewModel.PlayersViewModel.SelectedPlayer.Category.Add(cat);
                viewModel.PlayersViewModel.RaisePropertyChangedEvent("category");
            }

        }

        private void Control1_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // remove here
            if (!CheckSelectedPlayer()) return;
            Category cat = listCats.SelectedValue as Category;

            viewModel.PlayersViewModel.SelectedPlayer.Category.Remove(cat);
            viewModel.PlayersViewModel.RaisePropertyChangedEvent("category");
            // throw new System.NotImplementedException();
        }

        private bool CheckSelectedPlayer()
        {

            return viewModel.PlayersViewModel.SelectedPlayer != null;
        }
    }
}
