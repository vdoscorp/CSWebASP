namespace WebDI.Services
{
    public class CounterImpl : ICounter
    {
        private int counter = 0;

        public int Get() => counter;

        public void Increment() => counter++;
    }
}
