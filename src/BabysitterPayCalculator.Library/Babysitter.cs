using BabysitterPayCalculator.Library;
using System;

namespace BabySitterPayCalculator.Library
{
    public class Babysitter
    {
        public TimeSpan MinimumStartTime { get; set; }

        public TimeSpan MaximumEndTime { get; set; }

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
