/* 
 Problem 9. Bank Account Data
A bank account has a holder name 
 * (first name, middle name and last name), available amount of
 *  money (balance), bank name, IBAN and 3 credit card numbers 
 * associated with the account. Declare the variables needed to 
 * keep the information for a single bank account using the 
 * appropriate data types and descriptive names.
 */

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) {
    char firstName[] = "Ivan";
    char secondName[] = "Todorov";
    char lastName[] = "Selqmsuza";
    unsigned long balance = 3000000000;
    char *bankName = "KTB";
    char *IBAN = "BG80 BNBG 9661 1020 3456 78";
    unsigned long creditCardNumberOne = 347058003800265l;
    unsigned long creditCardNumberTwo = 546432103800265l;
    unsigned long creditCardNumberThree = 365445003800265l;
    
    return (EXIT_SUCCESS);
}

