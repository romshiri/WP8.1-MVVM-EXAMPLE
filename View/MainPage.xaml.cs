using GalaSoft.MvvmLight.Messaging;
using Romfix.Model.DictionaryAPI;
using Romfix.Model.MorfixAPI;
using Romfix.View;
using Romfix.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Text;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Romfix
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            Messenger.Default.Register<NotificationMessage<string>>(this, (message) =>
            {
                this.tbSearch.Text = message.Content;
            });

            Messenger.Default.Register<NotificationMessage<bool>>(this, (flag) =>
            {
                this.infoBox.Visibility = flag.Content ? Visibility.Visible : Visibility.Collapsed;
            });

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            if (e.NavigationMode == NavigationMode.New)
            {
                Task.Run(() =>
                    {
                        RegisterVoiceCommands();
                    });

                // Get recognition result from parameter passed in frame.Navigate call
                SpeechRecognitionResult vcResult = e.Parameter as SpeechRecognitionResult;

                if (vcResult != null)
                {
                    // What did the user say? e.g. MSDN, "Find Windows Phone Voice Commands"
                    string recoText = vcResult.Text;

                    // Store the semantics dictionary for later use
                    IReadOnlyDictionary<string, IReadOnlyList<string>> semantics = vcResult.SemanticInterpretation.Properties;

                    string voiceCommandName = vcResult.RulePath.First();

                    if (voiceCommandName == "Translate")
                    {
                        // What did the user say, for named phrase topic or list "slots"? e.g. "Windows Phone Voice Commands"
                        if (semantics.ContainsKey("dictatedSearchTerms"))
                        {
                            await ViewModelLocator.Instance.MainVm.Translate(semantics["dictatedSearchTerms"][0]);

                        }
                        else
                        {
                            //HandleNoSearchTerms();
                        }
                    }
                    // Else handle other voice commands
                    //   navigationHelper.OnNavigatedTo(e)
                }

            }


            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void RegisterVoiceCommands()
        {
            // SHOULD BE PERFORMED UNDER TRY/CATCH
            Uri uriVoiceCommands = new Uri("ms-appx:///CortanaVCD.xml", UriKind.Absolute);
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(uriVoiceCommands);
            await VoiceCommandManager.InstallCommandSetsFromStorageFileAsync(file);
        }


        private async void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                HideSoftKeyboard();

                if (tbSearch.Text != "")
                {
                    await ViewModelLocator.Instance.MainVm.Translate(tbSearch.Text);
                }
            }
        }

        private void HideSoftKeyboard()
        {
            tbSearch.IsEnabled = false;
            tbSearch.IsTabStop = false;

            tbSearch.IsEnabled = true;
            tbSearch.IsTabStop = true;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AboutPage));
        }



    }
}
