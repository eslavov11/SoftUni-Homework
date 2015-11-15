import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P02SoftuniDefenseSystem {

    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        String input = Console.nextLine();
        Pattern pattern = Pattern.compile("([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?([0-9]+)L");
        List<String> list = new ArrayList<>();
        double totalLiters = 0;
        while(!input.equals("OK KoftiShans")) {
            Matcher match = pattern.matcher(input);
            while (match.find()) {
                String name = match.group(1);
                String type = match.group(2).toLowerCase();
                String amount = match.group(3);
                list.add(name + " brought " + amount + " liters" + " of " + type + "!");
                totalLiters+=Integer.parseInt(amount);
            }
            input = Console.nextLine();
        }
        for (String s : list) {
            System.out.println(s);
        }
        System.out.printf("%.3f softuni liters\n", (totalLiters/1000.0));
    }
}