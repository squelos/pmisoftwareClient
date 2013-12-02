using System.ComponentModel;
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls;
using TcpDataModel.Annotations;

namespace TcpModernUI.Flyouts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FlyoutBadges : Flyout, INotifyPropertyChanged
    {
        public FlyoutBadges()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
