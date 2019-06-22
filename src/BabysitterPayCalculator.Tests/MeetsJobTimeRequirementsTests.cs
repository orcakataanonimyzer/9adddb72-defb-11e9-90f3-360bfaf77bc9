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

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Babysitter = new Babysitter();
        }

        [TestMethod]
        public void MeetsJobTimeRequirements_ReturnsTrueForValidJob()
        {
            // Arrange.
            var job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 17, 0, 0), // 6/20/2019 - 5:00:00PM
                EndDateTime = new DateTime(2019, 6, 21, 3, 0, 0) // 6/21/2019 - 3:00:00AM
            };
            Babysitter.MinimumStartTime = new TimeSpan(17, 0, 0); // 5:00:00PM
            Babysitter.MaximumEndTime = new TimeSpan(3, 0, 0); // 3:00:00AM

            // Act.
            var metRequirements = Babysitter.MeetsJobTimeRequirements(job);

            // Assert.
            var expectedValue = true;
            Assert.AreEqual(expectedValue, metRequirements);
        }


        [TestMethod]
        public void Babysitter_MeetsJobTimeRequirements_ReturnsFalseForInvalidStartTimeJob()
        {
            // Arrange.
            var job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 16, 0, 0), // 6/20/2019 - 4:00:00PM
                EndDateTime = new DateTime(2019, 6, 21, 3, 0, 0) // 6/21/2019 - 3:00:00AM
            };
            Babysitter.MinimumStartTime = new TimeSpan(17, 0, 0); // 5:00:00PM
            Babysitter.MaximumEndTime = new TimeSpan(3, 0, 0); // 3:00:00AM

            // Act.
            var metRequirements = Babysitter.MeetsJobTimeRequirements(job);

            // Assert.
            var expectedValue = false;
            Assert.AreEqual(expectedValue, metRequirements);
        }
    }
}
