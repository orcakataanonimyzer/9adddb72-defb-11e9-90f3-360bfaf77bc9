using BabysitterPayCalculator.Library;
using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class KataTests
    {
        private Babysitter Babysitter;
        private Job Job;
        private Family Family;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Family = new Family();
            Babysitter = new Babysitter
            {
                MinimumStartTime = new TimeSpan(17, 0, 0), // 5:00:00PM
                MaximumEndTime = new TimeSpan(4, 0, 0) // 4:00:00AM
            };
            Job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 17, 0, 0), // 6/20/2019 - 5:00:00PM
                EndDateTime = new DateTime(2019, 6, 21, 4, 0, 0), // 6/21/2019 - 3:00:00AM
                Family = Family
            };
        }

        [TestMethod]
        public void Kata_FamilyA()
        {
            // Arrange.
            var familyHourlyRate = new FamilyHourlyRate
            {
                StartTime = new TimeSpan(23, 0, 0), // 11:00PM
                HourlyRate = 20
            };

            Family.DefaultHourlyRate = 15;
            Family.AddFamilyHourlyRate(familyHourlyRate);

            Babysitter.AddJob(Job);

            // Act.
            var totalPay = Babysitter.CalculatePayForJob(Job);

            // Assert.
            var expectedTotalPay = 190;
            Assert.AreEqual(expectedTotalPay, totalPay);
        }

        [TestMethod]
        public void Kata_FamilyB()
        {
            // Arrange.
            var familyHourlyRate = new FamilyHourlyRate
            {
                StartTime = new TimeSpan(22, 0, 0), // 11:00PM
                HourlyRate = 8
            };
            var familyHourlyRateTwo = new FamilyHourlyRate
            {
                StartTime = new TimeSpan(0, 0, 0), // 12:00AM
                HourlyRate = 16
            };

            Family.DefaultHourlyRate = 12;
            Family.AddFamilyHourlyRate(familyHourlyRate);
            Family.AddFamilyHourlyRate(familyHourlyRateTwo);

            Babysitter.AddJob(Job);

            // Act.
            var totalPay = Babysitter.CalculatePayForJob(Job);

            // Assert.
            var expectedTotalPay = 140;
            Assert.AreEqual(expectedTotalPay, totalPay);
        }

        [TestMethod]
        public void Kata_FamilyC()
        {
            // Arrange.
            var familyHourlyRate = new FamilyHourlyRate
            {
                StartTime = new TimeSpan(21, 0, 0), // 9:00PM
                HourlyRate = 15
            };

            Family.DefaultHourlyRate = 21;
            Family.AddFamilyHourlyRate(familyHourlyRate);

            Babysitter.AddJob(Job);

            // Act.
            var totalPay = Babysitter.CalculatePayForJob(Job);

            // Assert.
            var expectedTotalPay = 189;
            Assert.AreEqual(expectedTotalPay, totalPay);
        }
    }
}
