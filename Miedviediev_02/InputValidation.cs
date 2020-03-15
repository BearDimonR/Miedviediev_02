using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Miedviediev_02
{
    public class InputValidation: ValidationRule
    {
        public enum TypeName
        {
            TextBox,
            EmailBox,
            DatePicker
        }

        public TypeName ValidType { get; set; }
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string check;
            switch (ValidType)
            {
                case TypeName.TextBox:
                    check = CheckText(value);
                    break;
                case TypeName.EmailBox:
                    check = CheckEmail(value);
                    break;
                case TypeName.DatePicker:
                    check = CheckDate(value);
                    break;
                default:
                    throw new ArgumentException("Undefined Validation Element!");
            }
            return !string.IsNullOrEmpty(check) ? 
                new ValidationResult(false, check) : ValidationResult.ValidResult;
        }

        private static string CheckDate(object value)
        {
            return value == null ? "Date can't be empty!" : string.Empty;
        }

        private static string CheckEmail(object value)
        {
            Regex regex = new Regex(@"^[\w-\.]{2,}@([\w-]{2,}\.)+[\w-]{2,4}$");
            if (value != null && regex.IsMatch(value.ToString()))
                return "";
            return "Wrong E-mail! example@ukma.edu.ua";
        }

        private static string CheckText(object value)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
                return "This field can't be empty!";
            return string.Empty;
        }
    }
}