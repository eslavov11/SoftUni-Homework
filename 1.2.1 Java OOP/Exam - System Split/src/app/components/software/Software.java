package app.components.software;

import app.components.SystemComponent;

/**
 * Created by Edi on 10-Jul-16.
 */
public abstract class Software extends SystemComponent{
    private long capacityConsumption;
    private long memoryConsumption;

    protected Software(String name, long maximumCapacity, long maximumMemory) {
        super(name);
        this.setCapacityConsumption(maximumCapacity);
        this.setMemoryConsumption(maximumMemory);
    }

    public long getCapacityConsumption() {
        return capacityConsumption;
    }

    private void setCapacityConsumption(long maximumCapacity) {
        this.capacityConsumption = maximumCapacity;
    }

    public long getMemoryConsumption() {
        return memoryConsumption;
    }

    private void setMemoryConsumption(long maximumMemory) {
        this.memoryConsumption = maximumMemory;
    }
}
