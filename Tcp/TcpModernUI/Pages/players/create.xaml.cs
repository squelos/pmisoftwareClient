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
using System.Data.Entity;

namespace TcpModernUI.Pages.players
{
    /// <summary>
    /// Interaction logic for create.xaml
    /// </summary>
    public partial class create : UserControl
    {
        private entityContainer _container = new entityContainer();

        public create()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource playerViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("playerViewSource")));

            _container.PlayerJeu.Load();

            playerViewSource.Source = _container.PlayerJeu.Local;
            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //save
            foreach(var player  in _container.PlayerJeu.Local.ToList())
            {
                if(player.firstName == "" || player.firstName == "")
                {
                    _container.PlayerJeu.Remove(player);
                }
            }
            _container.SaveChanges();
            this.playerDataGrid.Items.Refresh();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //cancel
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //this._container.Dispose();
        }
    }
}
