using BabysitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class FamilyHourlyRateTests
    {
        [TestMethod]
        public void FamilyHourlyRate_RateStartTime_ReturnsValuePassed()
        {
            // Arrange.
            var rateStartTime = new TimeSpan(1, 0, 0);

            // Act.
            var familyHourlyRate = new FamilyHourlyRate().StartTime = rateStartTime;

            // Assert.
            Assert.AreEqual(rateStartTime, familyHourlyRate);
        }
    }
}
