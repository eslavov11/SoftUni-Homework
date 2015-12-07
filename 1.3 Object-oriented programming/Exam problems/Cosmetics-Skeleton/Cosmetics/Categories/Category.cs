using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;

namespace Cosmetics.Categories
{
    public class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        private IList<IProduct> products;
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                    value, 
                    MaxCategoryNameLength,
                    MinCategoryNameLength,
                    $"Category name must be between {MinCategoryNameLength} and " +
                    $"{MaxCategoryNameLength} symbols long!");
                this.name = value;
            }
        }

        public IEnumerable<IProduct> Products
        {
            get
            {
                return this.products
                    .OrderBy(x => x.Brand)
                    .ThenByDescending(x => x.Price);
            }
            private set { this.products = value.ToList(); }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics.Name,
                $"Product {cosmetics.Name} does not exist in category {this.Name}!");
            this.products.Remove(cosmetics);
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{this.Name} category - {this.products.Count}" + 
                (this.products.Count == 1 ? 
                " product " :
                " products ") +
                "in total");
            if (this.products.Count > 0)
            {
                result.AppendLine();
            }
            else
            {
                return result.ToString();
            }
            foreach (var product in Products)
            {
                result.AppendLine($"- {product.Brand} - {product.Name}:");
                result.AppendLine($"  * Price: ${product.Price}");
                result.AppendLine($"  * For gender: {product.Gender}");
                result.AppendLine(product.Print());
            }

            return result.ToString().Substring(0, result.Length-2);
        }
    }
}
