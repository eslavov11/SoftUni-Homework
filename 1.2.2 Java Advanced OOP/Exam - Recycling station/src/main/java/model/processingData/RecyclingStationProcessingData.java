package model.processingData;

import wasteDisposal.Contracts.ProcessingData;

/**
 * Created by Edi on 07-Aug-16.
 */
public class RecyclingStationProcessingData implements ProcessingData {
    private double energy;
    private double capital;

    public RecyclingStationProcessingData(double energy, double capital) {
        this.setEnergy(energy);
        this.setCapital(capital);
    }

    @Override
    public double getEnergyBalance() {
        return this.energy;
    }

    private void setCapital(double capital) {
        this.capital = capital;
    }

    @Override
    public double getCapitalBalance() {
        return this.capital;
    }

    private void setEnergy(double energy) {
        this.energy = energy;
    }
}
