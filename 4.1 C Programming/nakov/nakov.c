#include <stdio.h>
#include <math.h>
int pow_ints(int a, int b);
int main() 
{
    unsigned int n, firstPair, secondPair, p, q, k;
    scanf("%d", &n);
    scanf("%d", &p);
    scanf("%d", &q);
    scanf("%d", &k);
    
    firstPair = (n>>p) & (pow_ints(2,k)-1);
    secondPair = (n>>q) & (pow_ints(2,k)-1);
    n &= ~((pow_ints(2,k)-1)<<p);
    n &= ~((pow_ints(2,k)-1)<<q);
    n |= firstPair << q;
    n |= secondPair << p;
    printf("%d\n", n);
    return 0;
}

int pow_ints(int a, int b)
{
    int i,result=1;
    for (i = 0; i < b; i++) {
        result*=a;
    }
    return result;
}