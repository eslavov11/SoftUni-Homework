import java.util.Scanner;
public class CalculateExpression {
	
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		float a = Float.parseFloat(input.nextLine());
		float b = Float.parseFloat(input.nextLine());
		float c = Float.parseFloat(input.nextLine());
		double f1 = Math.pow((a*a + b*b)/(a*a - b*b),((a+b+c)/Math.sqrt(c)));
		double f2 = Math.pow((a*a + b*b - c*c*c),(a-b));
		System.out.printf("F1 result: %.2f", f1); 
		System.out.printf("; F2 result: %.2f", f2);
		System.out.printf("; Diff: %.2f",  Math.abs((((a+b+c)/3) - ((f1+f2)/2))));
		
//		((a2 + b2) / (a2 – b2))(a + b + c) / √c             (a2 + b2 - c3)(a – b)
	}
}