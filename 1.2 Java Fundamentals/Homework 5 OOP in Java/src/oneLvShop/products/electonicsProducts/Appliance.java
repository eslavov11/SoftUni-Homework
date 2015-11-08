package oneLvShop.products.electonicsProducts;

import oneLvShop.products.AgeRestriction;

import java.math.BigDecimal;

public class Appliance extends ElectonicsProduct {

    private final int qunatityForPriceAdditon = 50;

    private static final BigDecimal addition = new BigDecimal("1.05");

    public Appliance(String name, BigDecimal price, double quantity) {
        super(name, price, quantity, AgeRestriction.Adult, 6);
    }

    @Override public BigDecimal getPrice() {
        if (super.getQuantity() < qunatityForPriceAdditon) {
            return super.getPrice()
                        .multiply(addition);
        }
        return super.getPrice();
    }
}
