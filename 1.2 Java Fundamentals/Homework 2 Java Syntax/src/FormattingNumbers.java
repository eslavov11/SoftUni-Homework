import java.util.Scanner;
import java.lang.String;
public class FormattingNumbers {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		String[] numbers = input.nextLine().split(" ");
		int a = Integer.parseInt(numbers[0]);
		double b = Double.parseDouble(numbers[1]);
		double c = Double.parseDouble(numbers[2]);
		System.out.print("|");
		System.out.print(
				padRight(Integer.toHexString(a).toUpperCase(), 10) + "|");
		String formatted = String.format("%010d", Integer.parseInt(Integer.toBinaryString(a)));
				System.out.print(formatted + "|");
		System.out.printf("      %.2f",Double.parseDouble(padLeft(Double.toString(b),10)));
		System.out.print("|");
		System.out.printf("%.3f     ",Double.parseDouble(padRight(Double.toString(c),10)));
		System.out.print("|");
	}
	public static String padRight(String s, int n) {
	     return String.format("%1$-" + n + "s", s);  
	}

	public static String padLeft(String s, int n) {
	    return String.format("%1$" + n + "s", s);  
	}
}
