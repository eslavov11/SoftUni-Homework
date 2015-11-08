package shapes.spaceShapes;

public class Cuboid extends SpaceShape {

    private double width;

    private double height;

    private double depth;

    public Cuboid(double x, double y, double z, double width, double height, double depth) {
        super(x, y, z);
        this.setWidth(width);
        this.setHeight(height);
        this.setDepth(depth);
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getDepth() {
        return depth;
    }

    public void setDepth(double depth) {
        this.depth = depth;
    }

    @Override
    public double getArea() {
        double area =
                2 * this.getWidth() * this.getHeight() +
                        2 * this.getWidth() * this.getDepth() +
                        2 * this.getHeight() * this.getDepth();
        return area;
    }

    @Override public double getVolume() {
        return this.getWidth()*this.getHeight()*this.getDepth();
    }
}
