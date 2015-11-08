package shapes.spaceShapes;

public class Sphere extends SpaceShape {

    private double radius;

    public Sphere(double x, double y, double z, double radius) {
        super(x, y, z);
        this.setRadius(radius);
    }

    public double getRadius() {
        return radius;
    }

    public void setRadius(double radius) {
        this.radius = radius;
    }

    @Override public double getArea() {
        double area = 4 * Math.PI * Math.pow(this.getRadius(), 2);
        return area;
    }

    @Override public double getVolume() {
        double sphereVolume = (4 * Math.PI * Math.pow(this.getRadius(), 3)) / 3;
        return sphereVolume;
    }
}
