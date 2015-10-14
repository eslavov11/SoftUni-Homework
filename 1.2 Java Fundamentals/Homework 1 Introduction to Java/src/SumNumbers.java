import java.util.Scanner;
public class SumNumbers {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		int sum = 0;
		int size = Integer.parseInt(input.nextLine());
		for (int i = 0; i < size; i++) {
			sum+=i+1;
		}
		System.out.println(sum);
	}
}
