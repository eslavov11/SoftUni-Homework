using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6.BitArray
{
    class BitArrayTest
    {
        static void Main(string[] args)
        {
            BitArray num = new BitArray(8);
            num[0] = 0;
            num[3] = 1;
            Console.WriteLine(num);
        }
    }
}
