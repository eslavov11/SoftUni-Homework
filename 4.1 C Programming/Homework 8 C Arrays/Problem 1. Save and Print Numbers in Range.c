#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int n;
    scanf("%d", &n);
    int arr[n],i;
    for (i = 0; i < n-1; i++) {
        scanf("%d ", &arr[i]);
    }
    scanf("%d", &arr[n-1]);
    for (i = 0; i < n-1; i++) {
        printf("%d, ", arr[i]);
    }
    printf("%d\n", arr[n-1]);
    return 0;
}

