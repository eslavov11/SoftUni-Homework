package kasov_aparat;

import java.util.ArrayList;
import java.util.Scanner;

public class Broenka {
    public static void main(String[] args) {
        Scanner Console = new Scanner(System.in);

        int n = Console.nextInt(),
            m = Console.nextInt();

        int winnerPosition = findWinner(n, m);

        System.out.println(winnerPosition);
    }

    public static int findWinner(int n, int m) {
        int peopleOutsideCircleCount = 0,
            currentStep = 1;

        ArrayList<Integer> peopleOutsideCirclePositions = arrangePeoplePositions(n);

        while (n - 1 > peopleOutsideCircleCount) {
            currentStep = (currentStep + m) % n;

            if (currentStep == 0) {
                currentStep = n;
            }

            while (!peopleOutsideCirclePositions.contains(new Integer(currentStep))) {
                currentStep++;

                if (currentStep > n) {
                    currentStep = 0;
                }
            }

            peopleOutsideCirclePositions.remove(new Integer(currentStep));

            peopleOutsideCircleCount++;
        }

        return peopleOutsideCirclePositions.get(0);
    }

    private static ArrayList<Integer> arrangePeoplePositions(int n) {
        ArrayList<Integer> result = new ArrayList<>();

        for (int i = 1; i <= n; i++) {
            result.add(i);
        }

        return result;
    }
}