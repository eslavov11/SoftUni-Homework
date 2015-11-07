#include <stdio.h>

int main() 
{
    int n, firstBit, p;
    scanf("%d", &n);
    scanf("%d", &p);
    firstBit = (n >> p) & 1;
    printf("%d\n", firstBit);
    return 0;
}

