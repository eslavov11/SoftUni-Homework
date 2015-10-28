import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P08ExtractEmails {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.print("Insert text = ");
        String text = scanner.nextLine();
        Pattern pattern = Pattern.compile("[a-zA-Z0-9]+[a-zA-Z0-9\\.\\-_]*[a-zA-Z0-9]"
        		+ "+@[a-zA-Z0-9]+[a-zA-Z0-9\\.]+[a-zA-Z0-9]+");
        Matcher matcher = pattern.matcher(text);

        while (matcher.find()) {
            System.out.println(matcher.group());
        }
    }
}