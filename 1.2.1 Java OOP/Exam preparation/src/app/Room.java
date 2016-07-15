package app;

/**
 * Created by Edi on 10-Jul-16.
 */
public class Room {
    private double electricityCost;

    public Room(double electricityCost) {
        this.setElectricityCost(electricityCost);
    }

    public double getElectricityCost() {
        return electricityCost;
    }

    public void setElectricityCost(double electricityCost) {
        this.electricityCost = electricityCost;
    }
}
