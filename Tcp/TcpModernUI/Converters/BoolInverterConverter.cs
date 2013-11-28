using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpModernUI.Converters
{
    public class BoolInverterConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool i;
            if (bool.TryParse(value.ToString(), out i) == false) return null;

            return !i;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool i;
            if (bool.TryParse(value.ToString(), out i) == false) return null;

            return !i;
        }

        #endregion
    }
}
