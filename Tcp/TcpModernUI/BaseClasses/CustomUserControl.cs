using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace TcpModernUI.BaseClasses
{
    
    public class CustomUserControl : UserControl
    {
        public static readonly DependencyProperty CustomFlyoutsProperty = DependencyProperty.Register("CustomFlyouts", typeof(FlyoutsControl), typeof(Window), new PropertyMetadata(null));

        public CustomUserControl():base()
        {
            
        }
        /// <summary>
        /// Gets/sets the FlyoutsControl that hosts the window's flyouts.
        /// </summary>
        public FlyoutsControl CustomFlyouts
        {
            get { return (FlyoutsControl)GetValue(CustomFlyoutsProperty); }
            set { SetValue(CustomFlyoutsProperty, value); }
        }
    }
}
