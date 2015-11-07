#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *substr(char * src, int position, int length);

int main() 
{
    char *result1 = substr("Breaking Bad", 0, 2);
    printf("%s\n", result1);
    
    char *result2 = substr("Maniac", 3, 3);
    printf("%s\n", result2);
    
    char *result3 = substr("Maniac", 3, 5);
    printf("%s\n", result3);
    
    char *result4 = substr("Master Yoda", 13, 5);
    printf("%s\n", result4);
    
    free(result1);
    free(result2);
    free(result3);
    free(result4);
    
    return 0;
}

char *substr(char * src, int position, int length)
{
    size_t sourceLength = strlen(src);
    if (position >= sourceLength)
    {
        char *substring = malloc(1);
        substring[0] = '\0';
        return substring;
    }
    else if (position < 0)
    {
        printf("Invalid starting position!");
        exit(1);
    }
    
    char *substring = calloc(length + 1, sizeof(char));
    if (!substring)
    {
        printf("No memory to allocate!");
        exit(1);
    }
    
    int i;
    for (i = 0; i < length; i++)
    {
        substring[i] = src[position + i];
    }
    
    substring[i] = '\0';
    
    return substring;
}