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
    int numberToCheck;
    scanf("%d", &numberToCheck);
    for (i = 0; i < n; i++) {
        if (arr[i] == numberToCheck) {
            printf("yes\n");
            return 0;
        }
    }
    printf("no\n");
    return 0;
}

