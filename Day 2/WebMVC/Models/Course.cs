namespace WebMVC.Models
{
    public class Course
    {
        public static IList<Course> All { get; set; }

        static Course()
        {
            All = new List<Course>()
            {
                new Course() { Id = 1, Title = "C# 12", Duration = 40, Description = "C# Intro" },
                new Course() { Id = 2, Title = "C# Client-Server", Duration = 40, Description = "Creating service with c#" },
                new Course() { Id = 3, Title = "JavaScript", Duration = 24, Description = "JavaScript Intro" },
                new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" }
            };
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
    }
}
