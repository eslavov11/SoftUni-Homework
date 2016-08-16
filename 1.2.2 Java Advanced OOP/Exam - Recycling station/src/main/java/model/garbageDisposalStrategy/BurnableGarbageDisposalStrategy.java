package model.garbageDisposalStrategy;

import model.processingData.RecyclingStationProcessingData;
import wasteDisposal.Contracts.GarbageDisposalStrategy;
import wasteDisposal.Contracts.ProcessingData;
import wasteDisposal.Contracts.Waste;

/**
 * Created by Edi on 07-Aug-16.
 */
public class BurnableGarbageDisposalStrategy implements GarbageDisposalStrategy {
    @Override
    public ProcessingData processGarbage(Waste garbage) {
        double producedEnergy = calculateTotalGarbageVolume(garbage);
        double usedEnergy = calculateTotalGarbageVolume(garbage) * 0.2;
        double energyBalance = producedEnergy - usedEnergy;

        double earnedCapital = 0;
        double usedCapital = 0;
        double capitalBalance = earnedCapital - usedCapital;

        ProcessingData processingData = new RecyclingStationProcessingData(energyBalance, capitalBalance);

        return processingData;
    }

    private double calculateTotalGarbageVolume(Waste garbage) {
        return garbage.getWeight() * garbage.getVolumePerKg();
    }
}
