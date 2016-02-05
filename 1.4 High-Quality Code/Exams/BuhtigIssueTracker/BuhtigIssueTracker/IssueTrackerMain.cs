namespace BuhtigIssueTracker
{
    using System.Globalization;
    using System.Threading;
    using Execution;
    using Interfaces;
    using UserInterface;

    public class IssueTrackerMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            IUserInterface userInterface = new ConsoleUserInterface();
            var commandExecutor = new CommandExecutor();

            IEngine engine = new IssueTrackerEngine(commandExecutor, userInterface);
            engine.Run();
        }
    }
}
