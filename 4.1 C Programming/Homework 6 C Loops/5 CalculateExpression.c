#include <stdio.h>
#include <stdlib.h>
#include <math.h>
int main() 
{
    int n,x,i;
    double sum = 1.0;
    scanf("%d", &n);
    scanf("%d", &x);
    for (i = 0; i < n; i++) 
    {
        sum += (double)(factorial(1+i)/pow(x,i+1));
    }
    printf("%.5f\n", sum);
    return 0;
}

int factorial(int num)
{
    int result = 1;
    int i;
    for (i = 1; i <= num; i++) {
        result*=i;
    }

    return result;
}

