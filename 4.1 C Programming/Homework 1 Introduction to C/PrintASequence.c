#include <stdio.h>
int main()
{
    int i = 2;
    for (i = 2; i < 12; i++)
    {
        if (i % 2 == 0) 
        {
            printf("%d,",i);
        }
        else
        {
            printf("-%d,",i);
        }

    }

    return 0;
}
