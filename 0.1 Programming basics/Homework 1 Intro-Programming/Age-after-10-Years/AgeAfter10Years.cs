using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age_after_10_Years
{
    class AgeAfter10Years
    {
        static void Main(string[] args)
        {
            DateTime birthDay = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Now: {0}", (DateTime.Now.Year - birthDay.Year));
            Console.WriteLine("After 10 Years: {0}", (DateTime.Now.Year - birthDay.Year + 10));
        }
    }
}
