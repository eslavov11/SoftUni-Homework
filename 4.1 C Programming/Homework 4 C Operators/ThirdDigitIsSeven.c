#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv)
{
    int number,result;
    scanf("%d", &number);
   // result = number<<;
   // result = number<<;
    result = number/100%10;
    printf(result == 7 ? "true\n" : "false\n");
    return (EXIT_SUCCESS);
}

