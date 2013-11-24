﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TcpModernUI.ViewModels;

namespace TcpModernUI.Commands
{
    public class SeasonsCancelCommand : ICommand
    {
        private SeasonsViewModel _vm;
        public SeasonsCancelCommand(SeasonsViewModel vm)
        {
            _vm = vm;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.Cancel();
        }

        public event EventHandler CanExecuteChanged;
    }
}
