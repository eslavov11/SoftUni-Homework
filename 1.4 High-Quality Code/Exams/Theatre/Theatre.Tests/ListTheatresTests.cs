namespace Theatre.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Theatre.Data;
    using Theatre.Interfaces;

    [TestClass]
    public class ListTheatresTests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeTest()
        {
            this.database = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestListTheatres_InitializeTheatres_ShouldReturnTheatres()
        {
            // Arrange
            List<object> theatres = new List<object>();
            theatres.Add("Ivan Vazov");
            theatres.Add("Opera");
            theatres.Add("Theatre");

            this.database.AddTheatre("Ivan Vazov");
            this.database.AddTheatre("Opera");
            this.database.AddTheatre("Theatre");

            // Act
            List<string> returnedTheatres = this.database.ListTheatres().ToList();

            // Assert
            CollectionAssert.AreEqual(theatres, returnedTheatres);
        }

        [TestMethod]
        public void TestListTheatres_InitializeNoTheatres_ShouldReturnEmptyCollection()
        {
            // Arrange
            // Act
            List<string> returnedTheatres = this.database.ListTheatres().ToList();

            // Assert
            CollectionAssert.AreEqual(new List<string>(), returnedTheatres);
            Assert.AreEqual(0, returnedTheatres.Count);
        }

        [TestMethod]
        public void TestListTheatres_InitializeTheatre_CountShouldBeOne()
        {
            // Arrange
            this.database.AddTheatre("New");
            // Act
            List<string> returnedTheatres = this.database.ListTheatres().ToList();

            // Assert
            Assert.AreEqual(1, returnedTheatres.Count);
        }

        [TestMethod]
        public void TestListTheatres_InitializeTheatre_TheatreNamesShouldMatch()
        {
            // Arrange
            this.database.AddTheatre("New");
            // Act
            List<string> returnedTheatres = this.database.ListTheatres().ToList();

            // Assert
            Assert.AreEqual("New", returnedTheatres[0]);
        }
    }
}
