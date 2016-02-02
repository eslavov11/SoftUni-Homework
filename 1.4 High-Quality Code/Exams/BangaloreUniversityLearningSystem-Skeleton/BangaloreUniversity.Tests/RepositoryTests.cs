using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BangaloreUniversity.Tests
{
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Data;

    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void TestGet_InitializeRepoOfStrings_ShouldReturnElement()
        {
            // Arrange
            var namesRepo = new Repository<string>();
            namesRepo.Add("Stoyan");
            namesRepo.Add("Valio");
            namesRepo.Add("Pecata");

            // Act
            var name = namesRepo.Get(1);

            // Assert
            Assert.AreEqual("Stoyan", name, "Returned name should be Stoyan");
        }

        [TestMethod]
        public void TestGet_EmptyRepository_ShouldReturnNull()
        {
            // Arrange
            var namesRepo = new Repository<string>();

            // Act
            var name = namesRepo.Get(1);

            // Assert
            Assert.IsNull(name, "Returned name should be null");
        }

        [TestMethod]
        public void TestGet_NegativeId_ShouldReturnDefault()
        {
            // Arrange
            var namesRepo = new Repository<string>();

            // Act
            var name = namesRepo.Get(-5);

            // Assert
            Assert.IsNull(name, "Name should be null.");
        }

        [TestMethod]
        public void TestGet_InvalidId_ShouldReturnDefault()
        {
            // Arrange
            var namesRepo = new Repository<string>();
            namesRepo.Add("Stoyan");

            // Act
            var name = namesRepo.Get(5);

            // Assert
            Assert.IsNull(name, "Name should be null.");
        }
    }
}
