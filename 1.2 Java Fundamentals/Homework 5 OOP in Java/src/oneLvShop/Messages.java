package oneLvShop;

public final class Messages {
    private Messages(){}

    public static final String invalidProductName = "Product name cannot be empty.";
    public static final String invalidProductPrice = "The price of product cannot be a negative number.";
    public static final String invalidProductQuantity = "The quantity of product cannot be a negative number.";
    public static final String noProductQuantity = "Tho product is out of stock";
    public static final String invalidProductDateOfExpiration = "The date of expiration cannot be earlier than date of product creation.";
    public static final String expiredProduct = "the product has expired.";
    public static final String invalidCustomerName = "Customer name cannot be empty.";
    public static final String invalidCustomerAge = "Customer age cannot be a negative number.";
    public static final String invalidCustomerBalance = "Customer balance cannot be a negative number.";
    public static final String notEnoughMoney = "The buyer does not have enough money";
    public static final String notOldEnough = "The buyer does not have permission to purchase the given product";
}
