#include <stdio.h>
#include <stdlib.h>
int get_max(int a, int b);

int main()
{
    int a,b;
    scanf("%d", &a);
    scanf("%d", &b);
    printf("%d\n", get_max(a,b));
    return 0;
}

int get_max(int a, int b)
{
    return a > b ? a : b;
}

