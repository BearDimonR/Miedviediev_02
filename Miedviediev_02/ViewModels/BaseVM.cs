using System.ComponentModel;
using System.Runtime.CompilerServices;
using Miedviediev_02.Annotations;

namespace Miedviediev_02.ViewModels
{
    public class BaseVm:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}