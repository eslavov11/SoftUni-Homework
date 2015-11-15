#include <stdio.h>
#include <stdlib.h>
#include <errno.h>

#define BUFFER_SIZE 4096
#define FILE_PATH_LENGTH 64

void die(const char *msg);
void slice(const char *sourceFile, const char *destinationFile, size_t parts);
void assemble(const char **parts, const char *destinationDirectory);

int main(int argc, char **argv)
{
    if (argc < 4) 
    {
        die("Usage: ./prog <src-file> <destination path> <parts count>");
    }
    
    size_t partsCount = atoi(argv[3]);
    const char *srcPath = argv[1];
    const char *destPath = argv[2];
    
//    size_t partsCount = 3;
//    const char *srcPath = "test.txt";
//    const char *destPath = "";
    
    slice(srcPath, destPath, partsCount);
    
    char **partNames = calloc(partsCount, sizeof(char *));
    size_t i;
    for(i = 0; i < partsCount; i++)
    {
        partNames[i] = calloc(11 + FILE_PATH_LENGTH, sizeof(char));
        
        sprintf(partNames[i],
                "%sPart-%d.%c%c%c",
                destPath,
                i+1,
                srcPath[strlen(srcPath)-3],
                srcPath[strlen(srcPath)-2],
                srcPath[strlen(srcPath)-1]);
    }
    
    assemble(partNames, destPath);
    
    return 0;
}

void assemble(const char **parts, const char *destinationDirectory)
{
    char destFileName[FILE_PATH_LENGTH];
    sprintf(destFileName,
                "%smerged.%c%c%c",
                destinationDirectory,
                parts[0][strlen(parts[0])-3],
                parts[0][strlen(parts[0])-2],
                parts[0][strlen(parts[0])-1]); //file format
    
    FILE *dest = fopen(destFileName,"wb");
    if(!dest) die(NULL);
    printf("\nParts count: %d\n", strlen(parts));
    
    size_t i;
    for(i = 0; i< strlen(parts); i++)
    {
        FILE *srcPart = fopen(parts[i],"rb");
        if(!srcPart) die(NULL);
        char buffer[BUFFER_SIZE];
        while(!feof(srcPart))
        {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, srcPart);
            fwrite(buffer, 1, readBytes, dest);
        }
        fclose(srcPart);
    }
    fclose(dest);
}

void slice(const char *sourceFile, const char *destinationFile, size_t parts)
{
    FILE *src = fopen(sourceFile, "rb");
    if(!src) die(NULL);
    
    fseek(src, 0, SEEK_END);
    size_t totalBytes = ftell(src);
    fseek(src, 0, SEEK_SET);
    
    size_t partSize = totalBytes / parts + 1;
    printf("\nLength of source file: %d\nEach part size: %d\n", strlen(sourceFile), partSize);
    size_t i;
    for(i = 0; i < parts; i++)
    {
        char currPart[FILE_PATH_LENGTH];
        sprintf(currPart,
                "%sPart-%d.%c%c%c",
                destinationFile,
                i+1,
                sourceFile[strlen(sourceFile)-3],
                sourceFile[strlen(sourceFile)-2],
                sourceFile[strlen(sourceFile)-1]); //file format
        
        FILE *dest = fopen(currPart, "wb");
        printf("File name: %s\n", currPart);
        size_t writtenBytes = 0;
        char buffer[BUFFER_SIZE];
        while(!feof(src) && writtenBytes<=partSize)
        {
            size_t readBytes = fread(buffer, 1, BUFFER_SIZE, src);
            fwrite(buffer, 1, readBytes, dest);
            writtenBytes+= readBytes;
        }
        fclose(dest);
        printf("Written bytes: %d\n", writtenBytes);
    }
    fclose(src);   
}

void die(const char *msg)
{
    if(errno)
    {
        perror(msg);
    }
    else
    {
        printf("%s\n", msg);
    }
    exit(1);
}
