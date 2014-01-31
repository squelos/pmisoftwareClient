using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace TcpDash
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            EventManager.RegisterClassHandler(typeof(TextBox), TextBox.GotFocusEvent,
                new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.AttachTabTip()));
            EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.GotFocusEvent,
                new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.AttachTabTip()));
            //EventManager.RegisterClassHandler(typeof(ComboBox), ComboBox.GotFocusEvent,
            //    new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.AttachTabTip()));
            //EventManager.RegisterClassHandler(typeof(TextBox), TextBox.LostFocusEvent,
            //    new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.RemoveTabTip()));
            //EventManager.RegisterClassHandler(typeof(PasswordBox), PasswordBox.LostFocusEvent,
            //    new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.RemoveTabTip()));
            //EventManager.RegisterClassHandler(typeof(ComboBox), ComboBox.LostFocusEvent,
            //    new RoutedEventHandler((sender, args) => VirtualKeyBoardHelper.RemoveTabTip()));
        }

        public static void ShowKeyboard()
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.System) + Path.DirectorySeparatorChar + "osk.exe");
        }
    }
}
