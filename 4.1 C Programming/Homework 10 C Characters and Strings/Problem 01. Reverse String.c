#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *read_line();
char *string_reverse();

int main() 
{
    char *string;
    string = read_line(&string);
    string = string_reverse(string);
    printf("%s\n", string);
    free(string);
    
    return 0;
}

char *string_reverse(char *input)
{
    size_t stringLength= strlen(input);
    char *reversed = calloc(stringLength + 1, sizeof(char));
    if (!reversed)
    {
        printf("Cannot allocate enough memory!");
        exit(1);
    }
    
    int i, j;
    for (i = stringLength - 1, j = 0; i >= 0; i--, j++)
    {
        reversed[j] = input[i];
    }
    
    reversed[j] = '\0';
    
    return reversed;
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