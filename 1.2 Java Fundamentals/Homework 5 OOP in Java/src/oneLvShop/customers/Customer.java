package oneLvShop.customers;

import java.math.BigDecimal;

public class Customer {

    private static final int maxAge = 120;

    private String name;

    private int age;

    private BigDecimal balance;

    public Customer(String name, int age, BigDecimal balance) {
        this.setName(name);
        this.setAge(age);
        this.setBalance(balance);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name.isEmpty() || name == null) {
            throw new IllegalArgumentException("Name cannot be empty.");
        }
        this.name = name;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        if (age < 0 || age > maxAge) {
            throw new IllegalArgumentException(String.format("Age cannot be negative or above %d", maxAge));
        }
        this.age = age;
    }

    public BigDecimal getBalance() {
        return this.balance;
    }

    public void setBalance(BigDecimal balance) {
        if (balance.compareTo(new BigDecimal("0.0")) == -1) {
            throw new IllegalArgumentException("Balance cannot be negative.");
        }
        this.balance = balance;
    }
}
