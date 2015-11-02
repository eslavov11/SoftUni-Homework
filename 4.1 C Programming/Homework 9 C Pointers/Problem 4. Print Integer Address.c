#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int n;
    scanf("%d", &n);
    printf("Address in hexacedimal format: 0x%p\n", &n);
    return 0;
}

