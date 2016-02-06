using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversity.Tests
{
    using System;

    using BangaloreUniversityLearningSystem.Controllers;
    using BangaloreUniversityLearningSystem.Data;
    using BangaloreUniversityLearningSystem.Enums;
    using BangaloreUniversityLearningSystem.Models;

    [TestClass]
    public class UsersControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLogout_InitializeNullUser_ShouldThrow()
        {
            // Arrange
            User user = null;
            var database = new BangaloreUniversityData();
            var controller = new UsersController(database, user);

            // Act
            controller.Logout();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLogout_InitializeGuestUser_ShouldThrow()
        {
            // Arrange
            User user = new User("gosho", "123456", Role.Guest);
            var database = new BangaloreUniversityData();
            var controller = new UsersController(database, user);

            // Act
            controller.Logout();

            // Assert
        }

        [TestMethod]
        public void TestLogout_LogoutValidUser_CurrentUserShouldBeNull()
        {
            // Arrange
            User user = new User("gosho", "123456", Role.Lecturer);
            var database = new BangaloreUniversityData();
            var controller = new UsersController(database, user);

            // Act
            controller.Logout();

            // Assert
            Assert.IsNull(controller.User, "User should be null.");
        }
    }
}
