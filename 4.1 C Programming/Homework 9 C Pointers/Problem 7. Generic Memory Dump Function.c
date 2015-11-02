#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/*
 * Write a function that takes a pointer of any type, size of bytes n and row 
 * length len. The function should print a total of n bytes, starting from the 
 * address of the pointer. The output should be formatted into several rows, 
 * each holding len bytes. At the start of each row, print the address of the 
 * initial byte.
 * Note: The addresses may vary.
 */

void mem_dump(void *array, size_t size, int rowLength);

int main() 
{
    char *text = "I love to break free";
    int array[] = { 7, 3, 2, 10, -5};
    size_t size = sizeof(array) / sizeof(int);
    
    mem_dump(text, strlen(text) + 1, 5);
    printf("\n\n");
    mem_dump(array, size * sizeof(int), 4);

    return 0;
}

void mem_dump(void *array, size_t size, int rowLength)
{
    char *arrayPtr = array;
    int i;
    for (i = 0; i < size; i++)
    {
        if (i == 0)
        {
            printf("%p    ", &arrayPtr[i]);
        }
        else if (i % rowLength == 0)
        {
            printf("\n%p    ", &arrayPtr[i]);
        }

        printf("%02hhx ", *arrayPtr);
        arrayPtr++;
    }
}