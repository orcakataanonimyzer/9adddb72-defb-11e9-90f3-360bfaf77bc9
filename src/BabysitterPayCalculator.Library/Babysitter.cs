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
            var babySitterStart = GetBabysitterStartDateTimeForJob(job);
            var babySitterEnd = GetBabysitterEndDateTimeForJob(job);

            if (job.StartDateTime < babySitterStart
                || job.EndDateTime > babySitterEnd)
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

            var jobFamilyHourlyRates = new List<Tuple<DateTime, decimal>>();
            foreach(var familyHourlyRate in job.Family.FamilyHourlyRates)
            {
                var dateTime = GetHourlyRateChangeDateTimeByJobAndTime(job, familyHourlyRate.StartTime);
                jobFamilyHourlyRates.Add(new Tuple<DateTime, decimal>(dateTime, familyHourlyRate.HourlyRate));
            }

            for(var startDateTime = job.StartDateTime; startDateTime < job.EndDateTime; startDateTime = startDateTime.AddHours(1))
            {
                // Attempt to find a rate change every hour to change the rate.
                var hourlyRateChange = jobFamilyHourlyRates.LastOrDefault(rate => rate.Item1 <= startDateTime);
                if (hourlyRateChange != null) 
                {
                    rateOfPay = hourlyRateChange.Item2;
                }

                totalPay += rateOfPay;
            }
            return totalPay;
        }

        private DateTime GetHourlyRateChangeDateTimeByJobAndTime(Job job, TimeSpan changeTime)
        {
            var hourlyRateChangeDateTime = job.StartDateTime.Date.Add(changeTime);

            if(job.EndDateTime < hourlyRateChangeDateTime)
            {
                hourlyRateChangeDateTime = hourlyRateChangeDateTime.AddDays(-1);
            }
            if(job.StartDateTime > hourlyRateChangeDateTime)
            {
                hourlyRateChangeDateTime = hourlyRateChangeDateTime.AddDays(1);
            }

            return hourlyRateChangeDateTime;
        }

        private DateTime GetBabysitterStartDateTimeForJob(Job job)
        {
            var babysitterStartDateTime = job.StartDateTime.Date.Add(MinimumStartTime);

            if(job.EndDateTime < babysitterStartDateTime)
            {
                babysitterStartDateTime = babysitterStartDateTime.AddDays(-1);
            }

            return babysitterStartDateTime;
        }

        private DateTime GetBabysitterEndDateTimeForJob(Job job)
        {
            var babysitterEndDateTime = job.EndDateTime.Date.Add(MaximumEndTime);

            if (job.StartDateTime > babysitterEndDateTime)
            {
                babysitterEndDateTime = babysitterEndDateTime.AddDays(1);
            }

            return babysitterEndDateTime;
        }
    }
}
