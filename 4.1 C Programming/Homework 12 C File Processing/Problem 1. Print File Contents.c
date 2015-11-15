#include <stdio.h>
#include <stdlib.h>

#define BUFFER_LENGTH 4096

int main()
{
    FILE *file = fopen("Problem 1 text.txt", "r");
    if (file)
    {
        char buffer[BUFFER_LENGTH+1];
        while(!feof(file))
        {
            size_t readBytes = fread(buffer, 1, BUFFER_LENGTH, file);
            buffer[readBytes] = '\0';
            printf("%s", buffer);
        }
        printf("\n");
    }
    fclose(file);
    return 0;
}

