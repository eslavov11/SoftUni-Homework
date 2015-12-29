namespace Orders.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
    }
}
