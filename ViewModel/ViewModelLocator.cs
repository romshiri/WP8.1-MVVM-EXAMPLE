using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Romfix.Model;
using Romfix.Model.DictionaryAPI;
using Romfix.Model.MorfixAPI;

namespace Romfix.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDictionaryAPI, DesignData.DictionaryDesignDataAPI>();
            }
            else
            {
                SimpleIoc.Default.Register<IDictionaryAPI>(()=>
                    {
                        return new MorfixDictionaryAPI(new MorfixJsonParser());
                    });
            }

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainVm
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }


        public static ViewModelLocator Instance
        {
            get
            {

                return App.Current.Resources["Locator"] as ViewModelLocator;
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}