namespace HotelBookingSystem.Tests
{
    using System.Security.Policy;

    using ChepelareHotelBookingSystem.Data;
    using ChepelareHotelBookingSystem.Enums;
    using ChepelareHotelBookingSystem.Models;
    using ChepelareHotelBookingSystem.Utilities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestGet_InitializeValidUsers_UserShouldNotBeNull()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password123", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(2);

            // Assert
            Assert.IsNotNull(user, "User should not be null.");
        }

        [TestMethod]
        public void TestGet_InitializeValidUsers_UsernamesShouldMatch()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password123", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(2);

            // Assert
            Assert.AreEqual("username2", user.Username, "Usernames don't match.");
        }

        [TestMethod]
        public void TestGet_InitializeValidUsers_PasswordsShouldMatch()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password1234", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(2);

            // Assert
            Assert.AreEqual(HashUtilities.GetSha256Hash("password1234"), user.PasswordHash, "Passwords don't match.");
        }

        [TestMethod]
        public void TestGet_InitializeValidUsers_RolesShouldMatch()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password123", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(2);

            // Assert
            Assert.AreEqual(Roles.VenueAdmin, user.Role, "Users roles don't match.");
        }

        [TestMethod]
        public void TestGet_InitializeNoUsers_ShouldReturnNull()
        {
            // Arrange
            var roomsRepo = new UserRepository();

            // Act
            var user = roomsRepo.Get(1);

            // Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestGet_NegativeId_ShouldReturnNull()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password123", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(-1);

            // Assert
            Assert.IsNull(user);
        }

        [TestMethod]
        public void TestGet_InvalidPositiveId_ShouldReturnNull()
        {
            // Arrange
            var roomsRepo = new UserRepository();
            roomsRepo.Add(new User("username1", "password123", Roles.User));
            roomsRepo.Add(new User("username2", "password123", Roles.VenueAdmin));
            roomsRepo.Add(new User("username3", "password123", Roles.User));

            // Act
            var user = roomsRepo.Get(4);

            // Assert
            Assert.IsNull(user);
        }
    }
}
