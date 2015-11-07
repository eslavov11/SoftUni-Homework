#include <stdio.h>

int main() 
{
    int n, firstBit;
    scanf("%d", &n);
    firstBit = (n >> 3) & 1;
    printf("%d\n", firstBit);
    return 0;
}

