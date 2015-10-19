#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int main(int argc, char** argv)
{
    int number, n;
    scanf("%d",&number);
    scanf("%d",&n);
    printf("%d",((number / pow(10,n)) % 10));
    return (EXIT_SUCCESS);
}

