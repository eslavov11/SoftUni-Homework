using System.Collections.Generic;

namespace NightlifeEntertainment
{
    public class SportsHall : Venue
    {
        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, new List <PerformanceType>
            {
                PerformanceType.Sport, PerformanceType.Concert
            })
        {
        }
    }
}
