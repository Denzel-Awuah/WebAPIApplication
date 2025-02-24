﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApiApplication.Controllers;
using WebApiApplication;
using Xunit;
using WebApiApplication.Interfaces;
using WebApiApplication.Models;

namespace WebApiApplication.Unit_Testing
{
    public class TestCourseController
    {

        [Fact]
        public void GetAllCourses_ShouldReturnOkResult()
        {
            //Arrange
            var returnArray = new List<Course>();

            var _courseService = new Mock<ICourseService>();
            _courseService.Setup(_ => _.GetAllCourses()).Returns([]);
            var sut = new CoursesController(_courseService.Object);

            //Act
            var result = sut.GetAllCourses();

            //Assert
            var resultType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(returnArray, resultType.Value);
        }


        [Fact]
        public void GetCourseById_ShouldReturnExampleCourse()
        {

            var testCourse = new Course
            {
                Id = 10,
                Title = "A Title for the Test Course",
                Description = "This is a test course"
            };

            var _courseService = new Mock<ICourseService>();
            _courseService.Setup(_ => _.GetCourseById(1)).Returns(testCourse);
            var sut = new CoursesController(_courseService.Object);

            var result = sut.GetCourseById(1);

            var resultType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(resultType.Value, testCourse);

        }

    }
}
