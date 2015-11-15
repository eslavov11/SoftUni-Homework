#include <stdio.h>
#include <stdlib.h>

#define BUFFER_SIZE 4096

int main()
{
    FILE *srcImage = fopen("Problem 4 gotino_mace.jpg", "rb");
    FILE *newImage = fopen("Problem 4 cpy_gotino_mace.jpg","wb");
    if(!newImage || !srcImage)
    {
        printf("Error\n");
        return 1;
    }
    char buffer[BUFFER_SIZE];
    while(!feof(srcImage))
    {
        size_t readBytes = fread(buffer, 1, BUFFER_SIZE, srcImage);
        fwrite(buffer, 1, readBytes, newImage);
    }
    fclose(srcImage);
    fclose(newImage);
}
