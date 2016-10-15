package app;

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
        int playerLeft = n,
            positionsForOneTurnLeft = m,
            currentPosition = 1,
            finalPersonPosition,
            p;

        ArrayList<Integer> peopleOutsideCirclePositions = arrangePeoplePositions(n);

        while (playerLeft > 1) {
            while (positionsForOneTurnLeft > 0) {
                currentPosition++;

                if (currentPosition > n) {
                    currentPosition %= n;
                }

                currentPosition = moveToNextValidStep(currentPosition, peopleOutsideCirclePositions, n);

                positionsForOneTurnLeft--;
            }

            finalPersonPosition = currentPosition;
            peopleOutsideCirclePositions.remove(new Integer(finalPersonPosition));
            currentPosition = moveToNextValidStep(currentPosition, peopleOutsideCirclePositions, n);;
            playerLeft--;

            positionsForOneTurnLeft = m;
        }

        p = peopleOutsideCirclePositions.get(0);

        return p;
    }

    private static int moveToNextValidStep(int currentPosition, ArrayList<Integer> peopleOutsideCirclePositions, int n) {
        int validStep = currentPosition;

        while (!peopleOutsideCirclePositions.contains(new Integer(validStep))) {
            validStep++;

            if (validStep > n) {
                validStep %= n;
            }
        }

        return validStep;
    }

    public static int findWinner2(int n, int m) {
        int peopleOutsideCircleCount = 0,
            currentPosition = 1;

        ArrayList<Integer> peopleOutsideCirclePositions = arrangePeoplePositions(n);

        while (n - 1 > peopleOutsideCircleCount) {
            int peoplePassed = 0;

            if (currentPosition > n) {
                currentPosition = currentPosition - n;
            }

            while(peoplePassed < m) {
                if (peopleOutsideCirclePositions.contains(new Integer(currentPosition))) {
                    currentPosition++;
                } else {
                    while (!peopleOutsideCirclePositions.contains(new Integer(currentPosition))) {
                        currentPosition++;

                        if (currentPosition > n) {
                            currentPosition = currentPosition - n;
                        }
                    }
                }

                peoplePassed++;
            }

            peopleOutsideCirclePositions.remove(new Integer(currentPosition));

            currentPosition++;

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