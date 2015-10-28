import java.util.Scanner;

public class P05CountAllWords {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Insert text = ");
        String[] words = scanner.nextLine().trim().split("[^a-zA-Z]+");
        System.out.println(words.length);
    }
}