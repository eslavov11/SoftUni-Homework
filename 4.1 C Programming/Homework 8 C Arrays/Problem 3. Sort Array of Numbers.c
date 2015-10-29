#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>
int main() 
{
    int n;
    scanf("%d", &n);
    int arr[n],i;
    for (i = 0; i < n; i++) {
        scanf("%d\n", &arr[i]);
    }
    
    sort(arr, n);
    
    for (i = 0; i < n-1; i++) {
        printf("%d, ", arr[i]);
    }
    printf("%d", arr[i]);
    return 0;
}

void sort(int arr[], int n)
{
    bool isNotSorted = true;
    while (isNotSorted) {
        isNotSorted = false;
        int i;
        for (i = 0; i < n-1; i++) {
             if (arr[i] > arr[i+1]) {
                 isNotSorted = true;
                 int temp = arr[i+1];
                 arr[i+1] = arr[i];
                 arr[i] = temp;
             }
         }
    }

    
}
