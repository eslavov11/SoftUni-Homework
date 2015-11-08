package shapes.spaceShapes;

public class SquarePyramid extends SpaceShape {

    private double width;

    private double height;

    public SquarePyramid(double x, double y, double z, double width, double height) {
        super(x, y, z);
        this.setWidth(width);
        this.setHeight(height);

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

    @Override
    public double getArea() {
        double sideLength = Math.sqrt(this.getHeight() * this.getHeight()
                + this.getWidth() * this.getWidth() / 4);
        return 2 * this.getWidth() * sideLength + this.getWidth()*this.getWidth();
    }

    @Override public double getVolume() {
        return this.getHeight() * this.getWidth() * this.getWidth() / 3;
    }
}
