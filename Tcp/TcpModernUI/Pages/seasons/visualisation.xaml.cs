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
    /// Interaction logic for visualisation.xaml
    /// </summary>
    public partial class visualisation : UserControl
    {
        public List<TcpDataModel.Season> seasons = new List<Season>();
        public visualisation()
        {
            InitializeComponent();

        }
    }
}