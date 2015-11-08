package oneLvShop.products;

import oneLvShop.customExeptions.ProductHasExpiredException;
import oneLvShop.interfaces.Expirable;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;

public class FoodProduct extends Product implements Expirable {

    private static final BigDecimal discount = new BigDecimal("0.70");

    private LocalDate expirationDate;

    public FoodProduct(String name, BigDecimal price, double quantity, AgeRestriction ageRestriction, LocalDate expirationDate) {
        super(name, price, quantity, ageRestriction);
        this.setExpirationDate(expirationDate);
    }

    public void setExpirationDate(LocalDate expirationDate) {
//        long daysBetween = ChronoUnit.DAYS.between(LocalDate.now(), this.getExpirationDate());
//        try {
//            if (daysBetween <= 0) {
//                throw new ProductHasExpiredException();
//            }
//        }
//        catch (ProductHasExpiredException exeption){
//            System.out.println(exeption.getMessage());
//        }
        this.expirationDate = expirationDate;
    }

    @Override public LocalDate getExpirationDate() {
        return this.expirationDate;
    }

    @Override public BigDecimal getPrice() {
        long daysBetween = ChronoUnit.DAYS.between(LocalDate.now(), this.getExpirationDate());
        if (daysBetween <= 15) {
            return super.getPrice()
                        .multiply(discount);
        }
        return super.getPrice();
    }
}
