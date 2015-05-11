using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Romfix.ViewModel
{
    public class TranslationViewModel : ViewModelBase
    {
       public Translation Model { get; set; }
        public ObservableCollection<WordViewModel> WordsVm { get; set; }

        public TranslationViewModel(Translation translation)
        {
            Model = translation;
            WordsVm = new ObservableCollection<WordViewModel>();

            foreach (var word in translation.Words)
            {
                WordsVm.Add(new WordViewModel(word));
            }
        }


    }
}
