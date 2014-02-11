using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace TcpDash.Classes
{
    internal class UIDispatcher
    {
        #region members

        private MainWindow _uiElement;
        private Window _shownWindow;


        #endregion

        #region singleton

        private static readonly Lazy<UIDispatcher> lazy =
            new Lazy<UIDispatcher>(() => new UIDispatcher());

        public static UIDispatcher Instance
        {
            get { return lazy.Value; }
        }

        private UIDispatcher()
        {
        }

        #endregion

        #region public

        /// <summary>
        /// Registers the UI and returns true if the UI was already registered
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Returns true if the UI was already registered</returns>
        public bool RegisterUI(MainWindow element)
        {
            if (_uiElement != null)
            {
                _uiElement = element;
                return false;
            }
            else
            {
                _uiElement = element;
                return true;
            }
        }

        public bool? ShowDialogAndBlur(Window win)
        {
            OverlayMainWindow();
            
            BlurEffect blur = new BlurEffect();
            blur.Radius = 8;
            _uiElement.Effect = blur;
            Task t = new Task(() =>
            {
                Thread.Sleep(120000);
                _uiElement.Dispatcher.Invoke(win.Close);
                _shownWindow = null;
            });
            t.Start();
            _shownWindow = win;
            bool? result = win.ShowDialog();
            _uiElement.Effect = null;
            
            _shownWindow = null;
            HideOverlayMainWindow();
            return result;
        }

       

        void _uiElement_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (_shownWindow != null)
            {
                _shownWindow.Close();
            }
        }

        public void OverlayMainWindow()
        {
            //_uiElement.News.Visibility = Visibility.Hidden;
            _uiElement.ShowOverlayAsync();
        }

        public void HideOverlayMainWindow()
        {
            _uiElement.HideOverlayAsync();
            //_uiElement.News.Visibility = Visibility.Visible;
        }

        public void ShowMessageDialog(MetroWindow win, string title, string msg)
        {
            if (_uiElement.CheckAccess())
            {
                win.ShowMessageAsync(title, msg, MessageDialogStyle.Affirmative);
            }
            else
            {
                _uiElement.Dispatcher.Invoke(() => win.ShowMessageAsync(title, msg, MessageDialogStyle.Affirmative));
            }
        }

        public MainWindow GetMainWindow
        {
            get { return _uiElement; }
        }

        public void BeginInvoke(Action action)
        {
            _uiElement.Dispatcher.BeginInvoke(DispatcherPriority.Background, action);
        }

        public void Invoke(Action action)
        {
            _uiElement.Dispatcher.Invoke(DispatcherPriority.Background, action);
        }

        #endregion

        #region privateRaising

        #endregion
    }
}