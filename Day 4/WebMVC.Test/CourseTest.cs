using WebMVC.Models;

namespace WebMVC.Test
{
    public class CourseTest
    {
        [Fact]
        public void ChangeDuration()
        {
            // arrage
            Course c = new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" };

            // act
            c.Duration = 42;

            //assert
            Assert.Equal(40, c.Duration);

            c.Duration = 40;

            Assert.Equal(40, c.Duration);
        }

        [Fact]
        public void RangeDuration() //8<=Duration<=48
        {
            Course c = new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" };

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Duration = 50);

            Assert.Throws<ArgumentOutOfRangeException>(() => c.Duration = 4);
        }
    }
}