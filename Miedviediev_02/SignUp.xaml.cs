using System;
using System.Threading.Tasks;
using System.Windows;

namespace Miedviediev_02
{
    public partial class SignUp
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void ProceedClicked(object sender, RoutedEventArgs e)
        {
            LoaderManager.Instance.ShowLoader();
            InformationVm data = (InformationVm) DataContext;
            try
            {
                await Task.Run(() =>
                {
                    data.ProceedPerson();
                });
                LoaderManager.Instance.HideLoader();
            }
            catch (Exception exception)
            {
                LoaderManager.Instance.HideLoader();
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}