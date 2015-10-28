#include <stdlib.h>
#include <string.h>
#include <math.h>
#include "array_manipulations.h"

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

void arr_clear(double array[], int arrLength)
{
    memset(array, 0, sizeof(array) * arrLength);
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
    double sum;
    for (i = 0; i < arrLength; i++)
    {
        sum += array[i];
    }
    
    return sum;
}

int arr_contains(double array[], int arrLength, double num)
{
    int i, found = 0;
    for (i = 0; i < arrLength; i++)
    {
        if (compare_floats(array[i], num))
        {
            found = 1;
        }
    }
    
    return found;
}

int compare_floats(double firstNum, double secondNum)
{
    double eps = 0.000001;
    double diff = fabs(firstNum - secondNum);
    if (diff >= eps)
    {
        return 0;
    }
        
    return 1;

}

double* arr_merge(double firstArray[], double secondArray[],
                    int firstArrLength, int secondArrLength)
{
    int size = firstArrLength + secondArrLength;
    double* mergedArray = malloc(size);
    int i, j;
    for (i = 0; i < firstArrLength; i++)
    {
        mergedArray[i] = firstArray[i];
    }
    
    for (i = firstArrLength, j = 0; i < size; i++, j++)
    {
        mergedArray[i] = secondArray[j];
    }
    
    return mergedArray;
}

void print_array(double array[], int arrLength)
{
    int i;
    for (i = 0; i < arrLength; i++)
    {
        printf("%.3lf ", array[i]);
    }
}