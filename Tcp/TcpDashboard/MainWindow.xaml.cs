using System.Windows;
using TcpDashboard.ViewModel;

namespace TcpDashboard
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
