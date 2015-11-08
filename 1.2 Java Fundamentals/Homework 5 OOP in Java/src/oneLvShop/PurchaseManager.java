package oneLvShop;

import oneLvShop.customExeptions.BuyerDoesNotHaveEnoughMoneyException;
import oneLvShop.customExeptions.CustomerTooYoungException;
import oneLvShop.customExeptions.ProductHasExpiredException;
import oneLvShop.customExeptions.ProductOutOfStockException;
import oneLvShop.customers.Customer;
import oneLvShop.products.AgeRestriction;
import oneLvShop.products.FoodProduct;
import oneLvShop.products.Product;

import java.time.LocalDate;
import java.time.temporal.ChronoUnit;

// http://stackoverflow.com/questions/7486012/static-classes-in-java
public final class PurchaseManager {

    private static final int minAdultAge = 18;

    private PurchaseManager() {
    }
// moje vmesto custom exeptions da se polzvat IllegalArgumentException
    public static void processPurchase(Customer customer, Product product) throws ProductHasExpiredException,
                                                                                  ProductOutOfStockException,
                                                                                  BuyerDoesNotHaveEnoughMoneyException,
                                                                                  CustomerTooYoungException {
        if (product instanceof FoodProduct) {
            long daysBetween = ChronoUnit.DAYS.between(LocalDate.now(), ((FoodProduct) product).getExpirationDate());
            if (daysBetween <= 0) {
                throw new ProductHasExpiredException();
            }
        }
        if (product.getQuantity() < 1) {
            throw new ProductOutOfStockException();
        }
        if (customer.getBalance()
                    .compareTo(product.getPrice()) == -1) {
            throw new BuyerDoesNotHaveEnoughMoneyException();
        }
        if (product.getAgeRestriction() == AgeRestriction.Adult &&
                customer.getAge() < minAdultAge) {
            throw new CustomerTooYoungException();
        }
        customer.setBalance(customer.getBalance()
                                    .subtract(product.getPrice()));
        product.setQuantity(product.getQuantity() - 1);
    }
}
