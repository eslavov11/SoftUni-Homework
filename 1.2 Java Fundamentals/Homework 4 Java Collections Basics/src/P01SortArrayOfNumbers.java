import java.util.*;
public class P01SortArrayOfNumbers {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int length = input.nextInt();
		String[] arr = input.nextLine().split(" ");
		int[] numbers = new int[length];
		for (int j = 0; j < arr.length; j++) {
			numbers[j] = Integer.parseInt(arr[j]);
		}
		Arrays.sort(numbers);
		for (int i = 0; i < numbers.length; i++) {
			System.out.print(numbers[i] + " ");
		}
	}
}
