namespace Theatre.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Theatre.Data;
    using Theatre.Exceptions;
    using Theatre.Interfaces;

    [TestClass]
    public class PerformanceDatabaseTests
    {
        private IPerformanceDatabase database;

        [TestInitialize]
        public void InitializeTest()
        {
            this.database = new PerformanceDatabase();
        }

        [TestMethod]
        public void TestAddPerformance_ValidData_ParametersShouldMatch()
        {
            // Arrage
            string theatreName = "Ivan Vazov";
            string performanceTitle = "Hamlet";
            var startDateTime = DateTime.Now;
            var duration = new TimeSpan(5, 0, 0);
            decimal price = 10.50m;
            this.database.AddTheatre(theatreName);

            // Act
            this.database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);
            var performances = this.database.ListAllPerformances().ToList();
            
            // Assert
            Assert.AreEqual(performanceTitle, performances[0].PerformanceTitle);
            Assert.AreEqual(theatreName, performances[0].TheatreName);
            Assert.AreEqual(startDateTime, performances[0].StartDateTime);
            Assert.AreEqual(duration, performances[0].Duration);
            Assert.AreEqual(price, performances[0].Price);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void TestAddPerformance_NonExistingTheatre_ShouldThrow()
        {
            // Arrage
            string theatreName = "Ivan Vazov";
            string performanceTitle = "Hamlet";
            var startDateTime = DateTime.Now;
            var duration = new TimeSpan(5, 0, 0);
            decimal price = 10.50m;

            // Act
            this.database.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);

            // Assert
        }
    }
}
