#include <stdio.h>
#include <stdlib.h>

int main(int argc, char** argv) 
{
    int score;
    scanf("%d",&score);
    if (score > 0 && score < 4) 
    {
        printf("%d\n", score*10);
    }
    else if (score > 3 && score < 7) 
    {
        printf("%d\n", score*100);
    }
    else if (score > 6 && score < 10) 
    {
        printf("%d\n", score*1000);
    }
    else printf("invalid score\n");

            
    return (EXIT_SUCCESS);
}
//If the score is between 1 and 3, the program multiplies it by 10.
// If the score is between 4 and 6, the program multiplies it by 100.
// If the score is between 7 and 9, the program multiplies it by 1000.
// If the score is 0 or more than 9, the program prints “invalid score”.
