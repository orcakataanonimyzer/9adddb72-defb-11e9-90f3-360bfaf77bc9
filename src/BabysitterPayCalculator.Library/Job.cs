using System;

namespace BabysitterPayCalculator.Library
{
    public class Job
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        /// <summary>
        ///     Compares the start and end time for validity.
        /// </summary>
        /// <returns>True or false if start and end are valid.</returns>
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
