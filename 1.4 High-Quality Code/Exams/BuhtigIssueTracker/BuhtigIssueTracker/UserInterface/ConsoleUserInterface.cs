namespace BuhtigIssueTracker.UserInterface
{
    using System;
    using Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(object arg)
        {
            Console.Write(arg);
        }

        public void WriteLine(object arg)
        {
            Console.WriteLine(arg);
        }

        public void WriteLine(string obj, params object[] args)
        {
            Console.WriteLine(obj, args);
        }
    }
}
