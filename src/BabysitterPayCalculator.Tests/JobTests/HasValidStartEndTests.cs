using BabysitterPayCalculator.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BabysitterPayCalculator.Tests.JobTests
{
    [TestClass]
    public class HasValidStartEndTests
    {
        private Job Job;

        /// <summary>
        ///     Initializes before each test.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            Job = new Job()
            {
                StartDateTime = new DateTime(2019, 6, 20, 1, 0, 0),
                EndDateTime = new DateTime(2019, 6, 20, 2, 0, 0)
            };
        }

        [TestMethod]
        public void Job_HasValidStartAndEnd_ReturnsTrueForValidStartAndEnd()
        {
            // Act.
            var hasValidStartAndEnd = Job.HasValidStartAndEnd();

            // Assert.
            var expectedValue = true;
            Assert.AreEqual(expectedValue, hasValidStartAndEnd);
        }

        [TestMethod]
        public void Job_HasValidStartAndEnd_ReturnsFalseForInvalidStartAndEnd()
        {
            // Arrange.
            Job.EndDateTime = new DateTime(2019, 6, 20, 1, 0, 0);

            // Act.
            var hasValidStartAndEnd = Job.HasValidStartAndEnd();

            // Assert.
            var expectedValue = false;
            Assert.AreEqual(expectedValue, hasValidStartAndEnd);
        }
    }
}
