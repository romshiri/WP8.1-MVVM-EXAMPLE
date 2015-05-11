using Romfix.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Romfix.View.Common
{
    public class TranslationDataTemplateSelector : DataTemplateSelector
    {
        public Windows.UI.Xaml.DataTemplate FromEnglishDataTemplate { get; set; }
        public Windows.UI.Xaml.DataTemplate FromHebrewDataTemplate { get; set; }

        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            var translationVm = ViewModelLocator.Instance.MainVm.TranslationVm;
            return translationVm.Model.Type == Model.DictionaryAPI.TranslationType.FromEnglish ? FromEnglishDataTemplate : FromHebrewDataTemplate;
        }
    }
}
