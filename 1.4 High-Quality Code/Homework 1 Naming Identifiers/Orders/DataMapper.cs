using System.Collections.Generic;
using System.Linq;
using System.IO;
using Orders.Models;

namespace Orders
{
    public class DataMapper
    {
        private const string CategoriesFilePath = "../../Data/categories.txt";
        private const string ProductsFilePath = "../../Data/products.txt";
        private const string OrdersFilePath = "../../Data/orders.txt";

        private readonly string CategoriesFileName;
        private readonly string ProductsFileName;
        private readonly string OrdersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.CategoriesFileName = categoriesFileName;
            this.ProductsFileName = productsFileName;
            this.OrdersFileName = ordersFileName;
        }

        public DataMapper()
            : this(CategoriesFilePath, ProductsFilePath, OrdersFilePath)
        {
        }

        public IEnumerable<Category> GetCategories()
        {
            bool hasHeader = true;
            var category = ReadFile(this.CategoriesFileName, hasHeader);
            return category
                .Select(cat => cat.Split(','))
                .Select(cat => new Category
                {
                    Id = int.Parse(cat[0]),
                    Name = cat[1],
                    Description = cat[2]
                });
        }

        public IEnumerable<Product> GetProducts()
        {
            bool hasHeader = true;
            var product = ReadFile(this.ProductsFileName, hasHeader);
            return product
                .Select(prod => prod.Split(','))
                .Select(prod => new Product
                {
                    Id = int.Parse(prod[0]),
                    Nome = prod[1],
                    CategoryId = int.Parse(prod[2]),
                    UnitPrice = decimal.Parse(prod[3]),
                    UnitsInStock = int.Parse(prod[4]),
                });
        }

        public IEnumerable<Order> GetOrders()
        {
            bool hasHeader = true;
            var order = ReadFile(this.OrdersFileName, hasHeader);
            return order
                .Select(or => or.Split(','))
                .Select(or => new Order
                {
                    Id = int.Parse(or[0]),
                    ProductId = int.Parse(or[1]),
                    Quantity = int.Parse(or[2]),
                    Discount = decimal.Parse(or[3]),
                });
        }

        private static IEnumerable<string> ReadFile(string fileName, bool hasHeader)
        {
            var fullFile = new List<string>();
            using (var reader = new StreamReader(fileName))
            {
                string currentLine = null;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    fullFile.Add(currentLine);
                }
            }

            return fullFile;
        }
    }
}
