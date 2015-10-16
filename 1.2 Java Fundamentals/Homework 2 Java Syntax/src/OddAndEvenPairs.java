import java.util.Scanner;
public class OddAndEvenPairs {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] text = input.nextLine().split(" ");
		
		int[] numbers = new int[text.length];
		for (int i = 0; i < numbers.length; i++) {
			numbers[i] = Integer.parseInt(text[i]);
		}
		if (numbers.length % 2 != 0) {
			System.out.println("Invalid length");
			return;
		}
		for (int i = 0; i < numbers.length; i+=2) {
			System.out.print(numbers[i] + ", " + numbers[i+1] + " ->");
			if (numbers[i] % 2 == 0 && numbers[i+1] % 2 ==0) {
				System.out.println("both are even");
			} else if (numbers[i] % 2 != 0 && numbers[i+1] % 2 != 0) {
				System.out.println("both are odd");
			} else {
				System.out.println("different");
			}
		}
	}
}

