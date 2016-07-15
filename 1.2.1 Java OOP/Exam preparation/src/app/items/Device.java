package app.items;

/**
 * Created by Edi on 09-Jul-16.
 */
public class Device {
    private double electricityCost;

    public Device(double electricityCost) {
        this.setElectricityCost(electricityCost);
    }

    public double getElectricityCost() {
        return electricityCost;
    }

    public void setElectricityCost(double electricityCost) {
        this.electricityCost = electricityCost;
    }
}
