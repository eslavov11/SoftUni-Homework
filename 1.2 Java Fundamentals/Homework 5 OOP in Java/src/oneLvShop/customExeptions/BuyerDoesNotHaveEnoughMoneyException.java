package oneLvShop.customExeptions;

public class BuyerDoesNotHaveEnoughMoneyException extends Exception {

    public BuyerDoesNotHaveEnoughMoneyException() {
        super("You do not have enough money to buy this product!");
    }
}
