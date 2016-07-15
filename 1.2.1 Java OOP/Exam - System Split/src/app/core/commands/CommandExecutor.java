package app.core.commands;

import app.components.hardware.Hardware;
import app.components.hardware.HeavyHardware;
import app.components.hardware.PowerHardware;
import app.components.software.ExpressSoftware;
import app.components.software.LightSoftware;
import app.components.software.Software;
import app.core.SystemSplitDatabase;
import app.utility.Constants;

import java.util.NoSuchElementException;

/**
 * Created by Edi on 10-Jul-16.
 */
public class CommandExecutor {
    private boolean isExitCommand;
    private SystemSplitDatabase systemSplitDatabase;

    public CommandExecutor() {
        this.isExitCommand = false;
        this.systemSplitDatabase = new SystemSplitDatabase();
    }

    public boolean isExitCommand() {
        return isExitCommand;
    }

    public void execute(Command command) {
        Hardware hardware = null;

        switch (command.getName()) {
            case Constants.REGISTER_POWER_HARDWARE_COMMAND:
                this.systemSplitDatabase.addHardwareComponent(
                        new PowerHardware(
                                command.getParams()[0],
                                Long.parseLong(command.getParams()[1]),
                                Long.parseLong(command.getParams()[2])
                        )
                );
                break;
            case Constants.REGISTER_HEAVY_HARDWARE_COMMAND:
                this.systemSplitDatabase.addHardwareComponent(
                        new HeavyHardware(
                                command.getParams()[0],
                                Long.parseLong(command.getParams()[1]),
                                Long.parseLong(command.getParams()[2])
                        )
                );
                break;
            case Constants.REGISTER_EXPRESS_SOFTWARE_COMMAND:
                hardware = findHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                hardware.addSoftwareComponent(
                        new ExpressSoftware(
                                command.getParams()[1],
                                Long.parseLong(command.getParams()[2]),
                                Long.parseLong(command.getParams()[3])
                        )
                );
                break;
            case Constants.REGISTER_LIGHT_SOFTWARE_COMMAND:
                hardware = findHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                hardware.addSoftwareComponent(
                        new LightSoftware(
                                command.getParams()[1],
                                Long.parseLong(command.getParams()[2]),
                                Long.parseLong(command.getParams()[3])
                        )
                );
                break;
            case Constants.RELEASE_SOFTWARE_COMPONENT_COMMAND:
                hardware = findHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                Software software = findSoftware(command.getParams()[1], hardware);
                if (software == null) {
                    return;
                }

                hardware.removeSoftwareComponent(software);
                break;
            case Constants.ANALYZE_COMMAND:
                executeAnalyzeCommand();
                break;
            case Constants.SYSTEM_SPLIT_COMMAND:
                this.executeSystemSplitCommend();
                this.isExitCommand = true;
                break;
            case Constants.DUMP_COMMAND:
                hardware = findHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                this.systemSplitDatabase.removeHardwareComponent(hardware);
                this.systemSplitDatabase.addDumpComponent(hardware);
                break;
            case Constants.RESTORE_COMMAND:
                hardware = findDumpHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                this.systemSplitDatabase.addHardwareComponent(hardware);
                this.systemSplitDatabase.removeDumpComponent(hardware);
                break;
            case Constants.DESTROY_COMMAND:
                hardware = findDumpHardware(command.getParams()[0]);
                if (hardware == null) {
                    return;
                }

                this.systemSplitDatabase.removeDumpComponent(hardware);
                break;
            case Constants.DUMP_ANALYZE_COMMAND:
                this.executeDumpAnalyze();
                break;
            default:
                break;
        }
    }

    private void executeAnalyzeCommand() {
        System.out.println("System Analysis");
        System.out.println("Hardware Components: " + this.systemSplitDatabase.getHardwareComponents().size());
        System.out.println("Software Components: " + this.systemSplitDatabase.getHardwareComponents().stream()
                .mapToInt(h -> h.getSoftwareComponents().size()).sum());
        System.out.printf("Total Operational Memory: %d / %d%n",
                this.systemSplitDatabase.getHardwareComponents().stream().mapToLong(Hardware::getTotalMemoryInUse).sum(),
                this.systemSplitDatabase.getHardwareComponents().stream().mapToLong(Hardware::getMaximumMemory).sum()
        );
        System.out.printf("Total Capacity Taken: %d / %d%n",
                this.systemSplitDatabase.getHardwareComponents().stream().mapToLong(Hardware::getTotalCapacityTaken).sum(),
                this.systemSplitDatabase.getHardwareComponents().stream().mapToLong(Hardware::getMaximumCapacity).sum()
        );
    }

    private void executeSystemSplitCommend() {
        for (Hardware hardware : this.systemSplitDatabase.getHardwareComponents()) {
            if (hardware instanceof HeavyHardware) {
                continue;
            }

            printHardwareInfo(hardware);
        }

        for (Hardware hardware : this.systemSplitDatabase.getHardwareComponents()) {
            if (hardware instanceof PowerHardware) {
                continue;
            }

            printHardwareInfo(hardware);
        }
    }

    private void printHardwareInfo(Hardware hardware) {
        System.out.println("Hardware Component - " + hardware.getName());
        System.out.println("Express Software Components - " + hardware.getExpressSoftwareComponentsCount());
        System.out.println("Light Software Components - " + hardware.getLightSoftwareComponentsCount());
        System.out.printf("Memory Usage: %d / %d%n", hardware.getTotalMemoryInUse(), hardware.getMaximumMemory());
        System.out.printf("Capacity Usage: %d / %d%n", hardware.getTotalCapacityTaken(), hardware.getMaximumCapacity());
        System.out.println("Type: " + ((hardware instanceof PowerHardware) ? "Power" : "Heavy"));
        System.out.println("Software Components: " + hardware.getSoftwareComponentsString());
    }

    private void executeDumpAnalyze() {
        System.out.println("Dump Analysis");
        System.out.println("Power Hardware Components: " + this.getDumpPowerHardwareComponentsCount());
        System.out.println("Heavy Hardware Components: " + this.getDumpHeavyHardwareComponentsCount());
        System.out.println("Express Software Components: " +
                this.systemSplitDatabase.getDumpComponents().stream().mapToInt(Hardware::getExpressSoftwareComponentsCount).sum());
        System.out.println("Light Software Components: " +
                this.systemSplitDatabase.getDumpComponents().stream().mapToInt(Hardware::getLightSoftwareComponentsCount).sum());
        System.out.printf("Total Dumped Memory: %d%n",
                this.systemSplitDatabase.getDumpComponents().stream().mapToLong(Hardware::getTotalMemoryInUse).sum());
        System.out.printf("Total Dumped Capacity: %d%n",
                this.systemSplitDatabase.getDumpComponents().stream().mapToLong(Hardware::getTotalCapacityTaken).sum());
    }

    private Hardware findHardware(String hardwareName) {
        Hardware hardware;
        try {
            hardware = this.systemSplitDatabase.getHardwareComponents()
                    .stream().filter(h -> h.getName().equals(hardwareName)).findFirst().get();
        } catch (NoSuchElementException e) {
            hardware = null;
        }

        return hardware;
    }

    private Software findSoftware(String softwareName, Hardware hardware) {
        Software software = null;
        try {
            software = hardware.getSoftwareComponents().stream()
                    .filter(s -> s.getName().equals(softwareName)).findFirst().get();
        } catch (NoSuchElementException e) {
            hardware = null;
        }

        return software;
    }

    private Hardware findDumpHardware(String hardwareName) {
        Hardware hardware;
        try {
            hardware = this.systemSplitDatabase.getDumpComponents()
                    .stream().filter(h -> h.getName().equals(hardwareName)).findFirst().get();
        } catch (NoSuchElementException e) {
            hardware = null;
        }

        return hardware;
    }

    public int getDumpHeavyHardwareComponentsCount() {
        int count = 0;

        for (Hardware hardware : this.systemSplitDatabase.getDumpComponents()) {
            if (hardware instanceof HeavyHardware) {
                count++;
            }
        }

        return count;
    }

    public int getDumpPowerHardwareComponentsCount() {
        int count = 0;

        for (Hardware hardware : this.systemSplitDatabase.getDumpComponents()) {
            if (hardware instanceof PowerHardware) {
                count++;
            }
        }

        return count;
    }
}
