package oneLvShop.customExeptions;

public class ProductOutOfStockException extends Exception {

    public ProductOutOfStockException() {
        super("Sorry! The product is out of stock.");
    }
}
