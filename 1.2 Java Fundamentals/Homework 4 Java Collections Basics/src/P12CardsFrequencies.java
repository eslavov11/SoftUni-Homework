import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P12CardsFrequencies {
    public static void main(String[] args) {
        LinkedHashMap<String,Integer> strings = new LinkedHashMap<>();
        Scanner scanner = new Scanner(System.in);
        String inputText = scanner.nextLine();
        Pattern pattern = Pattern.compile("(\\w+)");
        Matcher wordExtractor = pattern.matcher(inputText);
        Double matchCounter = 0.00;
        while(wordExtractor.find()) {
            matchCounter++;
            if(strings.containsKey(wordExtractor.group(1))){
                strings.put(wordExtractor.group(1),strings.get(wordExtractor.group(1))+1);
            }else{
                strings.put(wordExtractor.group(1),1);
            }
        }
        Integer maxLength = strings.values().stream().max(Integer::compare).get();

        for(String key : strings.keySet()){

                System.out.printf("%s -> %.2f%%%n",key,(strings.get(key)/matchCounter)*100.00);

        }
    }
}