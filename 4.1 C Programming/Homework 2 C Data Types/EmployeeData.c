/* 
 * Problem 8. Employee Data
A marketing company wants to keep record of its employees. 
 * Each record would have the following characteristics:
 First name
 Last name
 Age (0...100)
 Gender (m or f)
 Personal ID number (e.g. 8306112507)
 Unique employee number (27560000…27569999)
 */

#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

/*
 */ 
int main(int argc, char** argv) {
    char *firstName = "Artur";
    char *lastName = "Chobanski";
    char age = 44;
    char gender = 'm';
    unsigned long long personalIDNumber = 8306112507l;
    int uniqueEmployeeNumber = 27569999;
    
    printf("First Name: %s\n", firstName);
    printf("Last Name: %s\n", lastName);
    printf("Age: %d\n", age);
    printf("Gender: %c\n", gender);
    printf("Personal ID Number: %llu\n", personalIDNumber);
    printf("Unique Employee Number: %d\n", uniqueEmployeeNumber);
    
    return (EXIT_SUCCESS);
}

