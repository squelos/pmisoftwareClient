using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpModernUI.ViewModels;

namespace TcpModernUI.Commands
{
    class PlayerSaveCommand : ICommand
    {
           
        private PlayersViewModel _vm;

        public PlayerSaveCommand(PlayersViewModel vm)
        {
            _vm = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            _vm.Save();
        }

        public event EventHandler CanExecuteChanged;
    }
}
