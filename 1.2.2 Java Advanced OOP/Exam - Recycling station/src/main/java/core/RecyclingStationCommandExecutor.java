package core;

import annotation.BurnableGarbageAnnotation;
import annotation.RecyclableGarbageAnnotation;
import annotation.StorableGarbageAnnotation;
import model.garbageDisposalStrategy.BurnableGarbageDisposalStrategy;
import model.garbageDisposalStrategy.RecyclableGarbageDisposalStrategy;
import model.garbageDisposalStrategy.StorableGarbageDisposalStrategy;
import utility.Constants;
import utility.Messages;
import wasteDisposal.Contracts.GarbageProcessor;
import wasteDisposal.Contracts.ProcessingData;
import wasteDisposal.Contracts.Waste;
import wasteDisposal.DefaultGarbageProcessor;

import java.lang.reflect.Constructor;

/**
 * Created by Edi on 07-Aug-16.
 */
public class RecyclingStationCommandExecutor implements CommandExecutor {
    private GarbageProcessor garbageProcessor;
    private ResourcesBalance resourcesBalance;

    public RecyclingStationCommandExecutor() {
        this.garbageProcessor = new DefaultGarbageProcessor();
        this.addGarbageProcessorStrategies();
        this.resourcesBalance = new RecyclingStationResourcesBalance();
    }

    @Override
    public String execute(Command command) {
        String commandResult = null;

        switch (command.getName()) {
            case Constants.PROCESS_GARBAGE_COMMAND:
                commandResult = this.executeProcessGarbageCommand(command);
                break;
            case Constants.STATUS_COMMAND:
                commandResult = String.format(Messages.STATUS,
                        this.resourcesBalance.getEnergyBalance(),
                        this.resourcesBalance.getCapitalBalance());
                break;
            case Constants.CHANGE_MANAGEMENT_REQUIREMENT_COMMAND:
                //TODO: execute command
                break;
            default:
                // TODO: NO such command
                break;
        }

        return commandResult;
    }

    private String executeProcessGarbageCommand(Command command) {
        String commandMessage = null;

        String garbageName = command.getArguments()[0];
        double garbageWeight = Double.parseDouble(command.getArguments()[1]);
        double garbageVolumePerKg = Double.parseDouble(command.getArguments()[2]);
        String garbageType = command.getArguments()[3];

        try {
            Constructor wasteConstructor = Class.forName(Constants.GARBAGE_PACKAGE_NAME +
                    garbageType +
                    Constants.GARBAGE_NAME_SUFFIX)
                    .getConstructor(String.class, double.class, double.class);
            Waste newWaste = (Waste) wasteConstructor.newInstance(garbageName, garbageWeight, garbageVolumePerKg);

            ProcessingData processingData = this.garbageProcessor.processWaste(newWaste);
            this.resourcesBalance.setEnergyBalance(this.resourcesBalance.getEnergyBalance() + processingData.getEnergyBalance());
            this.resourcesBalance.setCapitalBalance(this.resourcesBalance.getCapitalBalance() + processingData.getCapitalBalance());

            commandMessage = String.format(Messages.PROCESS_GARBAGE_SUCCESS, garbageWeight, garbageName);
        } catch (Exception e) {
            e.printStackTrace();
            //TODO: ERROR MESSAGE
        }

        return commandMessage;
    }

    private void addGarbageProcessorStrategies() {
        this.garbageProcessor.getStrategyHolder().addStrategy(BurnableGarbageAnnotation.class, new BurnableGarbageDisposalStrategy());
        this.garbageProcessor.getStrategyHolder().addStrategy(RecyclableGarbageAnnotation.class, new RecyclableGarbageDisposalStrategy());
        this.garbageProcessor.getStrategyHolder().addStrategy(StorableGarbageAnnotation.class, new StorableGarbageDisposalStrategy());
    }
}
