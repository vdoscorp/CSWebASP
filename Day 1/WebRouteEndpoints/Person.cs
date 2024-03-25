namespace WebRouteEndpoints
{
    public class Person
    {
        public static IList<Person> All { get; set; }

        static Person() {
            All = new List<Person>() {
                new Person() { Id = 1, Name = "Sergey", Age = 40 },
                new Person() { Id = 2, Name = "Anna", Age = 20 },
                new Person() { Id = 3, Name = "Julia", Age = 30 },
                new Person() { Id = 4, Name = "Alexander", Age = 30 }
            };
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
