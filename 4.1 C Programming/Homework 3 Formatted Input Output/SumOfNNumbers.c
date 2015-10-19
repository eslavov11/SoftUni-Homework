#include <stdio.h>
int main()
{
    int n, i;
    double temp = 0 ,sum = 0;
    scanf("%d", &n);
    for (i = 0; i < n; i++) 
    {
        scanf("%lf", &temp);
        sum = sum + temp;
        temp = 0;
    }
    printf("%.2f\n", sum);
    return 0;
}