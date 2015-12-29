namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    public class OrdersApplication
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var categories = dataMapper.GetCategories();
            var products = dataMapper.GetProducts();
            var orders = dataMapper.GetOrders();

            // Print names of the 5 most expensive products
            var firstFiveMostExpensiveProducts = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(5)
                .Select(p => p.Nome);
            Console.WriteLine(string.Join(Environment.NewLine, firstFiveMostExpensiveProducts));

            Console.WriteLine(new string('-', 10));

            // Print number of products in each category
            var productsInEachCategory = products
                .GroupBy(p => p.CategoryId)
                .Select(group =>
                new
                {
                    Category = categories.First(cat => cat.Id == group.Key).Name, Count = group.Count()
                })
                .ToList();

            foreach (var product in productsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", product.Category, product.Count);
            }

            Console.WriteLine(new string('-', 10));

            // Print the 5 top products (by Order quantity)
            var topFiveProductsByOrderQuantity = orders
                .GroupBy(
                    order => order.ProductId)
                    .Select(group =>
                    new
                    {
                        Product = products.First(p => p.Id == group.Key).Nome,
                        Quantities = group.Sum(order => order.Quantity)
                    })
                .OrderByDescending(q => q.Quantities)
                .Take(5);

            foreach (var item in topFiveProductsByOrderQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            // Print the most profitable category
            var category = orders
                .GroupBy(id => id.ProductId)
                .Select(group => new
                {
                    catId = products.First(p => p.Id == group.Key).CategoryId,
                    price = products.First(p => p.Id == group.Key).UnitPrice,
                    quantity = group.Sum(p => p.Quantity)
                })
                .GroupBy(group => group.catId)
                .Select(group => new
                {
                    CategoryName = categories.First(c => c.Id == group.Key).Name,
                    TotalQuantity = group.Sum(g => g.quantity * g.price)
                })
                .OrderByDescending(g => g.TotalQuantity)
                .First();
            Console.WriteLine("{0}: {1}", category.CategoryName, category.TotalQuantity);
        }
    }
}
