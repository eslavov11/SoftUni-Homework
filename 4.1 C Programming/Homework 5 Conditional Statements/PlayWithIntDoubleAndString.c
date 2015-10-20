#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    printf("Please choose a type:\n 1 --> int\n 2 --> double\n 3 --> string\n");
    int type;
    scanf("%d", &type);
    if (type==1) 
    {
        int n;
        printf("Please enter a int: ");
        scanf("%d", &n);
        printf("%d\n", ++n);
    }
    else if (type==2)
    {
        double n;
        printf("Please enter a double: ");
        scanf("%lf", &n);
        printf("%.2f\n", ++n);
    }
    else
    {
      char n[21];
        printf("Please enter a string: ");
        scanf("%20s", &n); 
        printf("%s*\n", n);
    }
    return (EXIT_SUCCESS);
}

