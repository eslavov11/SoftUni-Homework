#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main() 
{
    char *text = NULL;
    size_t size = 0;
    size_t textLength = getline(&text, &size, stdin);
    text[textLength - 1] = '\0';
    
    char *longestWord = calloc(1, sizeof(char));
    if (!longestWord)
    {
        printf("No memory to allocate!");
        return 1;
    }
    
    size_t longestWordLength = strlen(longestWord);
    char *token = strtok(text, " ,.?!\t");   
    while (token)
    {
        size_t currentWordLength = strlen(token);
        if (currentWordLength > longestWordLength)
        {
            char *newLongestWord = realloc(longestWord, currentWordLength + 1);
            if (!newLongestWord)
            {
                printf("No memory to allocate!");
                return 1;
            }
            
            longestWord = newLongestWord;
            strcpy(longestWord, token);
            longestWordLength = currentWordLength;
            longestWord[currentWordLength] = '\0';
        }
        
        token = strtok(NULL, " ,.?!\t");
    }
    
    printf("%s\n", longestWord);
    
    free(longestWord);
    free(text);
    
    return 0;
}