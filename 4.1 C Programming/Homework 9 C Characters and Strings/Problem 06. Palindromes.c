#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

int is_paliandrom(char *string);
char *reverse_string(char * string);
int containes(char **array, char * searched, int length);
void print_array(char **array, int length);
void bubble_sort(char **array, int length);
char *to_lower_string(char *str, size_t size);

int main() 
{
    char *text = NULL;
    size_t size = 0;
    int length = getline(&text, &size, stdin);
    text[length - 1] = '\0';
    length = strlen(text);
    
    char **paliandromes = calloc(length, sizeof(char *));
    if (!paliandromes)
    {
        printf("Cannot allocate enough memory!");
        exit(1);
    }
    
    char *token = strtok(text, " ,.?!");
    int i = 0;
    while (token)
    {
        if (is_paliandrom(token))
        {
            int paliLength = strlen(token);
            paliandromes[i] = calloc(paliLength + 1, sizeof(char));
            if (!paliandromes[i])
            {
                printf("Cannot allocate enough memory!");
                exit(1);
            }

            int isContained = containes(paliandromes, token, i);
            if (!isContained)
            {
                strncat(paliandromes[i], token, paliLength);
                paliandromes[i][paliLength] = '\0';
                i++;
            }
            else
            {
                free(paliandromes[i]);
            }
        }
        
        token = strtok(NULL, " ,.?!");
    }
    
    free(text);
    bubble_sort(paliandromes,  i);
    print_array(paliandromes, i);
    i--;
    while (i >= 0)
    {
        free(paliandromes[i]);
        i--;
    }
    
    free(paliandromes);
    
    return 0;
}

int is_paliandrom(char *string)
{
    int isPali = 0;
    char *reversed = reverse_string(string);
    if (strcmp(string, reversed) == 0)
    {
        isPali = 1;
        free(reversed);
        
        return isPali;
    }
    
    free(reversed);
    
    return isPali;
}

char *reverse_string(char *string)
{
    size_t stringLength= strlen(string);
    char *reversed = calloc(stringLength + 1, sizeof(char));
    if (!reversed)
    {
        printf("Cannot allocate enough memory!");
        exit(1);
    }
    
    int i, j;
    for (i = stringLength - 1, j = 0; i >= 0; i--, j++)
    {
        reversed[j] = string[i];
    }
    
    reversed[j] = '\0';
    
    return reversed;
}

int containes(char **array, char * searched, int length)
{
    int i, isFound = 0;
    for (i = 0; i < length; i++)
    {
        char *substr = strstr(array[i], searched);
        if (substr)
        {
            isFound = 1;
            break;
        }
    }
        
    return isFound;
}

void print_array(char **array, int length)
{
    int i;
    for (i = 0; i < length; i++)
    {
        if (i < length - 1)
        {
            printf("%s, ", array[i]);
        }
        else
        {
            printf("%s", array[i]);
        }
    }
}

void bubble_sort(char **array, int length)
{
    int hasSwaped = 1;
    while (hasSwaped)
    {
        hasSwaped = 0;
        int i;
        for (i = 0; i < length - 1; i++)
        {
            size_t currStrLen = strlen(array[i]);
            char *currentStr = to_lower_string(array[i], currStrLen);
            size_t nextStrLen = strlen(array[i + 1]);
            char *nextStr = to_lower_string(array[i + 1], nextStrLen);
            
            if (strcmp(currentStr, nextStr) >= 0)
            {
                char *temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
                hasSwaped = 1;
            }
            
            free(currentStr);
            free(nextStr);
        }
    }
}

char *to_lower_string(char *str, size_t size)
{
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