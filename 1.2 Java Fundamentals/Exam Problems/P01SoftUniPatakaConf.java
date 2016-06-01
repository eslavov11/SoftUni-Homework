import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P01SoftUniPatakaConf {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        int people = Integer.parseInt(Console.nextLine());
        int n = Integer.parseInt(Console.nextLine());
        int totalBeds = 0, foodAmount = 0;
        for (int i = 0; i < n; i++) {
            String[] input = Console.nextLine().split("\\s+");
            int amount = Integer.parseInt(input[1]);
            String type = input[2];
            if (input[0].equals("tents")) {
                if (type.equals("firstClass")) {
                    totalBeds += amount*3;
                } else {
                    totalBeds += amount*2;
                }
            } else if (input[0].equals("rooms")) {
                if (type.equals("single")) {
                    totalBeds += amount;
                } else if (type.equals("double")) {
                    totalBeds += amount*2;
                } else {
                    totalBeds += amount*3;
                }
            } else if (input[0].equals("food")) {
                if (type.equals("musaka")) {
                    foodAmount += 2*amount;
                }
            }
        }
		
        if (totalBeds>=people) {
            System.out.println("Everyone is happy and sleeping well. Beds left: " + (totalBeds - people));
        } else {
            System.out.println("Some people are freezing cold. Beds needed: " + (people - totalBeds));
        }

        if (foodAmount>=people) {
            System.out.println("Nobody left hungry. Meals left: " + (foodAmount - people));
        } else {
            System.out.println("People are starving. Meals needed: " + (people - foodAmount));
        }
        }
}
