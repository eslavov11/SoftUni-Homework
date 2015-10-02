using System;

namespace _12.NullValuesArithmetic
{
    class NulllValuesArithmetic
    {
        static void Main()
        {
            int? intNullVar = int.Parse(null);
            double? doubleNullVar = null;

            Console.WriteLine(intNullVar);
            Console.WriteLine(doubleNullVar);
            int? nullableWithValue = 3;
            Console.WriteLine(intNullVar + 2);
            Console.WriteLine(doubleNullVar + 2);
            Console.WriteLine(intNullVar + null);
            Console.WriteLine(doubleNullVar + null);
        }
    }
}
