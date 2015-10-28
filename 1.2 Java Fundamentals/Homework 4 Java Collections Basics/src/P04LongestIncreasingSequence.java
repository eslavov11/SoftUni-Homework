import java.util.Scanner;

public class P04LongestIncreasingSequence {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Insert n integers on a single line, separataed by space = ");

        String[] inputArr = scanner.nextLine().trim().split("\\s+");
        int[] nums = new int[inputArr.length];
        for (int i = 0; i < nums.length; i++) {
            nums[i] = Integer.parseInt(inputArr[i]);
        }

        int longestSequence = 0;
        int startIndex = 0;
        for (int i = 0; i < nums.length; i++) {
            int currentNum = nums[i];
            int currentIndex = i;
            int currentLongestSequence = 1;
            System.out.print(currentNum);

            for (int j = i + 1; j < nums.length; j++) {
                int subNum = nums[j];
                if (subNum > currentNum) {
                    System.out.print(" " + subNum);
                    currentNum = subNum;
                    currentLongestSequence++;
                    i++;
                } else {
                    break;
                }
            }

            if(currentLongestSequence > longestSequence) {
                longestSequence = currentLongestSequence;
                startIndex = currentIndex;
            }

            System.out.println();
        }

        System.out.print("Longest:");
        for (int i = startIndex; i < startIndex + longestSequence; i++) {
            System.out.print(" " + nums[i]);
        }
    }
}