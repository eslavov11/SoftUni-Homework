import java.util.Scanner;
import java.util.regex.*;
public class ExtractWords {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern wordRegex = Pattern.compile("[A-Za-z]{2,}");
		Matcher matcher = wordRegex.matcher(text);
		while (matcher.find()) {
			System.out.print(matcher.group() + " ");
		}
		System.out.println();
	}
}
