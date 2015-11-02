#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void swap(int *first, int *second)
{
    int temp = *first;
    *first = *second;
    *second = temp;
}

int main()
{
    int a,b;
    scanf("%d", &a);
    scanf("%d", &b);
    printf("Before: %d %d\n", a,b);
    swap(&a,&b);
    printf("After: %d %d\n", a,b);
    return 0;
}

