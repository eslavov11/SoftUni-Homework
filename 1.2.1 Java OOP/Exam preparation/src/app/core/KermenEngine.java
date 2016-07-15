package app.core;

import java.util.Scanner;

/**
 * Created by Edi on 09-Jul-16.
 */
public class KermenEngine {
    private int commandsCount;
    private Scanner Console;
    private CommandExecutor commandExecutor;

    public KermenEngine() {
        this.Console = new Scanner(System.in);
        this.commandExecutor = new CommandExecutor();
        this.commandsCount = 0;
    }

    public void run() {
        String commandLine = this.Console.nextLine();

        while (!this.commandExecutor.isExitCommand()) {
            this.commandsCount++;
            Command command = new Command(commandLine);

            this.commandExecutor.execute(command);

            commandLine = this.Console.nextLine();
        }
    }
}
