package app.components.hardware;

import app.utility.SystemComponentFunctions;

/**
 * Created by Edi on 10-Jul-16.
 */
public class PowerHardware extends Hardware {
    private static final int MAX_CAPACITY_PERCENTAGE = 75;
    private static final int MAX_MEMORY_PERCENTAGE = 75;
    private static final String MAX_CAPACITY_MODIFIER = "dec";
    private static final String MAX_MEMORY_MODIFIER = "inc";

    public PowerHardware(String name, long maximumCapacity, long maximumMemory) {
        super(name,
                SystemComponentFunctions.modifyComponentSpecification(maximumCapacity,
                        MAX_CAPACITY_MODIFIER,
                        MAX_CAPACITY_PERCENTAGE),
                SystemComponentFunctions.modifyComponentSpecification(maximumMemory,
                        MAX_MEMORY_MODIFIER,
                        MAX_MEMORY_PERCENTAGE));
    }
}
