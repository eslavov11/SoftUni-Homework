#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    int arr[] = {1,3,5,7,9,11,13};
    int i, *index = arr+sizeof(arr)/sizeof(int)-1;
    for (i = 0; i < sizeof(arr)/sizeof(int); i++,index--) 
    {
        printf("%d ", *index);
    }
    printf("\n");
    return 0;
}

