#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *read_line(FILE *file);

int main()
{
    FILE *lineFile = fopen("Problem 1 text.txt", "r");
    FILE *modifiedFile = fopen("Problem 3 modified.txt","w");
    if(!modifiedFile)
    {
        printf("Error in file\n");
        return 1;
    }
    if(lineFile)
    {
        int i = 1;
        while(!feof(lineFile))
        {
            char *line = read_line(lineFile);
            char *result = malloc(strlen(line)+5);
            sprintf(result, "%d. %s\n", i, line);
            fwrite(result,1, strlen(result),modifiedFile);
            free(result);
            i++;
        }
    }
    fclose(modifiedFile);
    fclose(lineFile);
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