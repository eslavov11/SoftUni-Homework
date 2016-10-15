package kasov_aparat;

import java.util.ArrayList;
import java.util.Date;

public class CashRegister {
    private double cashAmount;
    private String companyName;
    private ArrayList<Product> products;
    protected ArrayList<Bond> bonds;

    public double getCashAmount() {
        return cashAmount;
    }

    public void setCashAmount(double cashAmount) {
        this.cashAmount = cashAmount;
    }

    public String getCompanyName() {
        return companyName;
    }

    public void setCompanyName(String companyName) {
        this.companyName = companyName;
    }

    public void addBond(Bond bond) {
        this.bonds.add(bond);
    }

    public void initialize() {
        this.bonds = new ArrayList<>();

        this.products = new ArrayList<Product>() {{
                add(new Product(1, "Product 1", 10));
                add(new Product(2, "Product 2", 20.5));
                add(new Product(3, "Product 3", 30));
            }};

        this.setCompanyName("Company 1");

        this.setCashAmount(0);
    }

    public Bond newBond(int id, Date date, ArrayList<Position> positions) {
        return new Bond(id, date, positions);
    }

    public void printBond(Bond bond) {
        System.out.println("Company name: " + this.getCompanyName());
        System.out.println(bond);
    }

    public static void main(String[] args) {
        CashRegister cashRegister = new CashRegister();
        cashRegister.initialize();

        Bond b1 = cashRegister.newBond(1, new Date(),
                new ArrayList<Position>() {{
                    add(new Position(1, 1, 1));
                }});
        Bond b2 = cashRegister.newBond(2, new Date(),
                new ArrayList<Position>() {{
                    add(new Position(2, 2, 1));
                    add(new Position(2, 2, 5));
                }});
        Bond b3 = cashRegister.newBond(3,
                new Date(),
                new ArrayList<Position>() {{
                    add(new Position(1, 3, 8));
                    add(new Position(4, 3, 5));
                    add(new Position(4, 3, 10));
                }});

        cashRegister.printBond(b1);
        cashRegister.printBond(b2);
        cashRegister.printBond(b3);
    }
}
