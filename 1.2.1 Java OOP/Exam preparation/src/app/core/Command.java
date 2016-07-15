package app.core;

/**
 * Created by Edi on 10-Jul-16.
 */
public class Command {
    private String name;
    private String[] params;

    public Command(String commmandLine) {
        this.setName(commmandLine);
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String[] getParams() {
        return params;
    }

    public void setParams(String[] params) {
        this.params = params;
    }
}
