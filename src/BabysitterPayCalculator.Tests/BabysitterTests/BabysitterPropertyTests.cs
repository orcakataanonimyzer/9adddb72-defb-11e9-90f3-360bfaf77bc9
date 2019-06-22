using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class BabysitterPropertyTests
    {
        private Babysitter Babysitter;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Babysitter = new Babysitter();
        }

        [TestMethod]
        public void Babysitter_MinimumStartTime_ReturnsValuePassed()
        {
            // Arrange.
            var minimumStartTime = new TimeSpan(1);

            // Act.
            Babysitter.MinimumStartTime = minimumStartTime;

            // Assert.
            Assert.AreEqual(minimumStartTime, Babysitter.MinimumStartTime);
        }

        [TestMethod]
        public void Babysitter_MaximumEndTime_ReturnsValuePassed()
        {
            // Arrange.
            var maximumEndTime = new TimeSpan(1);

            // Act.
            Babysitter.MaximumEndTime = maximumEndTime;

            // Assert.
            Assert.AreEqual(maximumEndTime, Babysitter.MaximumEndTime);
        }
    }
}
