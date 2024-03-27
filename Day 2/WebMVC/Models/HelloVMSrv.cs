using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class HelloVMSrv
    {
        [Display(Name = "Ваше имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Укажите имя")]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Длина имени от 3 до 16 символов")]
        public string UserName { get; set; } = "";

        public string Hello { get; set; } = "";

    }
}
