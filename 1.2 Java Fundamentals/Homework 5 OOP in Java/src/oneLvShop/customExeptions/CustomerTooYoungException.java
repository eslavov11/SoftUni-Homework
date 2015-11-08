package oneLvShop.customExeptions;

public class CustomerTooYoungException extends Exception {

    public CustomerTooYoungException() {
        super("You are too young to buy this product!");
    }
}
