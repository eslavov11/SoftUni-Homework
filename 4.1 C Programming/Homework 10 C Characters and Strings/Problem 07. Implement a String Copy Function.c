#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *string_copy(char *source, char *dest, size_t size);

int main() 
{
    char destFirstExample[8];
    memset(destFirstExample, 0, 8 * sizeof(char));
    string_copy("SoftUni", destFirstExample, 7);
    printf("First example: %s\n", destFirstExample);
    
    char destSecondExample[8];
    memset(destSecondExample, 0, 8 * sizeof(char));
    string_copy("SoftUni", destSecondExample, 3);
    printf("Second example: %s\n", destSecondExample);
    
    char destThirdExample[8];
    memset(destThirdExample, 0, 8 * sizeof(char));
    string_copy("C is cool", destThirdExample, 0);
    printf("Third example: %s", destThirdExample);
    
    //Fourth example won't compile due to number of arguments that 
    //function need to work.
    
    return 0;
}

char *string_copy(char *source, char *dest, size_t size)
{
    size_t i;
    int isEndOfSource = 0;
    
    for (i = 0; i < size; i++)
    {
        if (source[i] == '\0')
        {
            isEndOfSource = 1;
        }
        
        if (isEndOfSource)
        {
            dest[i] = '\0';
        }
        else
        {
            dest[i] = source[i];
        }
    }
    
    return dest;
}