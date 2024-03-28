using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Controllers;
using WebMVC.Models;

namespace WebMVC.Test
{
    class FakeCourseData : ICourseData
    {
        public IEnumerable<Course> All
        {
            get
            {
                yield return new Course() { Id = 1, Title = "C# 12 web", Duration = 40, Description = "C# " };
                yield return new Course() { Id = 2, Title = "C# Client-Server", Duration = 40, Description = "Creating service with c#" };
                yield return new Course() { Id = 3, Title = "JavaScript", Duration = 24, Description = "JavaScript Intro web" };
                yield return new Course() { Id = 4, Title = "Java 1", Duration = 40, Description = "Java Intro" };
            }
        }
    }

    public class CourseControllerTest
    {
        [Fact]
        public void SearchTest()
        {
            // Arrange
            var c = new CourseController(new FakeCourseData());

            //Act
            var r = (IEnumerable<Course>)((c.Search("web") as ViewResult)?.ViewData.Model);

            //Assert
            Assert.All<Course>(r, course => Assert.True(
                    course.Title.Contains("web") || course.Description.Contains("web")));


        }
    }
}
