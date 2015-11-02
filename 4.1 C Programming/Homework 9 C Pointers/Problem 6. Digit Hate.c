#include <stdio.h>
#include <stdlib.h>
#include <string.h>

char* replace_digits(char *array, int length, int *digits);

int main() 
{
    char *line, *string;
    size_t size = 0;
    getline(&line, &size, stdin);
    int length = strlen(line);
    int digits = 0;
    string = replace_digits(line, length, &digits);
    
    printf("\n");
    printf("%s%d digits were replaced", string, digits);
    
    free(string);
    free(line);
    
    return 0;
}

char* replace_digits(char *array, int length, int *digits)
{
    int i;
    char *result = malloc(length * sizeof(char));
    for (i = 0; i < length; i++)
    {
        if ((*(array + i) >= 48) && (*(array + i) <= 57))
        {
            *(result + i) = '/';
            *digits += 1;
        }
        else
        {
            *(result + i) = *(array + i);
        }
    }
    
    return result;
}