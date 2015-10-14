import java.util.Scanner;
public class GetAverage {
	public static void main(String[] args){
		Scanner input = new Scanner(System.in);
		double a = Double.parseDouble(input.nextLine());
		double b = Double.parseDouble(input.nextLine());
		double c = Double.parseDouble(input.nextLine());
		
		double result = getAverage(a,b,c);
		System.out.printf("%.2f",result);
	}
	public static double getAverage(double a, double b, double c){
		return (a+b+c)/3;
	}
}
