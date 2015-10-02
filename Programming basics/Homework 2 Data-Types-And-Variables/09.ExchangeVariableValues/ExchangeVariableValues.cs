using System;

namespace _09.ExchangeVariableValues
{
    class ExchangeVariableValues
    {
        static void Main()
        {
            int a = 5;
            int b = 10;
            int temp = new int();
            Console.WriteLine("Before: ");
            Console.WriteLine("a = {0}",a);
            Console.WriteLine("b = {0}",b);

            //Exchange
            temp = b;
            b = a;
            a = temp;
            Console.WriteLine("After: ");
            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
        }
    }
}
