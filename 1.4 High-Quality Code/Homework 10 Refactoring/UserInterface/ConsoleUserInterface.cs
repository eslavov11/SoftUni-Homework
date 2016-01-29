namespace Matrix.UserInterface
{
    using System;
    using Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void WriteLine(string arg)
        {
            Console.WriteLine(arg);
        }

        public void WriteLine(string obj, params object[] args)
        {
            Console.WriteLine(obj, args);
        }

        public void Write(string obj, params object[] args)
        {
            Console.Write(obj, args);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
