using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpDataModel;
using TcpModernUI.BaseClasses;

namespace TcpModernUI.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {
        private entityContainer _container = new entityContainer();
        private Player _player = new Player();
        private ObservableCollection<Player> _players = new ObservableCollection<Player>();

        public PlayersViewModel()
        {
            
        }


    }
}
