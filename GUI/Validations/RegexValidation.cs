using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace GUI.Validations
{
    public class RegexValidation : ValidationRule
    {
        public string RegexText { get; set; }
        public string ErrorMsg { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var vr = new ValidationResult(true, null);
            if (!Regex.IsMatch(value.ToString(), RegexText))
            {
                vr = new ValidationResult(false, ErrorMsg);
            }
            return vr;
        }
    }
}
