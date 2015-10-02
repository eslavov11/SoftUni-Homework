using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formatting_Numbers
{
    class FormattingNumbers
    {
        static void Main(string[] args)
        {
            short a = short.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            Console.Write('|' + Convert.ToString(a,16).ToUpper().PadRight(10) + '|');
            Console.Write(Convert.ToString(a, 2).PadLeft(10, '0') + '|');
            Console.Write(b.ToString("0.00").PadLeft(10) + '|');
            Console.WriteLine(c.ToString("0.000").PadRight(10) + '|');
        }
    }
}
// 254	11.6	0.5	    |FE        |0011111110|     11.60|0.500     |
// 499	-0.5559	10000	|1F3       |0111110011|     -0.56|10000.000 |
// 0	3	-0.1234	    |0         |0000000000|         3|-0.123    |
