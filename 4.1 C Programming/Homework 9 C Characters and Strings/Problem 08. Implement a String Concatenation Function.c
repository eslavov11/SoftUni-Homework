#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char *string_concat(char *source, char *dest, size_t length);

int main() 
{
    char buffer1[10] = "Soft";
    string_concat("Uni", buffer1, 7);
    printf("%s\n", buffer1);
    
//    This will segmentation fault, beacause buffer has size of 5 but it
//    try to concatenate 15 chars.
//    char buffer[5] = "Soft";
//    string_concat("ware University", buffer, 15);
    
    char buffer2[10]= "C";
    string_concat(" is cool", buffer2, 8);
    printf("%s", buffer2);

//    This will segmentation fault, because buffer is initialized on
//    read only memory.
//    char *buffer = "C";
//    string_concat(" is cool", buffer, 8);
    
    return 0;
}

char *string_concat(char *source, char *dest, size_t length)
{
    size_t dest_length = strlen(dest);
    size_t i;

    for (i = 0; i < length; i++)
    {
        if (source[i] != '\0')
        {
            dest[dest_length + i] = source[i];
        }
        else
        {
            return dest;
        }
    }

    dest[dest_length + i] = '\0';
    
    return dest;
}