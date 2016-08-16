package core;

import utility.Constants;

/**
 * Created by Edi on 07-Aug-16.
 */
public class RecyclingStationCommand implements Command {
    private String name;
    private String[] arguments;

    public RecyclingStationCommand(String commandLine) {
        this.parseCommand(commandLine);
    }

    private void parseCommand(String commandLine) {
        String[] splatArguments = commandLine.split(Constants.INPUT_SPLIT_DELIMITER);

        this.setName(splatArguments[0]);

        if (splatArguments.length > 1) {
            this.setArguments(splatArguments[1].split(Constants.INPUT_COMMAND_ARGUMENTS_SPLIT_DELIMITER));
        }
    }

    @Override
    public String getName() {
        return this.name;
    }

    private void setName(String name) {
        this.name = name;
    }

    @Override
    public String[] getArguments() {
        return this.arguments;
    }

    private void setArguments(String[] args) {
        this.arguments = args;
    }
}
