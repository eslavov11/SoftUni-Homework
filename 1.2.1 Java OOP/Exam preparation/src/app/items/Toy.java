package app.items;

/**
 * Created by Edi on 09-Jul-16.
 */
public class Toy {
    private double cost;

    public Toy(double cost) {
        this.setCost(cost);
    }

    public double getCost() {
        return cost;
    }

    public void setCost(double cost) {
        this.cost = cost;
    }
}
