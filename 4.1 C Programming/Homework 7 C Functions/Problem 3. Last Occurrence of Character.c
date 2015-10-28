#include <stdio.h>
#include <stdlib.h>
int last_occurance(char *str, char ch);

int main()
{
    char str[10];
    char ch;
    printf("Enter the char: ");
    scanf("%c", &ch);
    printf("Enter the string: ");
    scanf("%9s", str);
    printf("%d\n", last_occurance(str, ch));
    return 0;
}

int last_occurance(char *str, char ch)
{
    int i;
    for (i = 8; i >= 0; i--) 
    {
        if (str[i] == ch)
        {
            return i;
        }
    }
    return -1;

    return 0;
}

