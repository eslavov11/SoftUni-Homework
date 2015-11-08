package shapes;

import shapes.interfaces.AreaMeasurable;

public abstract class Shape implements AreaMeasurable {

    // protected - classes in the same package and subclasses in any package can use this method.
    private double x = 0;

    private double y = 0;

    public Shape(double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return x;
    }

    public void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    public void setY(double y) {
        this.y = y;
    }

    @Override public String toString() {
        String toString = String.format("%14s (%6.2f, %6.2f",
                this.getClass()
                    .getSimpleName(),
                this.getX(),
                this.getY());
        return toString;
    }
}
