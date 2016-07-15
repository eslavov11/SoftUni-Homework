package app.core;

import app.City;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

/**
 * Created by Edi on 10-Jul-16.
 */
public class CommandExecutor {
    private boolean isExitCommand;
    private City kermen;

    public CommandExecutor() {
        this.isExitCommand = false;
        this.kermen = new City();
    }

    public void execute(Command command) {
        switch (command.getName()) {
            case "EVN":
                System.out.println("Total consumption: " + kermen.getConsumption());
            break;

            case "Democracy":
                System.out.printf("Total population: %d%n", this.kermen.getPopulation());
                this.isExitCommand = true;
            break;


            default:
            break;
        }




        throw new NotImplementedException();


    }

    public boolean isExitCommand() {
        return this.isExitCommand;
    }

}
