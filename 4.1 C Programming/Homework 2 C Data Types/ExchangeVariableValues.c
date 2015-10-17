

#include <stdio.h>
#include <stdlib.h>

/*
 */ 
int main(int argc, char** argv) {
    int a = 5;
    int b = 10;
    
    printf("Before a = %d, b = %d\n\n",a,b);
    
    int temp = a;
    a = b;
    b = temp;
    
    printf("After a = %d, b = %d\n",a,b);
    return (EXIT_SUCCESS);
}

