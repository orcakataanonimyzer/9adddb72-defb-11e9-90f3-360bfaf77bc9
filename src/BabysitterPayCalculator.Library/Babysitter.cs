using BabysitterPayCalculator.Library;
using System;

namespace BabySitterPayCalculator.Library
{
    public class Babysitter
    {
        public TimeSpan MinimumStartTime { get; set; }

        public TimeSpan MaximumEndTime { get; set; }

        /// <summary>
        ///     Validates the jobs requirements against the babysitter.
        /// </summary>
        /// <param name="job">The job to be validated.</param>
        /// <returns>True or False if requirements are met.</returns>
        public bool MeetsJobTimeRequirements(Job job)
        {
            if (job.StartDateTime.TimeOfDay < MinimumStartTime
                || job.EndDateTime.TimeOfDay > MaximumEndTime)
            {
                return false;
            }
            return true;
        }
    }
}
