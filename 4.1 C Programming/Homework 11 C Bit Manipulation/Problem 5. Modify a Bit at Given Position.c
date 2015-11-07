#include <stdio.h>

int main() 
{
    int n, p, v;
    scanf("%d", &n);
    scanf("%d", &p);
    scanf("%d", &v);
    v ? (n |= (1 << p)) : (n &= ~(1 << p));
    printf("%d\n", n);
    return 0;
}

