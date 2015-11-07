#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define WORDS_COUNT 10
char *read_line();

int main() 
{
    char *input = read_line();
    char *bannedWords[WORDS_COUNT];
    char *token = strtok(input, ", ");
    int index = 0;
    while (token != NULL) 
    {
        bannedWords[index] = malloc(strlen(token) + 1);
        strcpy(bannedWords[index],token);
        index++; 
        token = strtok(NULL, " , ");
    }
    char *text = read_line();
    printf("%d\n", strlen(bannedWords[0]));
    int i,j,count=0, arrI, arrJ;
    for (i = 0; i < strlen(text); i++) 
    {
        for (arrI=0;arrI<strlen(bannedWords)-1;arrI++)
        {
            for (j = i, count = 0, arrJ = 0; j < i + strlen(bannedWords[arrI]); j++)
            {
                if(text[j] != bannedWords[arrI][arrJ++])
                {
                    break;
                }
                else count++;
            }
            if(count == strlen(bannedWords[arrI]))
            {
                for (j = i; j < i + strlen(bannedWords[arrI]); j++)
                {
                    text[j] = '*';
                }
            }
        }
    }
    printf("%s\n", text);
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
