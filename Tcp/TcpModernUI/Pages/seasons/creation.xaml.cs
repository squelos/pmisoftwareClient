﻿using System;
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
using TcpDataModel;


namespace TcpModernUI.Pages.seasons
{
    /// <summary>
    /// Interaction logic for creation.xaml
    /// </summary>
    public partial class creation : UserControl
    {
        private entityContainer _container = new entityContainer();

        public creation()
        {
            InitializeComponent();
            _container = new entityContainer();
            
            
        }
    }
}
