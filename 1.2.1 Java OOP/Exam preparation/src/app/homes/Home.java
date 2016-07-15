package app.homes;

import app.Room;
import app.items.Device;
import app.population.Person;

import java.util.List;

/**
 * Created by Edi on 09-Jul-16.
 */
public abstract class Home {
    private double salaries;
    private double bills;
    private double budget;

    private List<Person> people;
    private List<Room> rooms;
    private List<Device> devices;

    protected Home(int numberOfRooms, double electricityCost) {
        this.addRooms(numberOfRooms, electricityCost);
        this.salaries = 0;
        this.bills = 0;
        this.budget = 0;

        this.calculateBills();
        this.calculateSalaries();
    }

    public double getBills() {
        return bills;
    }

    public void setBills(double bills) {
        this.bills = bills;
    }

    public List<Person> getPeople() {
        return people;
    }

    public void setPeople(List<Person> people) {
        this.people = people;
    }

    protected List<Room> getRooms() {
        return rooms;
    }

    protected void setRooms(List<Room> rooms) {
        this.rooms = rooms;
    }

    protected void addRooms(int numberOfRooms, double electricityCost) {
        for (int index = 0; index < numberOfRooms; index++) {
            this.getRooms().add(new Room(electricityCost));
        }
    }

    public List<Device> getDevices() {
        return devices;
    }

    public void setDevices(List<Device> devices) {
        this.devices = devices;
    }

    public int getPopulationCount() {
        return this.getPeople().size();
    }

    public void calculateBills() {
        this.setBills(this.getRooms().stream().mapToDouble(Room::getElectricityCost).sum()
                + this.getDevices().stream().mapToDouble(Device::getElectricityCost).sum());
    }

    public boolean payBills() {
        if (this.budget >= this.bills) {
            this.budget -= this.bills;
            return true;
        }

        return false;
    }

    void calculateSalaries() {
        this.salaries = this.people.stream()
                .mapToDouble(Person::getIncome)
                .sum();
    }

    public void receiveSalary() {
        this.budget += this.salaries;
    }
}
