#include <stdio.h>
#include <stdlib.h>

char *read_line();

int main() 
{
    char *line;
    line = read_line(&line);
    printf("%s", line);
    
    free(line);
    
    return 0;
}

char *read_line()
{
    int initialSize = 4;
    char *readline = malloc(initialSize);
    int index = 0;
    char ch = getchar();
    while (ch != '\n' && ch != EOF)
    {
        if (index == initialSize - 1)
        {
            char *newReadLine = realloc(readline, initialSize * 2);
            if (!newReadLine)
            {
                printf("Not enough memory!");
                exit(1);
            }
            
            readline = newReadLine;
            initialSize *= 2;
        }
        
        *(readline + index) = ch;
        index++;
        ch = getchar();
    }
    
    *(readline + index) = '\0';
    
    return readline;
}