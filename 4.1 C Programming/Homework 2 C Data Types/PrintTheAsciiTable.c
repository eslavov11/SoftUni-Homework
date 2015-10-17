

#include <stdio.h>
#include <stdlib.h>

/*
 */
int main(int argc, char** argv) 
{
    int i = 0;
    for (i = 0; i < 256; i++) 
    {
        if (i < '!') 
        {
            continue;
        }

        printf("%c", i );
    }

    return (EXIT_SUCCESS);
}

