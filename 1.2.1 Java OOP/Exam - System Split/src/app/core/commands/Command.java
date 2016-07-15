package app.core.commands;

/**
 * Created by Edi on 10-Jul-16.
 */
public class Command {
    private String name;
    private String[] params;

    public Command(String commandLine) {
        String[] commandTokens = commandLine.split("\\(");
        this.setName(commandTokens[0]);

        if (commandTokens.length > 1) {
            // removing the closing bracket ) from the command line
            commandTokens[1] = commandTokens[1].substring(0, commandTokens[1].length()-1);

            this.params = commandTokens[1].split(", ");
        }
    }

    public String[] getParams() {
        return params;
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        this.name = name;
    }
}
