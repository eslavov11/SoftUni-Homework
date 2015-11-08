package shapes;

import shapes.interfaces.AreaMeasurable;
import shapes.interfaces.PerimeterMeasurable;
import shapes.interfaces.VolumeMeasurable;
import shapes.planeShapes.Circle;
import shapes.planeShapes.Rectangle;
import shapes.planeShapes.Triangle;
import shapes.spaceShapes.Cuboid;
import shapes.spaceShapes.Sphere;
import shapes.spaceShapes.SquarePyramid;

public class ShapesExamples {

    public static void main(String[] args) throws Exception {
        //masiv ot interfaci Moveable
        PerimeterMeasurable[] planeShapes = new PerimeterMeasurable[]{
                new Circle(5, 8, 12),
                new Triangle(1, 2, 3, 4, 11, 6),
                new Rectangle(3, 7, 10, 5),
                new Circle(120, 75, 17.5),
        };
        for (PerimeterMeasurable shape : planeShapes) {
            System.out.println(shape);
        }
        System.out.println();
        VolumeMeasurable[] spaceShapes = new VolumeMeasurable[]{
                new Sphere(1, 2, 3, 6),
                new Cuboid(4, 5, 6, 1, 2, 3),
                new SquarePyramid(5, 6, 7, 3, 4)
        };
        for (VolumeMeasurable shape : spaceShapes) {
            System.out.println(shape);
        }
        System.out.println();
        AreaMeasurable[] shapes = new AreaMeasurable[]{
                new Circle(5, 8, 12),
                new Rectangle(3, 7, 10, 5),
                new Rectangle(-1.5, 0, 2, 6),
                new Circle(0, 0, 2.5),
                new Cuboid(2.5, 3.2, 1.85, 1, 2, 3),
                new Sphere(1, 2, 3, 6),
                new Cuboid(4, 5, 6, 1, 2, 3),
                new SquarePyramid(5, 6, 7, 3, 4),
                new Triangle(1, 2, 3, 4, 11, 6),
                new Rectangle(3, 7, 10, 5),
                new Circle(120, 75, 17.5),
        };
        for (AreaMeasurable shape : shapes) {
            System.out.println(shape);
        }
        System.out.println();
    }
}
