import java.util.*;
import java.util.Map;
import java.util.Map.Entry;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P04LogParser {
    private static boolean ASC = true;
    private static boolean DESC = false;

    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        String input = Console.nextLine();
        Pattern pat = Pattern.compile("\\{\".+\": \\[\"(.+)\"\\], \"Type\": \\[\"(.+)\"\\], \"Message\": \\[\"(.+)\"\\]\\}");
        TreeMap<String, TreeMap<String, ArrayList<String>>> projects = new TreeMap<String, TreeMap<String, ArrayList<String>>>();
        while (!input.equals("END")) {
            Matcher match = pat.matcher(input);
            List<String> tok = new ArrayList<>();
            String project = "", type = "", message = "";
            if(match.find()) {
                 project = match.group(1);
                 type = match.group(2).toLowerCase();
                 type = (type.charAt(0) + "").toUpperCase() + type.substring(1,type.length());
                 message = match.group(3);
            }
            if (!projects.containsKey(project)) {
                projects.put(project, new TreeMap<String, ArrayList<String>>());
                projects.get(project).put("Critical", new ArrayList<String>());
                projects.get(project).get("Critical").add("None");
                projects.get(project).put("Warning", new ArrayList<String>());
                projects.get(project).get("Warning").add("None");
            }
            if(!projects.get(project).containsKey(type))
            {
                projects.get(project).put(type, new ArrayList<String>());
                projects.get(project).get(type).add("None");
            }
            projects.get(project).get(type).add(message);
            input = Console.nextLine();
        }

        TreeMap<String, Integer> sortMe = new TreeMap<String, Integer>();
        int size = 0;
        for (Map.Entry<String, TreeMap<String, ArrayList<String>>> types : projects.entrySet()) {
            String write = types.getKey() + ":\n";
            int critical = 0;
            int warnings = 0;
            for (Map.Entry<String, ArrayList<String>> messages : types.getValue().entrySet()) {
                ArrayList<String> list = messages.getValue();
                list.sort(Comparator.comparing(String::length));
                for (String s : list) {
                    if (messages.getKey().equals("Critical")) {
                        critical++;
                    } else {
                        warnings++;
                    }
                }
            }
            write+= ("Total Errors: " + (critical + warnings - 2) + "\n");
            write+= "Critical: " + (critical - 1) + "\n";
            write+= "Warnings: " + (warnings - 1) + "\n";

            for (Map.Entry<String, ArrayList<String>> messages : types.getValue().entrySet()) {
                write += (messages.getKey() + " Messages:\n");
                ArrayList<String> list = messages.getValue();
                list.sort(String::compareTo);
                list.sort(Comparator.comparing(String::length));
                for (String s : list) {
                    if (messages.getKey().equals("Critical")) {
                        critical++;
                    } else {
                        warnings++;
                    }
                    if (messages.getValue().size() == 1) {
                        write += "--->None\n";
                        break;
                    } else if (!s.equals("None")) {
                        write += "--->" + s + "\n";
                    }
                }
            }
            sortMe.put(write, critical+warnings-2);
        }
        Map<String, Integer> sortedMapDesc = sortByComparator(sortMe, DESC);
        for (Entry<String, Integer> entry : sortedMapDesc.entrySet())
        {
                System.out.println(entry.getKey());
        }

    }
    private static Map<String, Integer> sortByComparator(Map<String, Integer> unsortMap, final boolean order) {
        List<Entry<String, Integer>> list = new LinkedList<Entry<String, Integer>>(unsortMap.entrySet());
        Collections.sort(list, new Comparator<Entry<String, Integer>>() {
            public int compare(Entry<String, Integer> o1,
                               Entry<String, Integer> o2) {
                if (order) {
                    return o1.getValue().compareTo(o2.getValue());
                } else {
                    return o2.getValue().compareTo(o1.getValue());
                }
            }
        });
        Map<String, Integer> sortedMap = new LinkedHashMap<String, Integer>();
        for (Entry<String, Integer> entry : list) {
            sortedMap.put(entry.getKey(), entry.getValue());
        }

        return sortedMap;
    }
}