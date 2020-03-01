using System.ComponentModel;
using System.Windows;

namespace Miedviediev_02
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility
        {
            get;
            set;
        }

        bool IsControlEnabled { get; set; }
    }
}