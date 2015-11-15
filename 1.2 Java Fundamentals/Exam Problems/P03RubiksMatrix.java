import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P03RubiksMatrix {

    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);
        String[] rubikSize = Console.nextLine().split("\\s+");
        int r = Integer.parseInt(rubikSize[0]);
        int c = Integer.parseInt(rubikSize[1]), fill = 1;
        int[][] arr = new int[r][c];
        int[][] rightMatrix = new int[r][c];

        for (int i = 0; i < r; i++) {
            for (int j = 0; j < c; j++) {
                arr[i][j] = fill;
                rightMatrix[i][j] = fill;
                fill++;
            }
        }
        int commandCount = Integer.parseInt(Console.nextLine());
        for (int i = 0; i < commandCount; i++) {
            String[] tokens = Console.nextLine().split("\\s+");
            int dirLine = Integer.parseInt(tokens[0]);
            String direction = tokens[1];
            int times = Integer.parseInt(tokens[2]);

            if (direction.equals("down")) {
                times %= r;
                int[] tempCol = new int[r];
                for (int j = 0; j < c; j++) {
                    tempCol[j] = arr[j][dirLine];
                }
                int index = 0;
                for (int j =  r -times; j < r; j++, index++) {
                    arr[index][dirLine] = tempCol[j];
                }
                for (int j = 0; j < r - times; j++, index++) {
                    arr[index][dirLine] = tempCol[j];
                }
            } else if (direction.equals("up")) {
                times %= r;
                int[] tempCol = new int[r];
                for (int j = 0; j < c; j++) {
                    tempCol[j] = arr[j][dirLine];
                }
                int index = 0;
                for (int j = times; j < r; j++, index++) {
                    arr[index][dirLine] = tempCol[j];
                }
                for (int j = 0; j < times; j++, index++) {
                    arr[index][dirLine] = tempCol[j];
                }
            } else if (direction.equals("left")) {
                times %= c;
                int[] tempRow = new int[c];
                for (int j = 0; j < c; j++) {
                    tempRow[j] = arr[dirLine][j];
                }
                int index = 0;
                for (int j = times; j < c; j++, index++) {
                    arr[dirLine][index] = tempRow[j];
                }
                for (int j = 0; j < times; j++, index++) {
                    arr[dirLine][index] = tempRow[j];
                }
            } else if (direction.equals("right")) {
                times %= c;
                int[] tempRow = new int[c];
                for (int j = 0; j < c; j++) {
                    tempRow[j] = arr[dirLine][j];
                }
                int index = 0;
                for (int j = c - times; j < c; j++, index++) {
                    arr[dirLine][index] = tempRow[j];
                }
                for (int j = 0; j < c - times; j++, index++) {
                    arr[dirLine][index] = tempRow[j];
                }
            }
        }
        boolean toBreak = true;
        for (int i = 0; i < r ; i++) {
            for (int j = 0; j < c; j++) {
                if (rightMatrix[i][j] == arr[i][j]) {
                    System.out.println("No swap required");
                } else {
                    toBreak = false;
                    for (int k = 0; k < r; k++) {
                        for (int l = 0; l < c; l++) {
                            if (rightMatrix[i][j] == arr[k][l]) {
                                int temp = arr[i][j];
                                arr[i][j] = arr[k][l];
                                arr[k][l] = temp;
                                System.out.printf("Swap (%d, %d) with (%d, %d)\n", i,j,k,l);
                                toBreak = true;
                                break;
                            }
                        }
                        if (toBreak) {
                            break;
                        }
                    }
                }
            }
        }
    }
}

