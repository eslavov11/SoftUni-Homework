namespace Main
{
    using Logger;
    using Logger.DataAppender;
    using Logger.Interfaces;

    public class LoggerMain
    {
        public static void Main()
        {
            ILayout simpleLayout = new SimpleLayout();
            IDataAppender consoleAppender =
                 new ConsoleAppender(simpleLayout);
            ILogger logger = new Logger(consoleAppender);

            logger.Error("Error parsing JSON.");
            logger.Info($"User {"Pesho"} successfully registered.");

            var fileAppender = new FileAppender(simpleLayout, "log.txt");
            logger = new Logger(fileAppender);
            logger.Error("Error parsing JSON.");
            logger.Info($"User {"Pesho"} successfully registered.");
            logger.Warn("Warning - missing files.");
        }
    }
}
