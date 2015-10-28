import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;
import java.util.stream.Collectors;

public class P13FilterArray {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        ArrayList<String> listStr = new ArrayList<String>(Arrays.asList(scanner.nextLine().split("\\s+")));
        ArrayList<String> filteredList = new ArrayList<String>(listStr.stream().filter(p -> p.length() > 3).collect(Collectors.toList()));
        if(filteredList.size()!=0){
            for(String s : filteredList){
                System.out.print(s + " ");
            }
        }else{
            System.out.println("(empty)");
        }


    }
}