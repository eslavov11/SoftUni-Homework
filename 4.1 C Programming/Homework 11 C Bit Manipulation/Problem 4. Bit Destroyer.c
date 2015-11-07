#include <stdio.h>

int main() 
{
    int n, mask, p;
    scanf("%d", &n);
    scanf("%d", &p);
    n &= ~(1 << p);
    printf("%d\n", n);
    return 0;
}

