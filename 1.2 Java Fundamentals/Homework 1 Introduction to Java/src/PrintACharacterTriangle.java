import java.util.Scanner;
public class PrintACharacterTriangle {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		int size = Integer.parseInt(input.nextLine());
		for(int i = 0, bottom = -1; i<size*2-1; i++){
			if (i < size) {
				for (char j = 'a'; j < 'a' + i+1; j++) {
					System.out.print(j);
				}
			}
			else {
				for (char j = 'a'; j <  'a' + size - bottom++; j++) {
					System.out.print(j);
				}
			}
			System.out.println();
		}
	}
}
