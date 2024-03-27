using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class HelloVM
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }
        public string Hello {
            get => string.IsNullOrWhiteSpace(UserName)? "Привет!" : $"Привет, {UserName}!";
        }
    }
}
