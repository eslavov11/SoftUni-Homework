#include <stdio.h>
#include <string.h>

#define BUFFER_SIZE 30
int main() 
{
    char line[BUFFER_SIZE];
    fgets(line, BUFFER_SIZE, stdin);
    int oddProduct = 1, evenProduct = 1, isOdd = 1;
    char* token = strtok(line, " ");
    while (token != NULL)
    {
        int num = atoi(token);
        
        if (isOdd)
        {
            oddProduct *= num;
        }
        else
        {
            evenProduct *= num; 
        }
        
        isOdd = !isOdd;
        
        token = strtok(NULL, " ");
    }
    
    if (oddProduct == evenProduct)
    {
        printf("yes\n%d\n", oddProduct);
    }
    else
    {
        printf("no\nodd_product = %d\neven_product = %d\n",
                oddProduct, evenProduct);
    }
    
    return 0;
}