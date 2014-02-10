﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TcpDash.Business;
using TcpDash.ViewModel;

namespace TcpDash.UI
{
    /// <summary>
    /// Interaction logic for ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow
    {
        private MainViewModel _mvm;

        public ImageWindow()
        {
            InitializeComponent();
            var dataContext = DataContext;
            var mainViewModel = dataContext as MainViewModel;
            _mvm = mainViewModel;

            Task t = new Task(() =>
            {
                //we check to autoClose
                while (true)
                {
                    if (Utility.GetLastInputTime() > 2)
                    {
                        Dispatcher.Invoke(Close);
                    }
                    Thread.Sleep(30000);
                }
            });
        }
    }
}