import java.util.Scanner;
public class TriangleArea {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		String[] triangleA = input.nextLine().split(" ");
		int AX = Integer.parseInt(triangleA[0]);
		int AY = Integer.parseInt(triangleA[1]);
		
		String[] triangleB = input.nextLine().split(" ");
		int BX = Integer.parseInt(triangleB[0]);
		int BY = Integer.parseInt(triangleB[1]);
		
		String[] triangleC = input.nextLine().split(" ");
		int CX = Integer.parseInt(triangleC[0]);
		int CY = Integer.parseInt(triangleC[1]);
		
		System.out.println("Triangle area: " + (AX*(BY - CY) + BX*(CY - AY) + CX*(AY-BY))/2);
	}
}
//FORMULA: Ax(By - Cy) + Bx(Cy - Ay) + Cx(Ay-By) / 2