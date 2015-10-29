#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int n;
    scanf("%d", &n);
    int arr[n][n],i,j;
    for (i = 0; i < n; i++) {
        for (j = 0; j < i+1; j++) {
            scanf("%d ", &arr[i][j]);
        }
    }
    free(arr);
    for (i = 0; i < n; i++) {
        for (j = 0; j < i+1; j++) {
            printf("%d ", arr[i][j]);
        }
        printf("\n");
    }

    return 0;
}

