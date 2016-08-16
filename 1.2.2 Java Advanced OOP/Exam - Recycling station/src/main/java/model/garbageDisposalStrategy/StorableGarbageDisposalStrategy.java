package model.garbageDisposalStrategy;

import model.processingData.RecyclingStationProcessingData;
import wasteDisposal.Contracts.GarbageDisposalStrategy;
import wasteDisposal.Contracts.ProcessingData;
import wasteDisposal.Contracts.Waste;

/**
 * Created by Edi on 07-Aug-16.
 */
public class StorableGarbageDisposalStrategy implements GarbageDisposalStrategy {
    @Override
    public ProcessingData processGarbage(Waste garbage) {
        double producedEnergy = 0;
        double usedEnergy = calculateTotalGarbageVolume(garbage) * 0.13;
        double energyBalance = producedEnergy - usedEnergy;

        double earnedCapital = 0;
        double usedCapital = calculateTotalGarbageVolume(garbage) * 0.65;
        double capitalBalance = earnedCapital - usedCapital;

        ProcessingData processingData = new RecyclingStationProcessingData(energyBalance, capitalBalance);

        return processingData;
    }

    private double calculateTotalGarbageVolume(Waste garbage) {
        return garbage.getWeight() * garbage.getVolumePerKg();
    }
}
