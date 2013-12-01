using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace TcpModernUI.Utility
{
    public sealed class Delegator
    {
        #region singleton
        private static readonly Lazy<Delegator> lazy =
            new Lazy<Delegator>(() => new Delegator());

        public static Delegator Instance { get { return lazy.Value; } }

        private Delegator()
        {

        }
        #endregion

        #region members
        private UIElement _element;
        #endregion

        #region publicmethods
        public void Register(UIElement element)
        {
            _element = element;
        }

        #endregion
    }
}
