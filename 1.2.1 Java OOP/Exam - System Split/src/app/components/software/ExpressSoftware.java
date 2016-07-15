package app.components.software;

import app.utility.SystemComponentFunctions;

/**
 * Created by Edi on 10-Jul-16.
 */
public class ExpressSoftware extends Software {
    private static final int MEMORY_CONSUMPTION_PERCENTAGE = 100;
    private static final String MEMORY_CONSUMPTION_MODIFIER = "inc";

    public ExpressSoftware(String name, long capacityConsumption, long memoryConsumption) {
        super(name,
                capacityConsumption,
                SystemComponentFunctions.modifyComponentSpecification(memoryConsumption,
                        MEMORY_CONSUMPTION_MODIFIER,
                        MEMORY_CONSUMPTION_PERCENTAGE));
    }
}
