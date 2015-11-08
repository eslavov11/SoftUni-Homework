package oneLvShop.products.electonicsProducts;

import oneLvShop.products.AgeRestriction;

import java.math.BigDecimal;

public class Computer extends ElectonicsProduct {

    private final int qunatityForPriceDiscount = 1000;

    private static final BigDecimal discount = new BigDecimal("0.95");

    public Computer(String name, BigDecimal price, double quantity) {
        super(name, price, quantity, AgeRestriction.Adult, 24);
    }

    @Override public BigDecimal getPrice() {
        if (super.getQuantity() > qunatityForPriceDiscount) {
            return super.getPrice()
                        .multiply(discount);
        }
        return super.getPrice();
    }
}
