using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Difference_between_Dates
{
    class DifferenceBetweenDates
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            DateTime date2 = DateTime.Parse(Console.ReadLine());
            string days = (date2 - date1).ToString();
            days = days.Remove(days.Length - 9);
            Console.WriteLine(days);
        }
    }
}
