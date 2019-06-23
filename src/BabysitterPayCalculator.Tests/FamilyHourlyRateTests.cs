using BabysitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class FamilyHourlyRateTests
    {
        [TestMethod]
        public void FamilyHourlyRate_StartTime_ReturnsValuePassed()
        {
            // Arrange.
            var rateStartTime = new TimeSpan(1, 0, 0);

            // Act.
            var familyHourlyRate = new FamilyHourlyRate().StartTime = rateStartTime;

            // Assert.
            Assert.AreEqual(rateStartTime, familyHourlyRate);
        }

        [TestMethod]
        public void FamilyHourlyRate_HourlyRate_ReturnsValuePassed()
        {
            // Arrange.
            var hourlyRate = 1.21m;

            // Act.
            var familyHourlyRate = new FamilyHourlyRate().HourlyRate = hourlyRate;

            // Assert.
            Assert.AreEqual(hourlyRate, familyHourlyRate);
        }
    }
}
