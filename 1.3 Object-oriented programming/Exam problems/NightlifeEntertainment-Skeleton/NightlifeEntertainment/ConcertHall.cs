using System.Collections.Generic;

namespace NightlifeEntertainment
{
    public class ConcertHall : Venue
    {
        public ConcertHall(string name, string location, int numberOfSeats) 
            : base(name, location, numberOfSeats, new List < PerformanceType >
            {
                PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert
            })
        {
        }
    }
}
