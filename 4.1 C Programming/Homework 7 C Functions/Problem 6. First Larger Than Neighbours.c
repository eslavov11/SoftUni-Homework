#include <stdio.h>
#include <stdlib.h>
int larger_element_index(int arr[]);

int main()
{
    int arr[] = {5,4,3,8,14,10};
    printf("%d\n", larger_element_index(arr));
    return 0;
}

int larger_element_index(int arr[])
{
    int i, elementsCount = 6;;
    for (i = 1; i < elementsCount; i++) 
    {
        if (arr[i] > arr[i-1] && arr[i] > arr[i+1]) 
        {
            return i;
        }
    }

    return -1;
}

