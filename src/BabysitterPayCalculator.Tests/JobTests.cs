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

        [TestMethod]
        public void Job_EndDateTime_ReturnsValuePassed()
        {
            // Arrange.
            var endDateTime = new DateTime(2019, 6, 20);

            // Act.
            Job.EndDateTime = endDateTime;

            // Assert.
            Assert.AreEqual(endDateTime, Job.EndDateTime);
        }
    }
}
