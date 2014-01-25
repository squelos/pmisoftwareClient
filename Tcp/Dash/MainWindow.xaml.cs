using Dash.ViewModel;
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

namespace Dash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainViewModel _mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            //InkInputHelper.DisableWPFTabletSupport();
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //_mainViewModel.BadgeScanner.Dispose();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            if (mainViewModel != null)
            {
                _mainViewModel = mainViewModel;
            }

            //System.Windows.Automation.AutomationElement asForm =
            //   System.Windows.Automation.AutomationElement.FromHandle(new WindowInteropHelper(this).Handle);

            //// Windows 8 API to enable touch keyboard to monitor for focus tracking in this WPF application
            //InputPanelConfigurationLib.InputPanelConfiguration inputPanelConfig = new InputPanelConfigurationLib.InputPanelConfiguration();
            //inputPanelConfig.EnableFocusTracking();
        }
    }
}