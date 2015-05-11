using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;

namespace Romfix.ViewModel.Converters
{
    public class FormattedTextToBoldTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var tb = (TextBlock)value;
            var example = (string)parameter;

            var str = example.Split(new string[] { "<b>", "</b>" }, StringSplitOptions.None);

            for (int i = 0; i < str.Length; i++)
                tb.Inlines.Add(new Run { Text = str[i], FontWeight = i % 2 == 1 ? FontWeights.Bold : FontWeights.Normal });

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
