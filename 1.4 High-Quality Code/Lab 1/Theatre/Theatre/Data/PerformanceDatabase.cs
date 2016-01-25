namespace Theatre.Data
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;
    using Models;

    public class PerformanceDatabase : IPerformanceDatabase
    {
        //TODO: PERFORMANCE CHECK
        private readonly SortedDictionary<string, SortedSet<Performance>> sortedDictionaryStringSortedSetPermance;

        public PerformanceDatabase()
        {
            this.sortedDictionaryStringSortedSetPermance = new SortedDictionary<string, SortedSet<Performance>>();
        }

        public void AddTheatre(string threatreName)
        {
            if (this.sortedDictionaryStringSortedSetPermance.ContainsKey(threatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.sortedDictionaryStringSortedSetPermance[threatreName] = new SortedSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.sortedDictionaryStringSortedSetPermance.Keys;

            return theatres;
        }

         public void AddPerformance(
             string theatreName, 
             string performanceTitle, 
             DateTime startDateTime,
             TimeSpan duration, 
             decimal price)
        {
            if (!this.sortedDictionaryStringSortedSetPermance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.sortedDictionaryStringSortedSetPermance[theatreName];

            var endDateTime = startDateTime + duration;

            if (PerformancesOverlap(performances, startDateTime, endDateTime))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var performance = new Performance(
                theatreName, 
                performanceTitle,
                startDateTime,
                duration,
                price);
            performances.Add(performance);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.sortedDictionaryStringSortedSetPermance.Keys;

            var allPerformances = new List<Performance>();

            foreach (var theatre in theatres)
            {
                var performances = this.sortedDictionaryStringSortedSetPermance[theatre];
                allPerformances.AddRange(performances);
            }

            return allPerformances;
        }

        IEnumerable<Performance> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.sortedDictionaryStringSortedSetPermance.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.sortedDictionaryStringSortedSetPermance[theatreName];

            return performances;
        }
        
        private static bool PerformancesOverlap(
            IEnumerable<Performance> performances, 
            DateTime performanceStartDateTime,
            DateTime performanceEndDateTime)
        {
            foreach (var performance in performances)
            {
                var startDateTime = performance.StartDateTime;

                var endDateTime = performance.StartDateTime + performance.Duration;

                if ((startDateTime <= performanceStartDateTime && performanceStartDateTime <= endDateTime) ||
                     (startDateTime <= performanceEndDateTime && performanceEndDateTime <= endDateTime) ||
                     (performanceStartDateTime <= startDateTime && startDateTime <= performanceEndDateTime) ||
                     (performanceStartDateTime <= endDateTime && endDateTime <= performanceEndDateTime))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
