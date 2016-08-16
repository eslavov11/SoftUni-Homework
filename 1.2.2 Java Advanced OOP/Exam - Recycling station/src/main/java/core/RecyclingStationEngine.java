package core;

import io.*;
import utility.Constants;

/**
 * Created by Edi on 07-Aug-16.
 */
public class RecyclingStationEngine implements Engine {
    private InputReader consoleReader;
    private OutputWriter consoleWriter;
    private Boolean isRunning;
    private CommandExecutor commandExecutor;
    private Command command;

    public RecyclingStationEngine() {
        this.consoleReader = new ConsoleReader();
        this.consoleWriter = new ConsoleWriter();
        this.commandExecutor = new RecyclingStationCommandExecutor();
    }

    @Override
    public void run() {
        this.isRunning = true;

        while (this.isRunning) {
            String inputLine = this.consoleReader.readLine().trim();
            this.processInput(inputLine);
        }
    }

    private void processInput(String input) {
        this.command = new RecyclingStationCommand(input);

        if(this.command.getName().equals(Constants.INPUT_TERMINATING_COMMAND)) {
            this.isRunning = false;
            return;
        }

        try {
            String commandResult = this.commandExecutor.execute(this.command);
            this.consoleWriter.writeLine(commandResult);
        } catch (Exception e) {
            this.consoleWriter.writeLine(e.getMessage());
        }
    }
}
