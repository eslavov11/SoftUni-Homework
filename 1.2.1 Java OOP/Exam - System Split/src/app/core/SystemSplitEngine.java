package app.core;

import app.core.commands.Command;
import app.core.commands.CommandExecutor;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Scanner;

/**
 * Created by Edi on 10-Jul-16.
 */
public class SystemSplitEngine {
    private BufferedReader Console;
    private CommandExecutor commandExecutor;

    public SystemSplitEngine() {
        this.Console = new BufferedReader(
                new InputStreamReader(
                        System.in
                )
        );
        this.commandExecutor = new CommandExecutor();
    }

    public void run() throws IOException {
        String commandLine = this.Console.readLine().trim();

        while (!this.commandExecutor.isExitCommand()) {
            Command command = new Command(commandLine);

            this.commandExecutor.execute(command);

            commandLine = this.Console.readLine().trim();
        }
    }
}
