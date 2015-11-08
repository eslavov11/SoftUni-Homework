package shapes.planeShapes;

public class Triangle extends PlaneShape {

    private double x2 = 0;

    private double y2 = 0;

    private double x3 = 0;

    private double y3 = 0;

    public Triangle(double x, double y, double x2, double y2, double x3, double y3) {
        super(x, y);
        this.setX2(x2);
        this.setY2(y2);
        this.setX3(x3);
        this.setY3(y3);
    }

    public double getX2() {
        return x2;
    }

    public void setX2(double x2) {
        this.x2 = x2;
    }

    public double getX3() {
        return x3;
    }

    public void setX3(double x3) {
        this.x3 = x3;
    }

    public double getY2() {
        return y2;
    }

    public void setY2(double y2) {
        this.y2 = y2;
    }

    public double getY3() {
        return y3;
    }

    public void setY3(double y3) {
        this.y3 = y3;
    }

    @Override public double getArea( ) {
        double area = 0;
        area += this.getX() * (this.getY2() - this.getY3());
        area += this.getX2() * (this.getY3() - this.getY());
        area += this.getX3() * (this.getY() - this.getY2());
        area /= 2.0;
        area = Math.abs(area);
        if (area == 0) {
            System.out.println("These three points do not form a triangle; they are collinear.");
            return 0;
        }
        return area;
    }

    @Override public double getPerimeter() {
        double firstSide= getSideLength(this.getX(), this.getY(), this.getX2(), this.getY2());
        double secondSide=getSideLength(this.getX2(), this.getY2(), this.getX3(), this.getY3());
        double thirdSide=getSideLength(this.getX3(), this.getY3(), this.getX(), this.getY());
        return firstSide+secondSide+thirdSide;
    }

    private double getSideLength(double x1, double y1, double x2, double y2) {
        return Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
}
