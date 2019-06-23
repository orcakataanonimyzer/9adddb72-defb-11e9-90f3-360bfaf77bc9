using BabysitterPayCalculator.Library;
using BabySitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests.BabysitterTests
{
    [TestClass]
    public class AddJobTests
    {
        [TestMethod]
        public void Babysitter_AddJob_SuccessfullyAddsJob()
        {
            // Arrange.
            var job = new Job
            {
                StartDateTime = new DateTime(2019, 6, 20, 17, 0, 0), // 6/20/2019 - 5:00:00PM
                EndDateTime = new DateTime(2019, 6, 21, 3, 0, 0) // 6/21/2019 - 3:00:00AM
            };

            var babySitter = new Babysitter
            {
                MinimumStartTime = new TimeSpan(17, 0, 0), // 5:00:00PM
                MaximumEndTime = new TimeSpan(3, 0, 0) // 3:00:00AM
            };

            // Act.
            babySitter.AddJob(job);

            // Assert.
            var expectedJobCount = 1;
            Assert.AreEqual(expectedJobCount, babySitter.Jobs.Count);
        }
    }
}
