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

        /// <summary>
        ///     Attempts to add a new <see cref="Job"> to the babysitter.
        /// </summary>
        /// <param name="job">The job to be added.</param>
        /// <exception cref="ArgumentException">Babysitter does not meet job requirements.</exception>
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
