using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TcpModernUI.BaseClasses
{
    class CustomDispatcher
    {
        #region members

        private UIElement _uiElement;
        #endregion

        #region singleton
        private static readonly  Lazy<CustomDispatcher> lazy = 
            new Lazy<CustomDispatcher>(() => new CustomDispatcher());

        public static CustomDispatcher Instance { get { return lazy.Value; } }

        private CustomDispatcher()
        {

        }

        #endregion

        #region public 

        /// <summary>
        /// Registers the UI and returns true if the UI was already registered
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Returns true if the UI was already registered</returns>
        public bool RegisterUI(UIElement element)
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
        #endregion
    }
}
