using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Controllers;
using WebMVC.Models;

namespace WebMVC.Test
{
    public class CourseControllerMoqTest
    {
        public IEnumerable<Course> Courses
        {
            get
            {
                yield return new Course() { Id = 1, Title = "C# 12 web", Duration = 40, Description = "C# " };
                yield return new Course() { Id = 2, Title = "C# Client-Server", Duration = 40, Description = "Creating service with c#" };
                yield return new Course() { Id = 3, Title = "JavaScript", Duration = 24, Description = "JavaScript Intro web" };
                yield return new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" };
            }
        }

        public void SearchTest()
        {
            // Arrange
            var mock = new Mock<ICourseData>();
            mock.SetupGet(m => m.All).Returns(Courses);

            var c = new CourseController(mock.Object);

            //Act
            ViewResult vr = (c.Search("wEb") as ViewResult);

            //Assert
            Assert.Equal(2, vr.ViewData["CoursesCount"]);

            var r = (IEnumerable<Course>)(vr.ViewData.Model);
            Assert.Equal(2, r.Count());

            Assert.All<Course>(r,
                course => Assert.True(
                    course.Title.Contains("web", StringComparison.OrdinalIgnoreCase)
                    || course.Description.Contains("web", StringComparison.OrdinalIgnoreCase)));
        }
    }
}
