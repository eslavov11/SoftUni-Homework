namespace Theatre.Execution
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Data;
    using Interfaces;

    public class TheatreEngine
    {
        private readonly IPerformanceDatabase theatreDatabase;

        public TheatreEngine()
        {
            this.theatreDatabase = new PerformanceDatabase();
        }

        public void Run()
        {
            //var output = new StringBuilder();
            string commandLine = Console.ReadLine();

            while (commandLine != null)//null
            {
                if (commandLine != string.Empty)
                {
                    string[] commandParts = commandLine.Split('(');
                    string commandName = commandParts[0];
                    string commandMessage;
                    try
                    {
                        commandMessage = ParseCommand(commandLine, commandName);
                    }
                    catch (Exception ex)
                    {
                        commandMessage = "Error: " + ex.Message;
                    }

                    Console.WriteLine(commandMessage);
                }

                commandLine = Console.ReadLine();
            }
        }

        private string ParseCommand(string commandLine, string commandName)
        {
            string commandMessage;
            string[] commandParts = commandLine.Split(
                        new[] { '(', ',', ')' },
                        StringSplitOptions.RemoveEmptyEntries);
            string[] commandParams = commandParts
                        .Skip(1).Select(p => p.Trim())
                        .ToArray();

            switch (commandName)
            {
                case "AddTheatre":
                    commandMessage = CommandExecutor.ExecuteAddTheatreCommand(commandParams, this.theatreDatabase);
                    break;
                case "PrintAllTheatres":
                    commandMessage = CommandExecutor.ExecutePrintAllTheatresCommand(this.theatreDatabase);
                    break;
                case "AddPerformance":
                    string theatreName = commandParams[0];
                    string performanceTitle = commandParams[1];
                    DateTime startDateTime = DateTime.ParseExact(
                        commandParams[2],
                        "dd.MM.yyyy HH:mm",
                        CultureInfo.InvariantCulture);
                    TimeSpan duration = TimeSpan.Parse(commandParams[3]);
                    decimal price = decimal.Parse(commandParams[4]) ;//NumberStyles.Float)

                    this.theatreDatabase.AddPerformance(
                        theatreName,
                        performanceTitle,
                        startDateTime,
                        duration,
                        price);
                    commandMessage = "Performance added";
                    break;

                case "PrintAllPerformances":
                    commandMessage = CommandExecutor.ExecutePrintAllPerformancesCommand(this.theatreDatabase);
                    break;

                case "PrintPerformances":
                    string theatre = commandParams[0];
                    var performances = this.theatreDatabase.ListPerformances(theatre).Select(
                        p =>
                        {
                            string result1 = p.StartDateTime.ToString("dd.MM.yyyy HH:mm");
                            return $"({p.PerformanceTitle}, {result1})";
                        }).ToList();

                    commandMessage = performances.Any() ?
                        string.Join(", ", performances) :
                        "No performances";
                    break;

                default:
                    commandMessage = "Invalid command!";
                    break;
            }

            return commandMessage;
        }
    }
}
