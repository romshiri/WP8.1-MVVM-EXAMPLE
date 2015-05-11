using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Romfix.Model.DictionaryAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Media.SpeechSynthesis;

namespace Romfix.ViewModel
{
    public class WordViewModel : ViewModelBase
    {
        public Word Model { get; set; }
        public ICommand SpeechCommand { get; set; }
        public ICommand AddToFavoritsCommand { get; set; }

        public WordViewModel(Word word)
        {
            Model = word;
            SpeechCommand = new RelayCommand(async () =>
            {
                await Speech();
            });
            //AddToFavoritsCommand = new RelayCommand(AddToFavorits);
        }

        private async Task Speech()
        {

            using (var ss = new SpeechSynthesizer())
            {
                var stream = await ss.SynthesizeTextToStreamAsync(Model.InputMeaning);

                var mediaElement = new Windows.UI.Xaml.Controls.MediaElement();
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play(); 
            }
        }

        private void AddToFavorits()
        {
            //TODO: add to favorits logic.
        }
    }
}
