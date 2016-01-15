namespace Methods.UI
{
    using System;
    using Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string args)
        {
            Console.WriteLine(args);
        }

        public void WriteLine(double args)
        {
            Console.WriteLine(args);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}
