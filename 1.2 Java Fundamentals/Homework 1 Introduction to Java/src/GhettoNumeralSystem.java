import java.util.Scanner;
public class GhettoNumeralSystem {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		String number = input.nextLine();
		for (int i = 0; i < number.length(); i++) {
			printGhetto(number,i);
		}
	}
	
	public static void printGhetto(String number, int i){
		switch(number.charAt(i)){
		case '0':
			System.out.print("Gee");
			break;
		case '1':
			System.out.print("Bro");
			break;
		case '2':
			System.out.print("Zuz");
			break;
		case '3':
			System.out.print("Ma");
			break;
		case '4':
			System.out.print("Duh");
			break;
		case '5':
			System.out.print("Yo");
			break;
		case '6':
			System.out.print("Dis");
			break;
		case '7':
			System.out.print("Hood");
			break;
		case '8':
			System.out.print("Jam");
			break;
		case '9':
			System.out.print("Mack");
			break;
		default:
			break;
		}
	}
}
//	0 – Gee
//	1 – Bro
//	2 – Zuz
//	3 – Ma
//	4 – Duh	
//	5  - Yo
//	6 – Dis
//	7 – Hood
//	8 – Jam
//	9 – Mack
