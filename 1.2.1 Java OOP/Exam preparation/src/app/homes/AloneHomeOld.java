package app.homes;

import app.population.Person;

/**
 * Created by Edi on 09-Jul-16.
 */
public class AloneHomeOld extends Home {
    private static final int NUMBER_OF_ROOMS = 1;
    private static final double ELECTRICITY_COST = 15;

    public AloneHomeOld(Person person) {
        super(NUMBER_OF_ROOMS, ELECTRICITY_COST);

        super.getPeople().add(person);
    }
}
