using BabysitterPayCalculator.Library;
using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        ///     Calculates the total pay for the given job.
        /// </summary>
        /// <param name="job"></param>
        /// <returns>The total pay for the job.</returns>
        public decimal CalculatePayForJob(Job job)
        {
            var familyHourlyRates = job.Family.FamilyHourlyRates;
            var rateOfPay = job.Family.DefaultHourlyRate;
            var totalPay = 0m;

            for(var startDateTime = job.StartDateTime; startDateTime < job.EndDateTime; startDateTime = startDateTime.AddHours(1))
            {
                // Attempt to find a rate change every hour to change the rate.
                var hourlyRateChange = familyHourlyRates.SingleOrDefault(fhr => fhr.StartTime == startDateTime.TimeOfDay);
                if (hourlyRateChange != null) 
                {
                    rateOfPay = hourlyRateChange.HourlyRate;
                }

                totalPay += rateOfPay;
            }
            return totalPay;
        }
    }
}
