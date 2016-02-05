namespace CustomerService
{
    using CustomerService.Data;
    using CustomerService.Models;

    public class Program
    {
        static void Main()
        {
            var repository = new CustomerRepository();

            var premiumCustomers = repository.GetPremiumCustomers();
            foreach (var premiumCustomer in premiumCustomers)
            {
                premiumCustomer.RaiseDiscount(5.0);
            }

            var allCustomers = repository.GetAll();
            foreach (var customer in allCustomers)
            {
                customer.AddFreePurchase(new Purchase("SteamOp", 0.0));
            }
        }
    }
}
