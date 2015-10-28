import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class P10ExtractAllUniqueWords {

        public static void main(String[] args) {
            Scanner scanner = new Scanner(System.in);
            Pattern wordPattern =  Pattern.compile("\\b\\w+\\b");
            String textInput = scanner.nextLine();
            Matcher wordMatcher = wordPattern.matcher(textInput);
            HashSet<String> uniqueWords = new HashSet<String>();

            while(wordMatcher.find()){
                uniqueWords.add(wordMatcher.group().toLowerCase());
            }
            ArrayList<String> uniqueList = new ArrayList<>(uniqueWords);
            Collections.sort(uniqueList,String.CASE_INSENSITIVE_ORDER);
            uniqueList.forEach(s -> System.out.print(s + " "));


        }
    }