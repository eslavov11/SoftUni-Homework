#include <stdio.h>

/*
 * 
 */
int main() 
{
    int n;
    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input");
        return 1;
    }
    else
    {
        long double nFactorial = 1;
        long double twoNFactorial = 1;
        long double nPlusOne = 1;
        long catalan = 1;
        
        if (n >= 0)
        {
            int i, j;
            for (i = n, j = 2 * n; i >= 1; i--, j--)
            {
                nFactorial *= i;
                twoNFactorial *= j;
                nPlusOne = (n + 1) * i;
                catalan = twoNFactorial / (nPlusOne * nFactorial);
            }
            
            printf("Catalan(%.d) --> %d\n", n, catalan);
        }
        else
        {
            printf("The number should be greater than 0 and less than 100\n");
        }
    }
    
    return 0;
}