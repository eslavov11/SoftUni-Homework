#include <stdio.h>
#include <stdlib.h>

char *read_line(FILE *file);
int main()
{
    FILE *oddFile = fopen("Problem 1 text.txt", "r");
    if (oddFile)
    {
        char index = 0;
        while(!feof(oddFile))
        {
            char *buffer = read_line(oddFile);
            if(index%2!=0)
            {
                printf("%s\n", buffer);
            }
            index++;
        }
        printf("\n");
    }
    fclose(oddFile);
    return 0;
}

char *read_line(FILE *file)
{
    int initialSize = 4;
    char *readline = malloc(initialSize);
    int index = 0;
    char ch = fgetc(file);//getchar();
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
        ch = fgetc(file);
    }
    
    *(readline + index) = '\0';
    
    return readline;
}

