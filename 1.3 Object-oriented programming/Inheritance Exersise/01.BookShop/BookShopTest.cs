using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BookShop
{
    class BookShopTest
    {
        static void Main(string[] args)
        {
            Book book = new Book("Pod igoto", "Ivan Vazov", 33.5m);
            GoldenBookEdition gBook = new GoldenBookEdition("Фифти шейдс оф грей", "Бай Манол", 40);
            Console.WriteLine(book);
            Console.WriteLine(gBook);
        }
    }
}
