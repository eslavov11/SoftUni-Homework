package core;

/**
 * Created by Edi on 07-Aug-16.
 */
public class RecyclingStationResourcesBalance implements ResourcesBalance {
    private static final double STARTING_ENERGY_BALANCE = 0;
    private static final double STARTING_CAPITAL_BALANCE = 0;

    private double energyBalance;
    private double capitalBalance;

    public RecyclingStationResourcesBalance() {
        this.setEnergyBalance(STARTING_ENERGY_BALANCE);
        this.setCapitalBalance(STARTING_CAPITAL_BALANCE);
    }

    @Override
    public double getEnergyBalance() {
        return this.energyBalance;
    }

    @Override
    public void setEnergyBalance(double energyBalance) {
        this.energyBalance = energyBalance;
    }

    @Override
    public double getCapitalBalance() {
        return this.capitalBalance;
    }

    @Override
    public void setCapitalBalance(double capitalBalance) {
        this.capitalBalance = capitalBalance;
    }
}
