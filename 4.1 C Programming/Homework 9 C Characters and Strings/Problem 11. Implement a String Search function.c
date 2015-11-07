#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int strsearch(char * src, char * substr);

int main() 
{
    printf("%d\n", strsearch("SoftUni", "Soft"));
    printf("%d\n", strsearch("Hard Rock", "Rock"));
    printf("%d\n", strsearch("Ananas", "nasa"));
    printf("%d\n", strsearch("Coolness", "cool"));
    
    return 0;
}

int strsearch(char * src, char * substr)
{
    size_t searchedLength = strlen(substr);
    size_t sourceLength = strlen(src);
    if (searchedLength > sourceLength)
    {
        return 0;
    }
    
    int i;
    for (i = 0; i < sourceLength; i++)
    {
        int j;
        for (j = 0; j < searchedLength; j++)
        {
            if (substr[j] != src[i + j])
            {
                break;
            }
        }
        
        if (j == searchedLength)
        {
            return 1;
        }
    }
    
    return 0;
}