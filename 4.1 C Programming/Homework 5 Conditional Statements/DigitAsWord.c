#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int n;
    scanf("%d", &n);
    switch (n) {
        case 0:
            printf("zero\n");
            break;
            case 1:
            printf("one\n");
            break;
            case 2:
            printf("two\n");
            break;
            case 3:
            printf("three\n");
            break;
            case 4:
            printf("four\n");
            break;
            case 5:
            printf("five\n");
            break;
            case 6:
            printf("six\n");
            break;
            case 7:
            printf("seven\n");
            break;
            case 8:
            printf("eight\n");
            break;
            case 9:
            printf("nine\n");
            break;
        default:
            printf("Not a digit\n");
            break;
    }
    return (EXIT_SUCCESS);
}

