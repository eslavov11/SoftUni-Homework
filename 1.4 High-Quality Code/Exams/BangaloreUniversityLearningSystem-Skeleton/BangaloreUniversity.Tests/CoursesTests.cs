namespace BangaloreUniversity.Tests
{
    using System;

    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Enums;

    using Moq;

    [TestClass]
    public class CoursesTests
    {
        [TestInitialize]
        public void InitializeData()
        {
            
        }

        [TestMethod]
        public void TestAddLecture_ValidCourse_ShouldAddToCourse()
        {
            var course = new Course("Advanced Java");
            var mockedData = new Mock<IBangaloreUniversityData>();
            var mockedCoursesRepo = new Mock<IRepository<Course>>();
            mockedCoursesRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(course);
            mockedData.Setup(data => data.Courses).Returns(mockedCoursesRepo.Object);

            var controller = new CoursesController(
                mockedData.Object, new User("123456", "123456", Role.Lecturer));

            var view = controller.AddLecture(800, "ABC");

            Assert.AreEqual(course.Lectures.First().Name, "ABC");
            Assert.IsNotNull(view);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_InvalidUserRole_ShouldThrow()
        {
            var course = new Course("Advanced Java");
            var mockedData = new Mock<IBangaloreUniversityData>();
            var mockedCoursesRepo = new Mock<IRepository<Course>>();
            mockedCoursesRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(course);
            mockedData.Setup(data => data.Courses).Returns(mockedCoursesRepo.Object);

            var controller = new CoursesController(
                mockedData.Object, new User("123456", "123456", Role.Student));

            var view = controller.AddLecture(800, "ABC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_InvalidUser_ShouldThrow()
        {
            var course = new Course("Very advanced Java");
            var mockedData = new Mock<IBangaloreUniversityData>();
            var mockedCourseRepo = new Mock<IRepository<Course>>();
            mockedCourseRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(course);
            mockedData.Setup(data => data.Courses).Returns(mockedCourseRepo.Object);

            var controller = new CoursesController(mockedData.Object, null);

            controller.AddLecture(12, "");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddLecture_InvalidCourseId_ShouldThrow()
        {
            Course course = null;
            var mockedData = new Mock<IBangaloreUniversityData>();
            var mockedCourseRepo = new Mock<IRepository<Course>>();
            mockedCourseRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns(course);
            mockedData.Setup(data => data.Courses).Returns(mockedCourseRepo.Object);

            var controller = new CoursesController(mockedData.Object, new User("asdfff", "1as65df1", Role.Lecturer));

            controller.AddLecture(1, "");
        }
    }
}
