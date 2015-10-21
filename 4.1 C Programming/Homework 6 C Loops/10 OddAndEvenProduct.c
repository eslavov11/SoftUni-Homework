#include <stdio.h>
#include <stdlib.h>

int main() 
{
    int i,j,n,evenProduct=1,oddProduct=1;
    printf("Numbers count = ");
    scanf("%d", &n);
    n=n*2-1;
    char num[n];
    printf("Enter numbers: ");
    fgets(num, n, stdin);
    for (i = 0, j=0; i < n; i+=2,j++) 
    {
        if (j%2==0)
        {
            evenProduct*=(num[i]-48);
        }
        else oddProduct*=(num[i]-48);
    }
    if (oddProduct == evenProduct) 
    {
        printf("yes\nproduct = %d\n", oddProduct);
    }
    else
    {
        printf("no\nodd_product = %d\neven_product = %d\n", oddProduct, evenProduct);
    }
    
    return 0;
}

