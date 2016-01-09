#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <limits.h>

char *read_line();
int main()
{   
    unsigned int a,b;
    scanf("%d", &a);
    scanf("%d", &b);
    unsigned long long result = 0;
    if (a>=b)
    {
        int i, aIndex = 0, bIndex = 0;
        for (i = 0; i < 64; i++) 
        {
            if (i % 2 == 0) 
            {
                unsigned long long mask = (b>>(bIndex++) & 1);
                result |= (mask<<i);
            }
            else
            {
                unsigned long long mask = ((a>>aIndex++) & 1);
                result |= (mask<<i);
            }
        }

    }
    else
    {
        int i, aIndex = 0, bIndex = 0, curr = 0;
        for (i = 0; i < 64; i+=2, curr++) 
        {
            if (curr % 2 == 0) 
            {
                unsigned long long mask = ((b>>bIndex) & 3);
                result |= (mask<<i);
                bIndex+=2;
            }
            else
            {
                unsigned long long mask = ((a>>aIndex) & 3);
                result |= (mask<<i);
                aIndex+=2;
            }
        }
    }
    printf("%llu\n", result);
}

char *read_line()
{
	int initialSize = 4;
	char *readline = (char*)malloc(initialSize);
	int index = 0;
	char ch = getchar();
	while (ch != '\n' && ch != EOF)
	{
		if (index == initialSize - 1)
		{
			char *newReadLine = (char*)realloc(readline, initialSize * 2);
			if (!newReadLine)
			{
				printf("Not enough memory!");
				exit(1);
			}

			readline = (char*)newReadLine;
			initialSize *= 2;
		}

		*(readline + index) = ch;
		index++;
		ch = getchar();
	}

	*(readline + index) = '\0';

	return readline;
}