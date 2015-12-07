using System;

namespace NightlifeEntertainment
{
    public class Concert : Performance
    {
        public Concert(string name, decimal basePrice, IVenue venue, DateTime startTime)
            : base(name, basePrice, venue, startTime, PerformanceType.Concert)
        {
        }

        protected override void ValidateVenue()
        {
            if (!this.Venue.AllowedTypes.Contains(PerformanceType.Concert) &&
                !this.Venue.AllowedTypes.Contains(PerformanceType.Opera))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "The venue {0} does{2} not support the type of performance {1}",
                        this.Venue.Name, 
                        this.Type,
                        "ARG2"));
            }
        }
    }
}
