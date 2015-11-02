#include <stdio.h>
#include <stdlib.h>

void swap(void *first, void *second, size_t size);

int main() 
{
    char letter = 'B', symbol = '+';
    swap(&letter, &symbol, sizeof(char));
    printf("%c %c", letter, symbol);
    printf("\n");
    
    int a = 10, b = 6;
    swap(&a, &b, sizeof(int));
    printf("%d %d", a, b);
    printf("\n");
    
    double d = 3.14, f = 1.23567;
    swap(&d, &f, sizeof(double));
    printf("%.2lf %.2lf", d, f); 
    // 1.234567 is printed as 1.24, because printf raunding it.
    printf("\n");
    
    return 0;
}

void swap(void *first, void *second, size_t size)
{
    char *firstPtr = first;
    char *secondPtr = second;
    int i;
    for (i = 0; i < size; i++)
    {
        char tempByte = firstPtr[i];
        firstPtr[i] = secondPtr[i];
        secondPtr[i] = tempByte;
    }
}