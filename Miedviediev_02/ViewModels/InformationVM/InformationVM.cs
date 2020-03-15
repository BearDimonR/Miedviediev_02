using System;
using System.Threading.Tasks;
using System.Windows;
using Miedviediev_02.Exceptions;
using Miedviediev_02.Managers;
using Miedviediev_02.Models;

namespace Miedviediev_02.ViewModels.InformationVM
{
    public sealed class InformationVm : BaseVm
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        public RelayCommand<object> ClickCommand { get; }

        private bool _isBirthDay;
        public bool IsBirthDay => _isBirthDay;

        private Person _person;

        public Person Person => _person;

        public InformationVm()
        {
            Birthday = DateTime.Today;
            ClickCommand = new RelayCommand<object>(ProceedPerson);
        }

        private async void ProceedPerson(object o)
        {
            try
            {
                try
                {
                    LoaderManager.Instance.ShowLoader();
                    await Task.Run(() => { _person = new Person(Name, Surname, Email, Birthday); });
                    LoaderManager.Instance.HideLoader();
                    OnPropertyChanged(nameof(Person));
                    ClearForm();
                    _isBirthDay = _person.IsBirthday;
                    OnPropertyChanged(nameof(IsBirthDay));
                }
                catch (Exception exception)
                {
                    LoaderManager.Instance.HideLoader();
                    // get rid of wrapper exception if present
                    if (exception.InnerException != null)
                        throw exception.InnerException;
                    throw;
                }
            }
            catch (AgeException exception)
            {
                MessageBox.Show(exception.Message,
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Birthday = DateTime.Today;
                OnPropertyChanged(nameof(Birthday));
            }
            catch (InvalidPersonName exception)
            {
                MessageBox.Show(exception.Message,
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Name = string.Empty;
                OnPropertyChanged(nameof(Name));
            }
            catch (InvalidPersonSurname exception)
            {
                MessageBox.Show(exception.Message,
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Surname = string.Empty;
                OnPropertyChanged(nameof(Surname));
            }
            catch (NotEduMailException exception)
            {
                MessageBox.Show(exception.Message,
                    "Input Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
                Email = string.Empty;
                OnPropertyChanged(nameof(Email));
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong...\nProgram will stop!",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Environment.Exit(-1);
            }
        }
        private void ClearForm()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            Birthday = DateTime.Today;
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));
            OnPropertyChanged(nameof(Birthday));
        }
    }
}