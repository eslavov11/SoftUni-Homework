package app.population;

/**
 * Created by Edi on 09-Jul-16.
 */
public class Person {
    private double income;

    public Person(double income) {
        this.setIncome(income);
    }

    public double getIncome() {
        return income;
    }

    public void setIncome(double income) {
        this.income = income;
    }
}
