import java.util.Scanner;
public class CharacterMultiplier {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String[] text = input.nextLine().split(" ");
		String wordOne = text[0];
		String wordTwo = text[1];
		multiplyChars(wordOne, wordTwo);
	}
	
	public static void multiplyChars(String wordOne, String wordTwo){
		int smallestLength = Integer.min(wordOne.length(), wordTwo.length());
		long sum = 0;
		for (int i = 0; i < smallestLength; i++) {
			sum += wordOne.charAt(i) * wordTwo.charAt(i);
		}
		if (smallestLength == wordOne.length()) {
			for (int i = smallestLength; i < wordTwo.length(); i++) {
				sum += wordTwo.charAt(i);
			}
		} else {
			for (int i = smallestLength; i < wordTwo.length(); i++) {
				sum += wordOne.charAt(i);
			}
		}
		System.out.println(sum);
	}
} 
