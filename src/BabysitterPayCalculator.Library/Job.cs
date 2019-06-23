using System;

namespace BabysitterPayCalculator.Library
{
    public class Job
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public bool HasValidStartAndEnd()
        {
            if (EndDateTime <= StartDateTime)
            {
                return false;
            }
            return true;
        }
    }
}
