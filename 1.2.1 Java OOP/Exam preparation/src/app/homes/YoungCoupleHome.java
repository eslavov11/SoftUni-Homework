package app.homes;

import app.items.Device;
import app.population.Person;

import java.util.List;

/**
 * Created by Edi on 09-Jul-16.
 */
public class YoungCoupleHome extends Home {
    private static final int NUMBER_OF_ROOMS = 2;
    private static final double ELECTRICITY_COST = 20;

    public YoungCoupleHome(Person male, Person female, Device tv, Device fridge, Device laptop) {
        super(NUMBER_OF_ROOMS, ELECTRICITY_COST);

        super.getPeople().add(male);
        super.getPeople().add(female);

        super.getDevices().add(tv);
        super.getDevices().add(fridge);
        super.getDevices().add(laptop);
    }
}
