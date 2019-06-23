using BabysitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class FamilyHourlyRateTests
    {
        private FamilyHourlyRate FamilyHourlyRate;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            FamilyHourlyRate = new FamilyHourlyRate()
            {
                HourlyRate = 1.21m,
                StartTime = new TimeSpan(1, 0, 0)
            };
        }

        [TestMethod]
        public void FamilyHourlyRate_StartTime_ReturnsValuePassed()
        {
            // Assert.
            var expectedStartTime = new TimeSpan(1, 0, 0);
            Assert.AreEqual(expectedStartTime, FamilyHourlyRate.StartTime);
        }

        [TestMethod]
        public void FamilyHourlyRate_HourlyRate_ReturnsValuePassed()
        {
            // Assert.
            var expectedHourlyRate = 1.21m;
            Assert.AreEqual(expectedHourlyRate, FamilyHourlyRate.HourlyRate);
        }
    }
}
