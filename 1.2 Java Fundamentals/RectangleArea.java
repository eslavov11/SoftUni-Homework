import java.util.Scanner;
public class RectangleArea {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		String[] rectangleSizes = input.nextLine().split(" ");
		int a = Integer.parseInt(rectangleSizes[0]);
		int b = Integer.parseInt(rectangleSizes[1]);
		System.out.println("Rectangle area: " + a*b);
	}
}
