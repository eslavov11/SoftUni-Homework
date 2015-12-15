using System;
using Empires.Interfaces;

namespace Empires.UserInterface
{
    public class ConsoleUserInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args );
        }
    }
}
