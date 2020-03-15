using System.Windows;
using Miedviediev_02.ViewModels;

namespace Miedviediev_02.Managers
{
    internal class LoaderManager : BaseVm
    {
        private static readonly object Locker = new object();
        private static LoaderManager _instance;

        internal static LoaderManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new LoaderManager());
                }
            }
        }

        private ILoaderOwner _loaderOwner;

        private LoaderManager()
        {
            
        }

        internal void Initialize(ILoaderOwner loaderOwner)
        {
            _loaderOwner = loaderOwner;
        }

        internal void ShowLoader()
        {
            _loaderOwner.IsControlEnabled = false;
            _loaderOwner.LoaderVisibility = Visibility.Visible;
        }    
        internal void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsControlEnabled = true;
        }
    }
}