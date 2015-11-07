#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *read_line();
char *remove_equal_consecutive_chars(char *input);

int main() 
{
    char *string = read_line(&string);
    string = remove_equal_consecutive_chars(string);
    printf("%s\n", string);
    return 0;
}

//removes equal consecutive chars ex. aaabb -> ab
char *remove_equal_consecutive_chars(char *input)
{
    size_t stringLength= strlen(input);
    
    char *cpy = malloc(stringLength);
    cpy[0] = input[0];
    int i,index=0;
    for (i = 0; i < stringLength; i++) 
    {
        if(input[i] != input[i-1])
        {
            cpy[index] = input[i];
            index++;
        }
    }
    cpy[index] = '\0';
    strcpy(input,cpy);
        
    return input;
}

//reads the intire line
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
