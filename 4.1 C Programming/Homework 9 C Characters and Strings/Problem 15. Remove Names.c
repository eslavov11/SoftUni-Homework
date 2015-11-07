#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *firstList = NULL, *secondList = NULL;
    size_t sizeFirst = 0, sizeSecond = 0;
    size_t firstLen = getline(&firstList, &sizeFirst, stdin);
    size_t seondLen = getline(&secondList, &sizeSecond, stdin);
    
    char *token = strtok(secondList, " ");
    while (token)
    {
        size_t length = strlen(token);
        int i;
        char *substr = strstr(firstList, token);
        while (substr)
        {
            size_t index = substr - firstList;
            memmove(&firstList[index],
                        &firstList[index + length + 1], 
                        firstLen - index);
            substr = strstr(firstList, token);
        }
        
        
        token = strtok(NULL, " ");
    }
    
    printf("%s", firstList);
    
    free(firstList);
    free(secondList);
    
    return 0;
}