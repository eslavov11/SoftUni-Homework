import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class P14SortArrayWithStreamAPI {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<String> nums = new ArrayList<>();

        System.out.print("Insert few integers on a single line separated by space = ");
        nums.addAll(Arrays.asList(scanner.nextLine().split(" ")));
        System.out.println("Insert ordering type in format (\"Ascending/Descending\") = ");
        String sortType = scanner.nextLine();

        if(sortType.equals("Ascending")) {
            nums.stream()
                    .map(s -> Integer.parseInt(s))
                    .sorted((num1, num2) -> num1.compareTo(num2))
                    .forEach(num -> System.out.print(num + " "));
        } else {
            nums.stream()
                    .map(s -> Integer.parseInt(s))
                    .sorted((num1, num2) -> num2.compareTo(num1))
                    .forEach(num -> System.out.print(num + " "));
        }
    }
}