using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Romfix.Model.DictionaryAPI;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store;

namespace Romfix.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        IDictionaryAPI _dictionaryService;
        TranslationViewModel _translationVm;
        public ICommand TranslateCommand { get; set; }
        public ICommand RateOnStoreCommand { get; set; }
        private bool isNoResultBoxEnabled;
        private bool isResultRegularEnabled;
        private bool isBusy;

        public MainViewModel(IDictionaryAPI dictionary)
        {
            _dictionaryService = dictionary;
            RateOnStoreCommand = new RelayCommand(async () =>
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=" + CurrentApp.AppId));
            });

            TranslateCommand = new RelayCommand<string>(async (query) =>
            {
                await Translate(query);
            });

            if (IsInDesignMode)
            {
                Translate("take");
            }

        }

        public async Task Translate(string query)
        {
            IsBusy = true;

            Messenger.Default.Send<NotificationMessage<string>>(new NotificationMessage<string>(query, ""));
            Messenger.Default.Send<NotificationMessage<bool>>(new NotificationMessage<bool>(false, ""));


            var result = await _dictionaryService.TranslateQueryAsync(query);
            TranslationVm = new TranslationViewModel(result);

            if (TranslationVm.Model.Result == ResultType.Match)
            {
                IsNoResultBoxEnabled = false;
                IsResultRegularEnabled = true;
            }
            else
            {
                IsNoResultBoxEnabled = true;
                IsResultRegularEnabled = false;
            }

            IsBusy = false;
        }

        public TranslationViewModel TranslationVm
        {
            get { return _translationVm; }
            set
            {
                _translationVm = value;
                RaisePropertyChanged(() => TranslationVm);
            }
        }

        public bool IsNoResultBoxEnabled
        {
            get { return isNoResultBoxEnabled; }
            set
            {
                isNoResultBoxEnabled = value;
                RaisePropertyChanged(() => IsNoResultBoxEnabled);

            }
        }

        public bool IsResultRegularEnabled
        {
            get { return isResultRegularEnabled; }
            set
            {
                isResultRegularEnabled = value;
                RaisePropertyChanged(() => IsResultRegularEnabled);
            }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }


    }
}