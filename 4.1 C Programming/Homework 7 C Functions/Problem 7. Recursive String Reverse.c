#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define BUFFER_SIZE 50

void reverseString(char* string, int start, int end);

int main() 
{
    char input[BUFFER_SIZE];
    fgets(input, BUFFER_SIZE, stdin);
    int length = strlen(input) - 2;
  
    reverseString(input, 0, length);
    printf("%s", input);
    
    return 0;
}

void reverseString(char* string, int start, int end)
{
    if (start <= end)
    {
        char ch = string[start];
        string[start] = string[end];
        string[end] = ch;
        reverseString(string, ++start, --end);
    }
}