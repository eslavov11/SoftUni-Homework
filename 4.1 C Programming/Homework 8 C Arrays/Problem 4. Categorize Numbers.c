#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#define lengthArr(array) sizeof(array) / sizeof(array[0])


int count_of_zero_fractions(double* array, int length);
void print_array(double* array, int length);
double arr_min(double array[], int arrLength);
double arr_max(double array[], int arrLength);
double arr_average(double array[], int arrLength);
double arr_sum(double array[], int arrLength);

int main() 
{
    int n;
    if (scanf("%d", &n) != 1)
    {
        printf("Invalid input!");
        return 1;
    }
    
    double numbers[n];
    int i;
    for (i = 0; i < n; i++)
    {
        scanf("%lf", &numbers[i]);
    }
    
    int length = lengthArr(numbers);
    int zeroFraction = count_of_zero_fractions(numbers, length);
    int notZeroFraction = length - zeroFraction;
    double fractioned[notZeroFraction];
    double zeroFractioned[zeroFraction];
    int j= 0, k = 0;
    for (i = 0; i < n; i++)
    {
        if (fmod(numbers[i], 1) == 0)
        {
            zeroFractioned[j] = numbers[i];
            j++;
        }
        else
        {
            fractioned[k] = numbers[i];
            k++;
        }
    }
    double fractionedMin = arr_min(fractioned, notZeroFraction);
    double zeroFractionedMin = arr_min(zeroFractioned, zeroFraction);
    
    double fractionedMax = arr_max(fractioned, notZeroFraction);
    double zeroFractionedMax = arr_max(zeroFractioned, zeroFraction);
    
    double fractionedSum = arr_sum(fractioned, notZeroFraction);
    double zeroFractionedSum = arr_sum(zeroFractioned, zeroFraction);
    
    double fractionedAvg = arr_average(fractioned, notZeroFraction);
    double zeroFractionedAvg = arr_average(zeroFractioned, zeroFraction);
    
    printf("\n");
    print_array(fractioned, notZeroFraction);
    printf(" -> min: %.3lf", fractionedMin);
    printf(", max: %.3lf", fractionedMax);
    printf(", sum: %.3lf", fractionedSum);
    printf(", avg: %.2lf", fractionedAvg);
    printf("\n");
    print_array(zeroFractioned, zeroFraction);
    printf(" -> min: %.lf", zeroFractionedMin);
    printf(", max: %.lf", zeroFractionedMax);
    printf(", sum: %.lf", zeroFractionedSum);
    printf(", avg: %.2lf", zeroFractionedAvg);
    
    printf("\n");
    
    return 0;
}

int count_of_zero_fractions(double* array, int length)
{
    int i, zeroFractionCount = 0;
    for (i = 0; i < length; i++)
    {
        if (fmod(array[i], 1) == 0)
        {
            zeroFractionCount++;
        }
    }
    
    return zeroFractionCount;
}

void print_array(double* array, int length)
{
    int i;
    printf("[");
    for (i = 0; i < length; i++)
    {
        if (i < length - 1)
        {
            printf("%.3lf, ", array[i]);
        }
        else
        {
            printf("%.3lf", array[i]);
        }
    }
    
    printf("]");
}

double arr_min(double array[], int arrLength)
{
    double min = array[0];
    int i;
    for (i = 1; i < arrLength; i++)
    {
        if (min > array[i])
        {
            min = array[i];
        }
    }
    
    return min;
}

double arr_max(double array[], int arrLength)
{
    double max = array[0];
    int i;
    for (i = 1; i < arrLength; i++)
    {
        if (max < array[i])
        {
            max = array[i];
        }
    }
    
    return max;
}

double arr_average(double array[], int arrLength)
{
    double sum = arr_sum(array, arrLength);
    double average = sum / arrLength;
    
    return average;
}

double arr_sum(double array[], int arrLength)
{
    int i;
    double sum = 0;
    for (i = 0; i < arrLength; i++)
    {
        sum += array[i];
    }
    
    return sum;
}