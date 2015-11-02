#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int arr[] = {-300,5,5000,9,10,10000000};
    int i, *index = arr;
    for (i = 0; i < sizeof(arr)/sizeof(int); i++,index++) {
        printf("%d ", *index);
    }
    printf("\n");
    
    return 0;
}

