namespace Theatre.Execution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Theatre.Interfaces;

    public static class CommandExecutor
    {
        public static string ExecuteAddTheatreCommand(string[] parameters, IPerformanceDatabase database)
        {
            string theatreName = parameters[0];
            database.AddTheatre(theatreName);

            return "Theatre added";
        }

        public static string ExecutePrintAllTheatresCommand(IPerformanceDatabase database)
        {
            var theatresCount = database.ListTheatres().Count();

            if (theatresCount == 0)
            {
                return "No theatres";
            }

            var resultTheatres = new LinkedList<string>();

            database.ListTheatres()
                    .ToList()
                    .ForEach(t => resultTheatres.AddLast(t));

            // PERFORMANCE: Useless iteration with foreach loop, which removes elements from Linkedlist 
            // a slow operation
            return string.Join(", ", resultTheatres);
        }

        public static string ExecutePrintAllPerformancesCommand(IPerformanceDatabase database)
        {
            var performances = database.ListAllPerformances().ToList();
            var performanceOutput = new StringBuilder();
            if (!performances.Any())
            {
                return "No performances";
            }

            for (int i = 0; i < performances.Count; i++)
            {
                //PERFORMANCE
                if (i > 0)
                {
                    performanceOutput.Append(", ");
                }

                string startDateTimeAsString = performances[i].StartDateTime.ToString("dd.MM.yyyy HH:mm");
                performanceOutput.AppendFormat(
                    "({0}, {1}, {2})",
                    performances[i].PerformanceTitle,
                    performances[i].TheatreName,
                    startDateTimeAsString);
            }

            return performanceOutput.ToString();
        }
    }
}
