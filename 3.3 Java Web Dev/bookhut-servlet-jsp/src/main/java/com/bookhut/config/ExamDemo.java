package com.bookhut.config;

//import java.util.*;
//
///**
// * Created by Edi on 18-Mar-17.
// */
//public class ExamDemo {
//
//    public static void main(String[] args) {
//        Scanner Console = new Scanner(System.in);
//
//        while (true) {
//            String gunnarLine = Console.nextLine();
//            if (gunnarLine == null || "".equals(gunnarLine)) {
//                break;
//            }
//
//            String emmaLine = Console.nextLine();
//
//            String[] gArr = gunnarLine.split(" ");
//            String[] eArr = emmaLine.split(" ");
//
//            int gd1a = Integer.parseInt(gArr[0]);
//            int gd1b = Integer.parseInt(gArr[1]);
//            int gd2a = Integer.parseInt(gArr[2]);
//            int gd2b = Integer.parseInt(gArr[3]);
//            int gSum = gd1a + gd1b + gd2a + gd2b;
//
//            int ed1a = Integer.parseInt(eArr[0]);
//            int ed1b = Integer.parseInt(eArr[1]);
//            int ed2a = Integer.parseInt(eArr[2]);
//            int ed2b = Integer.parseInt(eArr[3]);
//            int eSum = ed1a + ed1b + ed2a + ed2b;
//
//            if (gSum == eSum) {
//                System.out.println("Tie");
//            } else if (gSum > eSum) {
//                System.out.println("Gunnar");
//            } else {
//                System.out.println("Emma");
//            }
//        }
//
//    }
//}

import java.util.*;

/**
 * Created by Edi on 18-Mar-17.
 */
public class ExamDemo {

    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        try {
            while (true) {
                int n = Integer.parseInt(Console.nextLine());
                String[][] matrix = new String[n][n];
                Map<String, Integer> fansByClub = new HashMap<>();

                for (int i = 0; i < n; i++) {
                    String input = Console.nextLine();
                    matrix[i] = input.split("");
                }

                for (int i = 0; i < n; i++) {
                    for (int j = 0; j < n; j++) {
                        if (!fansByClub.containsKey(matrix[i][j])) {
                            fansByClub.put(matrix[i][j], 0);
                        }

                        fansByClub.put(matrix[i][j], fansByClub.get(matrix[i][j]) + 1);
                    }
                }

                int row = 0;
                int col = 0;
                String club = "";

                for (Map.Entry<String, Integer> entry : fansByClub.entrySet()) {
                    if (entry.getValue() == 1) {
                        for (int i = 0; i < n; i++) {
                            for (int j = 0; j < n; j++) {
                                if (matrix[i][j].equals(entry.getKey())) {
                                    row = i + 1;
                                    col = j + 1;
                                }
                            }
                        }
                    } else if (entry.getValue() == n -1) {
                        club = entry.getKey();
                    } else if (entry.getValue() == n + 1) {
                        // fans from some club are more than n
                        //club = entry.getKey();

                        for (int i = 0; i < n; i++) {
                            int foundOnRow = 0;

                            for (int j = 0; j < n; j++) {
                                if (matrix[i][j].equals(entry.getKey())) {
                                    foundOnRow++;
                                }
                            }

                            if (foundOnRow == 2) {
                                row = i + 1;
                            }
                        }

                        for (int i = 0; i < n; i++) {
                            int foundOnCol = 0;

                            for (int j = 0; j < n; j++) {
                                if (matrix[j][i].equals(entry.getKey())) {
                                    foundOnCol++;
                                }
                            }

                            if (foundOnCol == 2) col = i + 1;

                        }
                    }
                }

                System.out.println(row + " " + col + " " + club);
            }
        } catch (Exception e) {
        }
    }

    public static String removeDuplicates(String input) {
        String result = "";
        for (int i = 0; i < input.length(); i++) {
            if (!result.contains(String.valueOf(input.charAt(i)))) {
                result += String.valueOf(input.charAt(i));
            }
        }
        return result;
    }
}


//package com.bookhut.config;
//
//import java.util.*;
//
///**
// * Created by Edi on 18-Mar-17.
// */
//public class ExamDemo {
//    static Map<String, Integer> depsCount;
//    static List<String> coals;
//    static int totalNumberDep;
//
//    public static void main(String[] args) {
//        Scanner Console = new Scanner(System.in);
//        try {
//            while(true) {
//                int n = Integer.parseInt(Console.nextLine());
//                depsCount = new HashMap<>();
//                coals = new ArrayList<>();
//                totalNumberDep = 0;
//                for (int i = 0; i < n; i++) {
//                    String par = Console.next();
//                    int dep = Console.nextInt();
//
//                    totalNumberDep += dep;
//                    depsCount.put(par, dep);
//                }
//
//                findCoals();
//            }
//        } catch (Exception e) {}
//    }
//
//    private static void findCoals() {
//
//    }
//}
