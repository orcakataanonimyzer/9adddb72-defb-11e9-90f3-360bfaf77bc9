using BabysitterPayCalculator.Library;
using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests.BabysitterTests
{
    [TestClass]
    public class AddJobTests
    {
        private Babysitter Babysitter;
        private Job Job;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Babysitter = new Babysitter
            {
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
        public void Babysitter_AddJob_SuccessfullyAddsJob()
        {
            // Act.
            Babysitter.AddJob(Job);

            // Assert.
            var expectedJobCount = 1;
            Assert.AreEqual(expectedJobCount, Babysitter.Jobs.Count);
        }

        [TestMethod]
        public void Babysitter_AddJob_ThrowsArgumentExceptionForInvalidJob()
        {
            // Arrange.
            Job.StartDateTime = new DateTime(2019, 6, 20, 16, 0, 0); // 6/20/2019 - 4:00:00PM

            // Act & Assert.
            Assert.ThrowsException<ArgumentException>(() => Babysitter.AddJob(Job));
        }
    }
}
