#include <stdio.h>
#include <stdlib.h>

size_t string_length(char *str);

int main() 
{
    printf("%lu\n", string_length("Soft"));
    printf("%lu\n", string_length("SoftUni"));
    
    char buffer[10] =  {'C', '\0', 'B', 'a', 'b', 'y' };
    printf("%lu\n", string_length(buffer));

//    Can't be initialized like that.
//    char *buffer1 = { 'D', 'e', 'r', 'p' };
//    printf("%lu\n", string_length(buffer1));
    
    return 0;
}

size_t string_length(char *str)
{
    size_t length = 0;
    while (*str != '\0')
    {
        length++;        
        *str++;
    }
    
    return length;
}