namespace WebDI.Services
{
    public class HelloImpl : IHello
    {
        public string GetHelloString()
        {
            int h = DateTime.Now.Hour;
            if (h >= 0 && h < 6) return "Доброй ночи";
            if (h >= 6 && h < 12) return "Доброе утро";
            if (h >= 12 && h < 18) return "Добрый день";
            return "Добрый вечер";
        }
    }
}
