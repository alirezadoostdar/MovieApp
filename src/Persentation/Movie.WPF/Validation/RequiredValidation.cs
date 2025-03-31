using System.Globalization;
using System.Windows.Controls;

namespace Movie.WPF.Validation;

public class RequiredValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if (!string.IsNullOrWhiteSpace(value?.ToString()))
            return ValidationResult.ValidResult;

        return new ValidationResult(false, "This field is required");
    }
}
