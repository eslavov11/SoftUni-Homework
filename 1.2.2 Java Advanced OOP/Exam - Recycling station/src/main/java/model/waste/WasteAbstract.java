package model.waste;

import wasteDisposal.Contracts.Waste;

/**
 * Created by Edi on 07-Aug-16.
 */
public abstract class WasteAbstract implements Waste {
    private String name;
    private double weight;
    private double volumePerKg;

    protected WasteAbstract(String name, double weight, double volumePerKg) {
        this.setName(name);
        this.setWeight(weight);
        this.setVolumePerKg(volumePerKg);
    }

    @Override
    public String getName() {
        return this.name;
    }

    protected void setName(String name) {
        this.name = name;
    }

    @Override
    public double getVolumePerKg() {
        return this.volumePerKg;
    }

    protected void setWeight(double weight) {
        this.weight = weight;
    }

    @Override
    public double getWeight() {
        return this.weight;
    }

    protected void setVolumePerKg(double volumePerKg) {
        this.volumePerKg = volumePerKg;
    }
}
