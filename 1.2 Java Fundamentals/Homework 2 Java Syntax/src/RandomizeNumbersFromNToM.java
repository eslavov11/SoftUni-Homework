import java.util.Scanner;
import java.util.Random;
public class RandomizeNumbersFromNToM {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		Random rnd = new Random();
		System.out.print("n = ");
		int n = Integer.parseInt(input.nextLine());
		System.out.print("m = ");
		int m = Integer.parseInt(input.nextLine());
		if (n<m) {
			int temp = m;
			m = n;
			n = temp;
		}
		int[] randomArray = new int[n-m+1];
		int count = 0;
		while (count!= randomArray.length) {
			int rndNum = randInt(m, n);
			if (!contains(randomArray,count, rndNum)) {
				randomArray[count] = rndNum;
				count++;
			}
			
		}
		for (int i = -1; i < n-m; i++) {
			System.out.print(randomArray[i+1] + " ");
		}
	}
	public static boolean contains(int[] randomArray, int count, int rndNumber){
		for (int i = 0; i < randomArray.length; i++) {
			if (randomArray[i] == rndNumber) {
				return true;
			}
		}
		return false;
	}
	
	public static int randInt(int min, int max) {
	    Random rand = new Random();
	    int randomNum = rand.nextInt((max - min) + 1) + min;
	    return randomNum;
	}
}
