package shapes.planeShapes;

public class Circle extends PlaneShape {

    private double radius;

    public Circle(double x, double y, double radius) {
        super(x, y);
        this.setRadius(radius);
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override
    public double getArea() {
        return Math.PI * this.radius * this.getRadius();
    }

    @Override public double getPerimeter() {
        return 2 * Math.PI * this.getRadius();
    }
}
