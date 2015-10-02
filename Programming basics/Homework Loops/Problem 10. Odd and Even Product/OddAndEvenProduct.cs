using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10.Odd_and_Even_Product
{
    class OddAndEvenProduct
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int evenProduct = 1;
            int oddProduct = 1;
            string[] n = num.Split(' ');
            for (int i = 0; i < n.Length; i++)
            {
                if (i % 2 == 0)
                {
                    evenProduct *= (Convert.ToInt32(n[i]));
                }
                else
                {
                    oddProduct *= (Convert.ToInt32(n[i]));
                }

            }
            if (oddProduct==evenProduct)
            {
                Console.WriteLine("yes");
                Console.WriteLine("Product: " + evenProduct);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("even_product: " + evenProduct);
                Console.WriteLine("odd_product: " + oddProduct);
            }
        }
    }
}
//  2 1 1 6 3	yes
//  product = 6
//  3 10 4 6 5 1	yes
//  product = 60
//  4 3 2 5 2	no
//  odd_product = 16
//  even_product = 15
//  Problem 11.	R
