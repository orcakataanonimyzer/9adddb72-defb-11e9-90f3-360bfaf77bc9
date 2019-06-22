using BabysitterPayCalculator.Library;
using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests
{
    [TestClass]
    public class MeetsJobTimeRequirementsTests
    {
        private Babysitter Babysitter;
        private Job Job;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Babysitter = new Babysitter{
                MinimumStartTime = new TimeSpan(17, 0, 0), // 5:00:00PM
                MaximumEndTime = new TimeSpan(3, 0, 0) // 3:00:00AM
            };
            Job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 17, 0, 0), // 6/20/2019 - 5:00:00PM
                EndDateTime = new DateTime(2019, 6, 21, 3, 0, 0) // 6/21/2019 - 3:00:00AM
            };
        }

        [TestMethod]
        public void MeetsJobTimeRequirements_ReturnsTrueForValidJob()
        {
            // Act.
            var metRequirements = Babysitter.MeetsJobTimeRequirements(Job);

            // Assert.
            var expectedValue = true;
            Assert.AreEqual(expectedValue, metRequirements);
        }


        [TestMethod]
        public void MeetsJobTimeRequirements_ReturnsFalseForInvalidStartTimeJob()
        {
            // Arrange.
            Job.StartDateTime = new DateTime(2019, 6, 20, 16, 0, 0); // 6/20/2019 - 4:00:00PM

            // Act.
            var metRequirements = Babysitter.MeetsJobTimeRequirements(Job);

            // Assert.
            var expectedValue = false;
            Assert.AreEqual(expectedValue, metRequirements);
        }


        [TestMethod]
        public void MeetsJobTimeRequirements_ReturnsFalseForInvalidEndTimeJob()
        {
            // Arrange.
            Job.EndDateTime = new DateTime(2019, 6, 21, 4, 0, 0); // 6/21/2019 - 4:00:00AM

            // Act.
            var metRequirements = Babysitter.MeetsJobTimeRequirements(Job);

            // Assert.
            var expectedValue = false;
            Assert.AreEqual(expectedValue, metRequirements);
        }
    }
}
