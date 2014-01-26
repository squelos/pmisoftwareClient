﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TcpDash.ViewModel;

namespace TcpDash.UC
{
    /// <summary>
    /// Interaction logic for UserNews.xaml
    /// </summary>
    public partial class UserNews : UserControl
    {
        private MainViewModel _mvm;

        public UserNews()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var dataContext = DataContext;
                var mainViewModel = dataContext as MainViewModel;
                _mvm = mainViewModel;
                if (_mvm != null) _mvm.NewsViewModel.PropertyChanged += NewsViewModelOnPropertyChanged;
            }
            catch (Exception ex)
            {

                Console.Out.WriteLine(ex);
            }

        }

        private void NewsViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            web.Dispatcher.BeginInvoke(DispatcherPriority.Background, new ThreadStart(LoadHtmlInWeb));
            //throw new NotImplementedException();
        }

        private void LoadHtmlInWeb()
        {
            web.NavigateToString("<head></head><body bgcolor=\"#D45B07\">" + _mvm.NewsViewModel.CurrentNews.Content + "</body>");

        }
    }
}