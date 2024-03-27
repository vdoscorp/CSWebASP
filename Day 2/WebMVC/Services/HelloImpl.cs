namespace WebMVC.Services
{
    public class HelloImpl : IHello
    {
        public string GetHelloString(string name)
        {
            int h = DateTime.Now.Hour;
            string prefix;
            if (h >= 0 && h < 6) prefix = "Доброй ночи";
            else if (h >= 6 && h < 12) prefix = "Доброе утро";
            else if (h >= 12 && h < 18) prefix = "Добрый день";
            else prefix = "Добрый вечер";
            return string.IsNullOrWhiteSpace(name) ? prefix : $"{prefix}, {name}!";
        }
    }
}
