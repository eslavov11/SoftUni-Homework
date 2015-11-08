package oneLvShop.customExeptions;

public class ProductHasExpiredException extends Exception {

    public ProductHasExpiredException() {
        super("Sorry! The product has expired.");
    }
}
