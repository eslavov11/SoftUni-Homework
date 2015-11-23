using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BookShop
{
    class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Title cannot be empty!");
                }

                title = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Author's name cannot be empty!");
                }

                author = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value < 0)
                {
                    throw new FormatException("Price cannot be a negative number!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return this.Price.ToString();
        }
    }
}

