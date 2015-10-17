/* 
 * Problem 1. Declare Variables
Declare five variables choosing for each of them the most appropriate
 *  of the types char, short, unsigned short, int, unsigned int, long, 
 * unsigned long to represent the following values: 52130, 8942492113, 
 * -115, 4825932, 97, -10000, -35982859328592389. Choose a large enough 
 * type for each number to ensure it will fit in it.
 */

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    unsigned short value1 = 52130;
    long value2 = 8942492113l;
    char value3 = -115;
    int value4 = 4825932;
    char value5 = 97;
    short value6 = -10000;
    long long value7 = -35982859328592389l;
    return 0;
}

