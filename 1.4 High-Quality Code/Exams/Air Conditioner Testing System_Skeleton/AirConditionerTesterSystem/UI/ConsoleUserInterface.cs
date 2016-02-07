namespace AirConditionerTesterSystem.UI
{
    using System;
    using System.Text;
    using AirConditionerTesterSystem.Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public StringBuilder result = new StringBuilder();

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            result.AppendLine(message);
        }
    }
}
