import java.util.Scanner;

public class P16CalculateNFactorial {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Insert a number in range [1..20] = ");
        long num = scanner.nextLong();
        long factorial = calculateFactorial(num);
        System.out.printf("The factorial of %d is: %d", num, factorial);
    }

    private static long calculateFactorial(long num) {
        if(num == 1 || num == 0) {
            return 1;
        }

        return num * calculateFactorial(num - 1);
    }
}