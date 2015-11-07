#include <stdio.h>
#include <stdlib.h>
#include <string.h>
char *read_line();
char *string_tolower(char *str);
int countSubstringOccurances(const char *string, const char *substr);

int main() 
{
    char *string = read_line();
    string = string_tolower(string);
    char *sub = read_line();
    
    printf("%d\n", countSubstringOccurances(string,sub));
    return 0;
}

int countSubstringOccurances(const char *string, const char *substr)
{
    int count = 0;
    int i,j,subIn,inCount;
    for (i = 0; i < strlen(string); i++) {
        for (j = i,subIn=0, inCount = 0; j < i + strlen(substr); j++) {
            if(string[j] == substr[subIn++])
            {
                inCount++;
            }
        }
        if(inCount == strlen(substr))
        {
            count++;
        }

    }

    
    
    return count;
}

char *string_tolower(char *str)
{
    size_t size = strlen(str);
    char *result = calloc(size + 1, sizeof(char));
    if (!result)
    {
        printf("No memory to allocate!");
        exit(1);
    }
    
    int i;
    for (i = 0; i < size; i++)
    {
        result[i] = tolower(str[i]);
    }
    
    result[i] = '\0';
    
    return result;
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