#include <stdio.h>
#include <stdlib.h>

int wc(char * input, char delimiter);

int main() 
{
    printf("%d\n", wc("Hard Rock, Hallelujah!", ' '));
    printf("%d\n", wc("Hard Rock, Hallelujah!", ','));
    printf("%d\n", wc("Uncle Sam wants you Man", ' '));
    printf("%d\n", wc("Beat the beat!", '!'));
    
    return 0;
}

int wc(char * input, char delimiter)
{
    size_t count = 1;
    while (*input != '\0')
    {
        if (*input == delimiter)
        {
            count++;
        }
        
        *input++;
    }
    
    return count;
}