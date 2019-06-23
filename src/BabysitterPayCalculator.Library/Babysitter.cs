using BabysitterPayCalculator.Library;
using System;
using System.Collections.Generic;

namespace BabySitterPayCalculator.Library
{
    public class Babysitter
    {
        public TimeSpan MinimumStartTime { get; set; }

        public TimeSpan MaximumEndTime { get; set; }

        public ICollection<Job> Jobs { get; set; } = new HashSet<Job>();

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

        public void AddJob(Job job)
        {
            if (MeetsJobTimeRequirements(job))
            {
                Jobs.Add(job);
            } 
            else
            {
                throw new ArgumentException("You do not meet the requirements for this job.");
            }
        }
    }
}
