#include <stdio.h>
#include <string.h>
#define STRING_SIZE 30

int main() 
{
    char companyName[STRING_SIZE],
            companyAddress[STRING_SIZE],
            companyPhoneNumber[STRING_SIZE],
            companyFaxNumber[STRING_SIZE],
            companyWebSite[STRING_SIZE],
            managerFirstName[STRING_SIZE],
            managerLastName[STRING_SIZE],
            managerPhoneNumber[STRING_SIZE],
            managerAge[STRING_SIZE];
    
    printf("Company name: ");
    fgets(companyName, STRING_SIZE, stdin);
    printf("Company address: ");
    fgets(companyAddress, STRING_SIZE, stdin);
    printf("Phone number: ");
    fgets(companyPhoneNumber, STRING_SIZE, stdin);
    printf("Fax number: ");
    fgets(companyFaxNumber, STRING_SIZE, stdin);
    if (companyFaxNumber[0] == '\n')
    {
        strncpy(companyFaxNumber, "(no fax)\n", 9);
    }
    
    printf("Web site: ");
    fgets(companyWebSite, STRING_SIZE, stdin);
    printf("Manager first name: ");
    fgets(managerFirstName, STRING_SIZE, stdin);
    size_t firstNameLength = strlen(managerFirstName) - 1;
    if (managerFirstName[firstNameLength] == '\n')
    {
        managerFirstName[firstNameLength] = '\0';
    }
    
    printf("Manager last name: ");
    fgets(managerLastName, STRING_SIZE, stdin);
    size_t lastNameLength = strlen(managerLastName) - 1;
    if (managerLastName[lastNameLength] == '\n')
    {
        managerLastName[lastNameLength] = '\0';
    }
    
    printf("Manager age: ");
    fgets(managerAge, STRING_SIZE, stdin);
    size_t ageLength = strlen(managerAge) - 1;
    if (managerAge[ageLength] == '\n')
    {
        managerAge[ageLength] = '\0';
    }
    
    printf("Manager phone: ");
    fgets(managerPhoneNumber, STRING_SIZE, stdin);   
    size_t phoneLength = strlen(managerPhoneNumber) - 1;
    if (managerPhoneNumber[phoneLength] == '\n')
    {
        managerPhoneNumber[phoneLength] = '\0';
    }
    
    printf("%sAddress: %sTel. %sFax: %sWeb site: %sManager: %s %s (age: %s, tel. %s)\n",
            companyName,
            companyAddress,
            companyPhoneNumber,
            companyFaxNumber,
            companyWebSite,
            managerFirstName,
            managerLastName,
            managerAge,
            managerPhoneNumber);    
    
    return 0;
}