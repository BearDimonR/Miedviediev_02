using System.Windows;

namespace Miedviediev_02
{
    public class MainVm:BaseVM, ILoaderOwner
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