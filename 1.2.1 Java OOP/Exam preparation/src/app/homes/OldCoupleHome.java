package app.homes;

import app.items.Device;
import app.population.Person;

/**
 * Created by Edi on 09-Jul-16.
 */
public class OldCoupleHome extends Home {
    private static final int NUMBER_OF_ROOMS = 3;
    private static final double ELECTRICITY_COST = 15;

    public OldCoupleHome(Person male, Person female, Device tv, Device fridge, Device stove) {
        super(NUMBER_OF_ROOMS, ELECTRICITY_COST);

        super.getPeople().add(male);
        super.getPeople().add(female);

        super.getDevices().add(tv);
        super.getDevices().add(fridge);
        super.getDevices().add(stove);
    }
}
