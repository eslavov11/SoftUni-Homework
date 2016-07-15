package app.components.software;

import app.utility.SystemComponentFunctions;

/**
 * Created by Edi on 10-Jul-16.
 */
public class LightSoftware extends Software {
    private static final int CAPACITY_CONSUMPTION_PERCENTAGE = 50;
    private static final int MEMORY_CONSUMPTION_PERCENTAGE = 50;
    private static final String CAPACITY_CONSUMPTION_MODIFIER = "inc";
    private static final String MEMORY_CONSUMPTION_MODIFIER = "dec";

    public LightSoftware(String name, long capacityConsumption, long memoryConsumption) {
        super(name,
                SystemComponentFunctions.modifyComponentSpecification(capacityConsumption,
                        CAPACITY_CONSUMPTION_MODIFIER,
                        CAPACITY_CONSUMPTION_PERCENTAGE),
                SystemComponentFunctions.modifyComponentSpecification(memoryConsumption,
                        MEMORY_CONSUMPTION_MODIFIER,
                        MEMORY_CONSUMPTION_PERCENTAGE));
    }
}
