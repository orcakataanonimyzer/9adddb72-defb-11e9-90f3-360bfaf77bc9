using BabysitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class JobTests
    {
        private Job Job;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Job = new Job();
        }

        [TestMethod]
        public void Job_StartDateTime_ReturnsValuePassed()
        {
            // Arrange.
            var startDateTime = new DateTime(2019, 6, 20);

            // Act.
            Job.StartDateTime = startDateTime;

            // Assert.
            Assert.AreEqual(startDateTime, Job.StartDateTime);
        }
    }
}
