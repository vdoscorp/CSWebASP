namespace WebMVC.Models
{
    public class HelloVM
    {
        public string UserName { get; set; }
        public string Hello {
            get => string.IsNullOrWhiteSpace(UserName)? "Привет!" : $"Привет, {UserName}!";
        }
    }
}
