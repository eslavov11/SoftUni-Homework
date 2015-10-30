
package nakov;

import java.util.Scanner;

public class Nakov {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int minutes=0,hours=0;
        String text = input.nextLine();
        while (!text.equals("End")) {
            minutes+=text.charAt(text.length()-1)-48;
            minutes+=(text.charAt(text.length()-2)-48)*10;
            String[] in = text.split(":");
            hours+= Integer.parseInt(in[0]);
            if (minutes>59) {
                hours++;
                minutes-=60;
            }
            text = input.nextLine();
        }
        String finalMinutes;
        if (minutes<10) {
            finalMinutes = "0" + minutes;
        } else {
            finalMinutes = "" + minutes;
        }
        System.out.println(hours + ":" + finalMinutes);
    }
    
}
