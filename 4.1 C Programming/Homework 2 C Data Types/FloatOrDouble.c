/* 
Problem 2. Float or Double?
Which of the following values can be assigned to a variable 
 * of type float and which to a variable of type double: 
 * 34.567839023, 12.345, 8923.1234857, 3456.091? Write a 
 * program to assign the numbers in variables and print 
 * them to ensure no precision is lost.
 */

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    double value1 = 34.567839023d;
    float value2 = 12.345f;
    double value3 = 8923.1234857d;
    float value4 = 3456.091f;
    
    printf("%.9f; %.3f; %.7f; %.3f;",value1,value2,value3,value4);
    return (EXIT_SUCCESS);
}

