
namespace WebMVC.Models
{
    public class CourseDataImpl : ICourseData
    {
        public IEnumerable<Course> All => Course.All;
    }
}
