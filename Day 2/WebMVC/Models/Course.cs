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

        int duration;
        public int Duration
        {
            get => (duration / 4) * 4;
            set
            {
                if (value < 8 || value > 48)
                    throw new ArgumentOutOfRangeException("Course duration out of [8, 48]");
                duration = (value / 4) * 4;
            }
        }
        public string Description { get; set; }
    }
}
