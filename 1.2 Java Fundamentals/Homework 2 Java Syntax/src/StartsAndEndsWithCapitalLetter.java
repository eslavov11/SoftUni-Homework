import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
public class StartsAndEndsWithCapitalLetter {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		String text = input.nextLine();
		Pattern wordRegex = Pattern.compile("(?<!\\S)[A-Z][A-Za-z]*[A-Z](?![a-z])");
		Matcher matcher = wordRegex.matcher(text);
		while (matcher.find()) {
			System.out.print(matcher.group() + " ");
		}
		System.out.println();
	}
}
