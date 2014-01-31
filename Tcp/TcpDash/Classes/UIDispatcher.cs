using System;
using System.Windows;
using System.Windows.Media.Effects;
using System.Windows.Threading;

namespace TcpDash.Classes
{
    class UIDispatcher
    {

        #region members

        private MainWindow _uiElement;
        #endregion

        #region singleton
        private static readonly Lazy<UIDispatcher> lazy =
            new Lazy<UIDispatcher>(() => new UIDispatcher());

        public static UIDispatcher Instance { get { return lazy.Value; } }

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
            _uiElement.Effect = new BlurEffect();
            bool? result = win.ShowDialog();
            _uiElement.Effect = null;
            return result;
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
