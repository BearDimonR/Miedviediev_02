using System;

namespace Miedviediev_02
{
    public sealed class InformationVm : BaseVM
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime Birthday { get; set; }

        private Person _person;
        public Person Person => _person;

        public InformationVm()
        {
            Birthday = DateTime.Now;
        }

        public void ProceedPerson()
        {
            _person = new Person(Name, Surname, Email, Birthday);
            OnPropertyChanged(nameof(Person));
            ClearForm();
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