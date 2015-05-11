using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Romfix.ViewModel.Converters
{
    public class StringsListToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            List<string> strings = (List<string>)value;
            string oneString = "";

            foreach (var aString in strings)
            {
                oneString += aString + ", ";
            }

            oneString = oneString.Substring(0, oneString.Length - 2);

            return oneString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
