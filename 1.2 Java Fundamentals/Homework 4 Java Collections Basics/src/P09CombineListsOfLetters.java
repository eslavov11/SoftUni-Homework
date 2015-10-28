import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class P09CombineListsOfLetters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ArrayList<Character> firstList = new ArrayList(Arrays.asList(scanner.nextLine().split("\\s+")));
        ArrayList<Character> secondList = new ArrayList(Arrays.asList(scanner.nextLine().split("\\s+")));
        for (int i = 0; i < secondList.size(); i++) {
            if(!firstList.contains(secondList.get(i))){
                firstList.add(secondList.get(i));
            }
        }
        for (int i = 0; i < firstList.size(); i++) {
            System.out.print(firstList.get(i) + " ");
        }

    }
}