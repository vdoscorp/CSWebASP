using System.ComponentModel.DataAnnotations;
using WebMVC.Views.Validators;

namespace WebMVC.Models
{
    public class Registration
    {
        [Display (Name = "Логин")]
        [StringLength(16,MinimumLength = 3, ErrorMessage = "Логин должен быть от 3 до 16 символов")]
        public string Login { get; set; }

        [Display(Name = "Пароль")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Пароль должен быть от 3 до 16 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль не совпал с подтверждением")]
        [DataType(DataType.Password)]
        public string ConfilmPassword { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DateValidator(120, ErrorMessage = "Неверная дата рождения")]
        public DateOnly DOB { get; set; }

        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Неверный Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Ваш вес")]
        [Range(40, 200)]
        public int Weight { get; set; }

    }
}
