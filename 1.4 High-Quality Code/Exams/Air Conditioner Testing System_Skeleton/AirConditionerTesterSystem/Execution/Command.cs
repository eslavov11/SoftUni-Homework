namespace AirConditionerTesterSystem.Execution
{
    using System;

    using AirConditionerTesterSystem.Utility;

    public class Command
    {
        public Command(string line)
        {
            try
            {
                this.Name = line.Substring(0, line.IndexOf(' '));

                this.Parameters = line.Substring(line.IndexOf(' ') + 1)
                    .Split(new char[] { '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Constants.InvalidCommand, ex);
            }
        }

        public string Name { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
