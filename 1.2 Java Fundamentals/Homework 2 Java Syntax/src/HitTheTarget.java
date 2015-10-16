import java.util.Scanner;
public class HitTheTarget {
	
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int number = input.nextInt();
		for (int i = 1; i <= 20; i++) {
			for (int j = 1; j <= 20; j++) {
				if (i+j == number) {
					System.out.println(i + " + " + j + " = " + number);
				}
			}
		}
		for (int i = 1; i <= 20; i++) {
			for (int j = 1; j <= 20; j++) {
				if (i-j == number) {
					System.out.println(i + " - " + j + " = " + number);
				}
			}
		}
	}
}
