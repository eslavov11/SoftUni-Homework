package app.components.hardware;

import app.components.SystemComponent;
import app.components.software.ExpressSoftware;
import app.components.software.LightSoftware;
import app.components.software.Software;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Edi on 10-Jul-16.
 */
public abstract class Hardware extends SystemComponent {
    private long maximumCapacity;
    private long maximumMemory;
    private List<Software> softwareComponents;

    protected Hardware(String name, long maximumCapacity, long maximumMemory) {
        super(name);
        this.setMaximumCapacity(maximumCapacity);
        this.setMaximumMemory(maximumMemory);
        this.softwareComponents = new ArrayList<>();
    }

    public long getMaximumCapacity() {
        return maximumCapacity;
    }

    private void setMaximumCapacity(long maximumCapacity) {
        this.maximumCapacity = maximumCapacity;
    }

    public long getMaximumMemory() {
        return maximumMemory;
    }

    private void setMaximumMemory(long maximumMemory) {
        this.maximumMemory = maximumMemory;
    }

    public List<Software> getSoftwareComponents() {
        return this.softwareComponents;
    }

    public void addSoftwareComponent(Software software) {
        if (this.getTotalCapacityTaken() + software.getCapacityConsumption() > this.getMaximumCapacity() ||
            this.getTotalMemoryInUse() + software.getMemoryConsumption() > this.getMaximumMemory()) {
            return;
        }

        this.softwareComponents.add(software);
    }

    public void removeSoftwareComponent(Software software) {
        this.softwareComponents.remove(software);
    }

    public long getTotalMemoryInUse() {
        return this.softwareComponents.stream().mapToLong(Software::getMemoryConsumption).sum();
    }

    public long getTotalCapacityTaken() {
        return this.softwareComponents.stream().mapToLong(Software::getCapacityConsumption).sum();
    }

    public int getExpressSoftwareComponentsCount() {
        int count = 0;

        for (Software softwareComponent : this.softwareComponents) {
            if (softwareComponent instanceof ExpressSoftware) {
                count++;
            }
        }

        return count;
    }

    public int getLightSoftwareComponentsCount() {
        int count = 0;

        for (Software softwareComponent : this.softwareComponents) {
            if (softwareComponent instanceof LightSoftware) {
                count++;
            }
        }

        return count;
    }

    public String getSoftwareComponentsString() {
        if (this.softwareComponents.size() == 0) {
            return "None";
        }

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < this.softwareComponents.size() - 1; i++) {
            result.append(this.softwareComponents.get(i) + ", ");
        }

        result.append(this.softwareComponents.get(this.softwareComponents.size()-1));

        return result.toString();
    }
}
