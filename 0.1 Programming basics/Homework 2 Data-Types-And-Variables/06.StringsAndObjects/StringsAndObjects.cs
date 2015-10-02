using System;

namespace _06.StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main()
        {
            string hello = "Hello ";
            string world = "World";

            object stringConcatenation = hello + world;

            Console.WriteLine(stringConcatenation.ToString());
        }
    }
}
