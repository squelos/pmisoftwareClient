using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpDataModel;

namespace TcpModernUI.ViewModels
{
    public class BadgesViewModel
    {
        private ObservableCollection<Badge> _badges = new ObservableCollection<Badge>();
        private Badge _badge;

        public BadgesViewModel()
        {
            
        }
    }
}
