package app;

import app.homes.Home;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Created by Edi on 10-Jul-16.
 */
public class City {
    private List<Home> homes;

    public City() {
        this.homes = new ArrayList<>();
    }

    public void addHome(Home home) {
        this.homes.add(home);
    }

    public void removeHome(Home home) {
        this.homes.remove(home);
    }

    public int getPopulation() {
        return this.homes.stream().mapToInt(Home::getPopulationCount).sum();
    }

    public double getConsumption() {
        throw new NotImplementedException();
    }

    public void payBills() {
        Iterator<Home> iterator = this.homes.iterator();

        while (iterator.hasNext()) {
            Home home = iterator.next();
            if (!home.payBills()) {
                iterator.remove();
            }
        }
    }

    public void receiveSalaries() {
        this.homes.forEach(Home::receiveSalary);
    }
}
