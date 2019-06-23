using BabysitterPayCalculator.Library;
using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests.JobTests
{
    [TestClass]
    public class CalculatePayTests
    {
        [TestMethod]
        public void Job_CalculatePay_ReturnsCorrectPay()
        {
            // Arrange.
            var familyHourlyRate = new FamilyHourlyRate{
                StartTime = new TimeSpan(23, 0, 0), // 11:00PM
                HourlyRate = 20
            };

            var family = new Family
            {
                DefaultHourlyRate = 15
            };
            family.AddFamilyHourlyRate(familyHourlyRate);

            var job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 17, 0, 0), // 6/20/2019 5:00PM
                EndDateTime = new DateTime(2019, 6, 21, 4, 0, 0), // 6/21/2019 4:00AM
                Family = family
            };

            var babySitter = new Babysitter
            {
                MinimumStartTime = new TimeSpan(17, 0, 0), // 5:00PM
                MaximumEndTime = new TimeSpan(4, 0, 0) // 4:00AM
            };
            babySitter.AddJob(job);

            // Act.
            var totalPay = babySitter.CalculatePayForJob(job);

            // Assert.
            var expectedTotalPay = 190;
            Assert.AreEqual(expectedTotalPay, totalPay);
        }
    }
}
