import java.util.*;
public class P02SequencesOfEqualStrings {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		ArrayList<Character> uniqueCharacters = new ArrayList<Character>();
		String[] text1 = input.nextLine().split(" ");
		for (int i = 0; i < text1.length; i++) {
			uniqueCharacters.add(text1[i].charAt(0));
		}
		
		String[] text2 = input.nextLine().split(" ");
		for (int i = 0; i < text2.length; i++) {
			if (!uniqueCharacters.contains(text2[i].charAt(i))) {
				uniqueCharacters.add(text1[i].charAt(0));
			}
		}
		for (Iterator iterator = uniqueCharacters.iterator(); iterator.hasNext();) {
			System.out.print(iterator + " ");
		}
	}
}
