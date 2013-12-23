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

namespace TcpModernUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserBadge.xaml
    /// </summary>
    public partial class UserBadge : UserControl
    {
        public UserBadge()
        {
            InitializeComponent();
        }

        private void BadgesDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid != null && dataGrid.SelectedItems.Count == 1)
            {
                modif.IsSelected = true;

            }
        }
    }
}
