import java.util.Scanner;
public class ConvertFromDecimalToBaseSeven {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		System.out.println(Integer.toString(Integer.parseInt(input.nextLine(), 10), 2));
	}
}
