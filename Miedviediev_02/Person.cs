using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Miedviediev_02
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthday;
        private readonly bool _isAdult;
        private readonly WesternZodiac _westernZodiac;
        private readonly ChineseZodiac _chineseSign;
        private readonly bool _isBirthday;


        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }

        public bool IsAdult => _isAdult;

        public WesternZodiac SunSign => _westernZodiac;

        public ChineseZodiac ChineseSign => _chineseSign;

        public bool IsBirthday => _isBirthday;

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = birthday;
            (_westernZodiac, _chineseSign, _isAdult, _isBirthday) = CreateObject();
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birthday = DateTime.Today;
            (_westernZodiac, _chineseSign, _isAdult, _isBirthday) = CreateObject();
        }

        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthday = birthday;
            _email = null;
            (_westernZodiac, _chineseSign, _isAdult, _isBirthday) = CreateObject();
        }
        
        private (WesternZodiac _westernZodiac, ChineseZodiac _chineseSign, bool _isAdult, bool _isBirthday)
            CreateObject()
        {
            Task<WesternZodiac> wzTask = Task.Run(FindWesternZodiac);
            Task<ChineseZodiac> czTask = Task.Run(FindChineseZodiac);
            Task<int> ageTask = Task.Run(CountAge);
            Task<bool> birthTask = ageTask.ContinueWith((task) => CalculateBirthday(task.Result));
            Task.WaitAll(wzTask, czTask, birthTask);
            return (wzTask.Result, czTask.Result, (ageTask.Result >= 18), birthTask.Result);
        }
        
        private WesternZodiac FindWesternZodiac()
        {
            Thread.Sleep(2000);
            switch (_birthday.Month)
            {
                case 1:
                    return _birthday.Day <= 20 ? WesternZodiac.Capricorn : WesternZodiac.Aquarius;
                case 2:
                    return _birthday.Day <= 19 ? WesternZodiac.Aquarius : WesternZodiac.Pisces;
                case 3:
                    return _birthday.Day <= 20 ? WesternZodiac.Pisces : WesternZodiac.Aries;
                case 4:
                    return _birthday.Day <= 20 ? WesternZodiac.Aries : WesternZodiac.Taurus;
                case 5:
                    return _birthday.Day <= 21 ? WesternZodiac.Taurus : WesternZodiac.Gemini;
                case 6:
                    return _birthday.Day <= 22 ? WesternZodiac.Gemini : WesternZodiac.Cancer;
                case 7:
                    return _birthday.Day <= 22 ? WesternZodiac.Cancer : WesternZodiac.Leo;
                case 8:
                    return _birthday.Day <= 23 ? WesternZodiac.Leo : WesternZodiac.Virgo;
                case 9:
                    return _birthday.Day <= 23 ? WesternZodiac.Virgo : WesternZodiac.Libra;
                case 10:
                    return _birthday.Day <= 23 ? WesternZodiac.Libra : WesternZodiac.Scorpio;
                case 11:
                    return _birthday.Day <= 22 ? WesternZodiac.Scorpio : WesternZodiac.Sagittarius;
                case 12:
                    return _birthday.Day <= 21 ? WesternZodiac.Sagittarius : WesternZodiac.Capricorn;
                default:
                    throw new ArgumentOutOfRangeException($"Undefined WesternZodiac");
            }
        }

        private ChineseZodiac FindChineseZodiac()
        {
            Thread.Sleep(1000);
            try
            {
                ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
                int terrestrialBranch = calendar.GetTerrestrialBranch(calendar.GetSexagenaryYear(_birthday));
                return (ChineseZodiac) terrestrialBranch;
            }
            catch (ArgumentOutOfRangeException)
            {
                return (ChineseZodiac) ((_birthday.Year - 4) % 12 + 1);
            }
        }

        private int CountAge()
        {
            Thread.Sleep(500);
            DateTime now = DateTime.Now;
            int age = now.Year - _birthday.Year;
            if (_birthday > now.AddYears(-age)) age--;
            if (age < 0 || age > 135)
                throw new ArgumentOutOfRangeException($"Impossible Birthday Date!!");
            return age;
        }

        private bool CalculateBirthday(int age)
        {
            Thread.Sleep(1000);
            DateTime nextBirthday = _birthday.AddYears(age + 1);
            TimeSpan difference = nextBirthday - DateTime.Today;
            return Convert.ToInt32(difference.TotalDays) == 366;
        }
        
        public override string ToString()
        {
            return "\nName: " + _name +
                   "\nSurname: " + _surname +
                   "\nE-mail: " + _email +
                   "\nIsAdult: " + _isAdult +
                   "\nIsBirthday: " + _isBirthday +
                   "\nWesternZodiac: " + _westernZodiac +
                   "\nChineseSign: " + _chineseSign;
        }

    }
}