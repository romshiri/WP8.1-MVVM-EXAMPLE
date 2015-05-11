using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Romfix.ViewModel.Converters
{
    public class TranslationTypeToFlowDirectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var type = (TranslationType)value;

            switch (type)
            {
                case TranslationType.FromHebrew:
                    return FlowDirection.RightToLeft;
                case TranslationType.FromEnglish:
                    return FlowDirection.LeftToRight;
                default:
                    return FlowDirection.RightToLeft;

            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
