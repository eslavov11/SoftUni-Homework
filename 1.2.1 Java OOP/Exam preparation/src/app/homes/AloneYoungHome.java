package app.homes;

import app.items.Device;
import app.population.Person;

/**
 * Created by Edi on 09-Jul-16.
 */
public class AloneYoungHome extends Home {
    private static final int NUMBER_OF_ROOMS = 1;
    private static final double ELECTRICITY_COST = 10;

    public AloneYoungHome(Person person, Device laptop) {
        super(NUMBER_OF_ROOMS, ELECTRICITY_COST);

        super.getPeople().add(person);
        super.getDevices().add(laptop);
    }
}
