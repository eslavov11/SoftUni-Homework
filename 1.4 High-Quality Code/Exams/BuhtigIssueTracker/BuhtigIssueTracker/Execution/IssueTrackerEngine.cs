namespace BuhtigIssueTracker.Execution
{
    using System;
    using System.Text;

    using Interfaces;
    using UserInterface;

    public class IssueTrackerEngine : IEngine
    {
        private readonly CommandExecutor commandExecutor;
        private readonly IUserInterface userInterface;

        public IssueTrackerEngine(CommandExecutor commandExecutor, IUserInterface userInterface)
        {
            this.commandExecutor = commandExecutor;
            this.userInterface = userInterface;
        }

        public IssueTrackerEngine()
            : this(new CommandExecutor(), new ConsoleUserInterface())
        {
        }

        public void Run()
        {
            //var result = new StringBuilder();

            while (true)
            {
                string urlLine = this.userInterface.ReadLine();
                //if (urlLine == "zz")
                //{
                //    break;
                //}

                if (urlLine == null)
                {
                    break;
                }

                urlLine = urlLine.Trim();
                if (string.IsNullOrEmpty(urlLine))
                {
                    continue;
                }

                try
                {
                    var endpoint = new Endpoint(urlLine);
                    string viewResult = this.commandExecutor.DispatchAction(endpoint);
                    this.userInterface.WriteLine(viewResult);
                   // result.AppendLine(viewResult);
                }
                catch (Exception ex)
                {
                   this.userInterface.WriteLine(ex.Message);
                    //result.AppendLine(ex.Message);
                }
            }

            //this.userInterface.WriteLine(result);
        }
    }
}