#include <stdio.h>

int main() 
{
    int n, firstPair, secondPair;
    scanf("%d", &n);
    firstPair = (n>>3) & 7;
    secondPair = (n>>24) & 7;
    n &= ~(7<<3);
    n &= ~(7<<24);
    n |= firstPair << 24;
    n |= secondPair << 3;
    printf("%d\n", n);
    return 0;
}
