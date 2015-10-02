using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MatrixOfPalindromes
{
    static void Main()
    {
        Console.Write("r= ");
        int r = int.Parse(Console.ReadLine());
        Console.Write("c= ");
        int c = int.Parse(Console.ReadLine());
        char newChar = 'a';

        for (int i = 0; i < r; i++)
        {

            for (int j = 0; j < c; j++)
            {
                char nextNewChar = Convert.ToChar(newChar + j);

                Console.Write("{0}{1}{0} ", newChar, nextNewChar);

            }
            Console.WriteLine();
            newChar++;
        }

    }
}