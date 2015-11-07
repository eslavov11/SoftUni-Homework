#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *pad_right(char *input, char paddingChar, int totalStringSize);
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

int main() 
{
    char *string = read_line(&string);
    string = pad_right(string, '*', 20);
    printf("%s\n", string);
    return 0;
}

char *pad_right(char *input, char paddingChar, int totalStringSize)
{
    //doesnt work with big values over 40
    size_t stringLength= strlen(input);
    
    char *cpy = malloc(totalStringSize+1);
    
    if(stringLength<totalStringSize)
    {
        strcpy(cpy,input);
        int i;
        for (i = stringLength; i < totalStringSize; i++) 
        {
            cpy[i] = paddingChar;
        }
        cpy[totalStringSize] = '\0';
        strcpy(input,cpy);
    }
    
    return input;
}

