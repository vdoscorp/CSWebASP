using System.ComponentModel.DataAnnotations;

namespace WebMVC.Views.Validators
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        private int maxYears;

        public DateValidatorAttribute(int maxYears)
        {
            this.maxYears = maxYears;
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            if (value is DateOnly)
            {
                DateOnly d = (DateOnly)value;
                DateOnly now = DateOnly.FromDateTime(DateTime.Now);
                return d <= now && d >= now.AddYears(maxYears * -1);
            }
            return false;
        }
    }
}
