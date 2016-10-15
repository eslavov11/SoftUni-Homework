package kasov_aparat;

import java.util.ArrayList;
import java.util.Date;
import java.util.Scanner;

public class InteractiveCashRegister extends CashRegister {
    private static Scanner Console = new Scanner(System.in);

    public static Bond enterNewBond() {
        int id = Console.nextInt();
        if (id < 0) {
            throw new IllegalArgumentException("Id must be a non negative number");
        }

        return new Bond(id, new Date(), new ArrayList<>());
    }

    public void printReport() {
        for (Bond bond : super.bonds) {
            System.out.println(bond);
        }
    }

    public void start() {
        String inputLine = Console.nextLine();

        while (!inputLine.equals("Izhod")) {
            switch (inputLine) {
                case "Izdavane na kasov bon":
                    super.addBond(enterNewBond());
                break;
                case "Otpechatvane na otchet za period":
                    printReport();
                break;
                default:
                break;
            }

            inputLine = Console.nextLine();
        }
    }

    public static void main(String[] args) {
        InteractiveCashRegister register = new InteractiveCashRegister();

        register.initialize();
        register.start();
    }
}
