//#include <stdio.h>
//#include <stdlib.h>
//
//int main(int argc, char** argv)
//{
//    int number,sum =0, reversed= 0, third, fourth;
//    scanf("%d", &number);
//    sum = number%10 + number/10%10 + number/100%10 + number/1000%10;
//    reversed = number%10*1000 + number/10%10*100 + number/100%10*10 + number/1000%10;
//    third = number%10*1000 + number/10%10 + number/100%10*10 + number/1000%10*100;
//    fourth = number%10 + number/10%10*100 + number/100%10*10 + number/1000%10*1000;
//    printf("%d\n%d\n%d\n%d\n", sum, reversed, third, fourth);
//    return (EXIT_SUCCESS);
//}
////Write a program that takes as input a four-digit number in format abcd 
////(e.g. 2011) and performs the following:
//// Calculates the sum of the digits (in our example 2+0+1+1 = 4).
//// Prints on the console the number in reversed order: dcba (in our example 1102).
//// Puts the last digit in the first position: dabc (in our example 1201).
//// Exchanges the second and the third digits: acbd (in our example 2101).
//
