package app.population;

import app.items.Toy;

import java.util.List;

/**
 * Created by Edi on 09-Jul-16.
 */
public class Child {
    private double foodCost;
    private List<Toy> toys;

    public Child(double foodCost, List<Toy> toys) {
        this.setToys(toys);
        this.setFoodCost(foodCost);
    }

    public double getFoodCost() {
        return foodCost;
    }

    public void setFoodCost(double foodCost) {
        this.foodCost = foodCost;
    }

    public List<Toy> getToys() {
        return toys;
    }

    public void setToys(List<Toy> toys) {
        this.toys = toys;
    }

    public double getToysCost() {
        return this.getToys().stream().mapToDouble(Toy::getCost).sum();
    }

    public double getTotalCost() {
        return this.getFoodCost() + this.getToysCost();
    }
}
