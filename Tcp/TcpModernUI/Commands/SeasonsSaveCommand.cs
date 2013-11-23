using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TcpModernUI.ViewModels;

namespace TcpModernUI.Commands
{
    public class SeasonsSaveCommand : ICommand
    {
        private SeasonsViewModel _seasonsViewModel;

        public SeasonsSaveCommand(SeasonsViewModel vm)
        {
            _seasonsViewModel = vm;
        }
        public bool CanExecute(object parameter)
        {
            
            return true;
        }

        public void Execute(object parameter)
        {
            _seasonsViewModel.Save();
        }

        public event EventHandler CanExecuteChanged;
    }
}
