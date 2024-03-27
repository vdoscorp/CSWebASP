namespace WebMVC.Models
{
    public class Registration
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfilmPassword { get; set; }
        public DateOnly DOB { get; set; }
        public string Email { get; set; }
        public int Weight { get; set; }
    }
}
