#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int n;
    scanf("%d", &n);
    printf(isPrime(n) == 0 ? "false\n" : "true\n");
    return (EXIT_SUCCESS);
}
int isPrime(int n)
{
    int i;
    if (n < 2)
    {
        return 0;
    }
    for (i = 2; i < n; i++) 
    {
        if (n%i==0) 
        {
            return 0;
        }
    }
    return 1;
}
