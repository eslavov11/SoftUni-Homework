#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv)
{
    int number, n;
    scanf("%d",&number);
    scanf("%d",&n);
    printf(n > digitCount(number) ? "-\n" : "%d\n", ((number / (int)pow(10,n-1)) % 10));
    return (EXIT_SUCCESS);
}
int digitCount(int number)
{
    int count=0;
    while(number!=0)
    {
        number /= 10;
        count++;
    }
    return count;
}

