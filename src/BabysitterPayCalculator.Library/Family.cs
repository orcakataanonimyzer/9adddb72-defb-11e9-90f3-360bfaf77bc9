using System.Collections.Generic;

namespace BabysitterPayCalculator.Library
{
    public class Family
    {
        public ICollection<FamilyHourlyRate> FamilyHourlyRates { get; set; } = new HashSet<FamilyHourlyRate>();

        /// <summary>
        ///     Adds the given <see cref="FamilyHourlyRate"/> to the <see cref="FamilyHourlyRates"/> collection.
        /// </summary>
        /// <param name="familyHourlyRate">The family hourly rate to be added.</param>
        public void AddFamilyHourlyRate(FamilyHourlyRate familyHourlyRate)
        {
            FamilyHourlyRates.Add(familyHourlyRate);
        }
    }
}
