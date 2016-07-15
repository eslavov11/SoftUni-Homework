package app.homes;

import app.Room;
import app.items.Device;
import app.population.Child;
import app.population.Person;

import java.util.List;

/**
 * Created by Edi on 09-Jul-16.
 */
public class YoungCoupleWithChildrenHome extends Home {
    private static final int NUMBER_OF_ROOMS = 2;
    private static final double ELECTRICITY_COST = 30;

    private List<Child> children;

    public YoungCoupleWithChildrenHome(Person male, Person female, Device tv, Device fridge, Device laptop, List<Child> children) {
        super(NUMBER_OF_ROOMS, ELECTRICITY_COST);

        super.getPeople().add(male);
        super.getPeople().add(female);

        super.getDevices().add(tv);
        super.getDevices().add(fridge);
        super.getDevices().add(laptop);

        this.setChildren(children);
    }

    public List<Child> getChildren() {
        return children;
    }

    public void setChildren(List<Child> children) {
        this.children = children;
    }

    @Override
    public void calculateBills() {
        this.setBills(this.getRooms().stream().mapToDouble(Room::getElectricityCost).sum()
                + this.getDevices().stream().mapToDouble(Device::getElectricityCost).sum()
                + this.getChildren().stream().mapToDouble(Child::getTotalCost).sum());
    }

    @Override
    public int getPopulationCount() {
        return super.getPopulationCount() + this.getChildren().size();
    }
}
