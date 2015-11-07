
    package nakov;
    import java.util.Map;
    import java.util.HashMap;
    import java.util.Scanner;

    public class Nakov {

        public static void main(String[] args) {
            Scanner input = new Scanner(System.in);
            int numbersCount = input.nextInt();
            boolean found = false;
            int arr[] = new int[numbersCount];
            Map<int,int> matcher = new HashMap<int,int>();  
            for (int i = 0; i < numbersCount; i++) {
                arr[i] = input.nextInt();
            }
            for (int i = 0; i < numbersCount; i++) {
                for (int j = 0; j < numbersCount; j++) {
                    for (int k = 0; k < numbersCount; k++) {

                        if (arr[i]*arr[i] + arr[j]*arr[j] == arr[k]*arr[k]) {
                            System.out.println(arr[i] + "*" + arr[i] + " + " + arr[j] + "*" + arr[j] 
                                            + " = " + arr[k] + "*" + arr[k]);
                            found=true;
                        }
                    }
                }
            }
            if (!found) {
                System.out.println("No"); 
            }
        }
    }