#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int n,k;
    scanf("%d", &n);
    scanf("%d", &k);
    long i, nResult = 1, kResult = 1;
    for (i = 1; i <= n; i++) 
    {
        if (i<=n)
        {
            nResult*=i;
        }
        if (i<=k) 
        {
            kResult*=i;
        }
    }
    printf("%d\n", nResult/kResult);
    return 0;
}

