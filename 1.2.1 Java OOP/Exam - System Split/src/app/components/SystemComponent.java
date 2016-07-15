package app.components;

/**
 * Created by Edi on 10-Jul-16.
 */
public abstract class SystemComponent {
    private String name;

    protected SystemComponent(String name) {
        this.setName(name);
    }

    public String getName() {
        return name;
    }

    private void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return this.getName();
    }
}
