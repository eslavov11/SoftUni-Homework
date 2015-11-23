using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BookShop
{
    class GoldenBookEdition : Book
    {
        private const decimal Rate = 1.3m;

        public GoldenBookEdition(string title, string author, decimal price)
            : base(title, author, price * Rate)
        {

        }

        public override decimal Price
        {
            get
            {
                return base.Price * Rate;  
            }

            set
            {
                base.Price = value;
            }
        }
    }
}
