#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

int main() 
{
    char *line = NULL;
    size_t size = 0;
    size_t lineLength = getline(&line, &size, stdin);
    while (*line != '\n')
    {
        line[lineLength - 1] = '\0';
        size_t index = 0, currentSize = 1;
        char **words = calloc(currentSize, sizeof(char *));
        if (!words)
        {
            printf("No memory to allocate!");
            return 1;
        }
        
        char *token = strtok(line, "<>");
        while (token)
        {
            if (index >= currentSize)
            {
                char **newWords = realloc(words, (index + 1) * sizeof(char *));
                if (!newWords)
                {
                    printf("No memory to allocate!");
                    return 1;
                }
                
                words = newWords;
                currentSize = index;
            }
            
            size_t tokenLength = strlen(token);
            words[index] = calloc(tokenLength + 1, sizeof(char));
            if (!words[index])
            {
                printf("No memory to allocate!");
                return 1;
            }
            
            strcpy(words[index], token);
            words[index][tokenLength] = '\0';
            index++;

            token = strtok(NULL, "<>");
        }
              
        if (words[index - 1][0] == '/' &&
                strcmp(words[0], &words[index - 1][1]) == 0)
        {
            words[0][0] = toupper(words[0][0]);
            printf("%s: %s\n", words[0], words[1]);
        }
        else
        {
            printf("Invalid format\n");
        }

        int i;
        for (i = 0; i < index; i++)
        {
            free(words[i]);
        }
        
        free(words);
        
        lineLength = getline(&line, &size, stdin);
    }
          
    free(line);
    
    return 0;
}