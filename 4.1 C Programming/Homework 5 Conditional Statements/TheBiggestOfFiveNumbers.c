#include <stdio.h>

int main()
{
    float a,b,c,d,e;
    scanf("%f", &a);
    scanf("%f", &b);
    scanf("%f", &c);
    scanf("%f", &d);
    scanf("%f", &e);
    if (a > b && a > c && a > e && a > d) 
    {
        printf("%.1f\n", a);
    }
    else if (b > a && b > c && b > e && b > d) 
    {
        printf("%.1f\n", b);
    }
    else if (c > a && c > b && c > e && c > d) 
    {
        printf("%.1f\n", c);
    }
    else if (d > a && d > c && d > e && d > b) 
    {
        printf("%.1f\n", d);
    }
    else
    {
        printf("%.1f\n", e);
    }
    return 0;
}