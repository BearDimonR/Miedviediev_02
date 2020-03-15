using System.Windows;
using Miedviediev_02.Managers;

namespace Miedviediev_02.ViewModels
{
    public class MainVm:BaseVm, ILoaderOwner
    {
        private Visibility _loaderVisibility;
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged(nameof(LoaderVisibility));
            }
        }

        private bool _isControlEnabled;

        public bool IsControlEnabled
        {
            //used in SignUp
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged(nameof(IsControlEnabled));
            }
        }
        
        public MainVm()
        {
            LoaderManager.Instance.Initialize(this);
            LoaderManager.Instance.HideLoader();
        }
        
    }
}