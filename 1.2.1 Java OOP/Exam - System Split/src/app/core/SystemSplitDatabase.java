package app.core;

import app.components.hardware.Hardware;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Edi on 10-Jul-16.
 */
public class SystemSplitDatabase {
    private List<Hardware> hardwareComponents;
    private List<Hardware> dumpComponents;

    public SystemSplitDatabase() {
        this.setHardwareComponents(new ArrayList<>());
        this.setDumpComponents(new ArrayList<>());
    }

    public List<Hardware> getHardwareComponents() {
        return hardwareComponents;
    }

    private void setHardwareComponents(List<Hardware> hardwareComponents) {
        this.hardwareComponents = hardwareComponents;
    }

    public void addHardwareComponent(Hardware hardware) {
        this.hardwareComponents.add(hardware);
    }

    public void removeHardwareComponent(Hardware hardware) {
        this.hardwareComponents.remove(hardware);
    }

    public List<Hardware> getDumpComponents() {
        return dumpComponents;
    }

    private void setDumpComponents(List<Hardware> dumpComponents) {
        this.dumpComponents = dumpComponents;
    }

    public void addDumpComponent(Hardware hardware) {
        this.dumpComponents.add(hardware);
    }

    public void removeDumpComponent(Hardware hardware) {
        this.dumpComponents.remove(hardware);
    }
}
