#include <stdio.h>

/*
 * Write a program that reads 3 real numbers from the console 
 * and prints their sum.
 */
int main() 
{
    double a,b,c;
    scanf("%lf",&a);
    scanf("%lf",&b);
    scanf("%lf",&c);
    double sum = a + b + c;
    printf("%.2f", sum);
            
    return 0;
}