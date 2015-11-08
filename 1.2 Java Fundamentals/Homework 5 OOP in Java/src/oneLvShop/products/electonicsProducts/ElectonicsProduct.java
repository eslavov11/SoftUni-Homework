package oneLvShop.products.electonicsProducts;

import oneLvShop.products.AgeRestriction;
import oneLvShop.products.Product;

import java.math.BigDecimal;

public class ElectonicsProduct extends Product {

    private int guaranteePeriod;

    public ElectonicsProduct(String name, BigDecimal price, double quantity, AgeRestriction ageRestriction, int guaranteePeriod) {
        super(name, price, quantity, ageRestriction);
        this.setGuaranteePeriod(guaranteePeriod);
    }

    public int getGuaranteePeriod() {
        return guaranteePeriod;
    }

    public void setGuaranteePeriod(int guaranteePeriod) {
        if (guaranteePeriod < 0) {
            throw new IllegalArgumentException("Guarantee period cannot be negative.");
        }
        this.guaranteePeriod = guaranteePeriod;
    }
}
