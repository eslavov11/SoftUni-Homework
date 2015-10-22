#include <stdio.h>
#include <stdlib.h>
#define INT_MAX 214752317
#define INT_MIN -214752318
int main() 
{   
    int i,n,count = 0,max = INT_MIN, min = INT_MAX;
    double sum = 0.0;
    scanf("%d", &n);
    for (i = 1; i <= n; i++) 
    {
        int temp;
        scanf("%d", &temp);
        if (temp>max) 
        {
            max = temp;
        }   
        if (temp<min) 
        {
            min = temp;
        }  
        sum+=temp;
        count++;
    }
    printf("Min: %d.00\n",min);
    printf("Max: %d.00\n",max);
    printf("Sum: %d.00\n",sum);
    double avg = 0.0 + (sum/count);
    printf("Average: %.2f\n",avg);
    return 0;
}

