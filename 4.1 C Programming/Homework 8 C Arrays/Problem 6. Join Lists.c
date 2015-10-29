#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void filling_array(int *array, int length);
int arr_contains(int *array, int arrLength, int num);
void filling_distinct_arr(int *resultArr, int *firstArr, int *secondArr,
            int resultArrLength, int firstArrLength, int secondArrLength);
void bubble_sort(int *array, int length);
void print_array(int *array, int length);
int distinct_count(int *firstArr, int *secondArr, 
                    int firstArrLength, int secondArrLength);

int main() 
{
    int firstArrLength, secondArrLength;
    if (scanf("%d %d", &firstArrLength, &secondArrLength) != 2)
    {
        printf("Invalid input!");
        return 1;
    }
    
    int firstArray[firstArrLength], secondArray[secondArrLength];
    filling_array(firstArray, firstArrLength);
    filling_array(secondArray, secondArrLength);
    int resultArrLenght = distinct_count(firstArray, secondArray,
                                            firstArrLength, secondArrLength);
    int resultArr[resultArrLenght];
    filling_distinct_arr(resultArr, firstArray, secondArray,
            resultArrLenght, firstArrLength, secondArrLength);
    bubble_sort(resultArr, resultArrLenght);
    print_array(resultArr, resultArrLenght);
    printf("\n");
    return 0;
}

void filling_array(int *array, int length)
{
    int i;
    for (i = 0; i < length; i++)
    {
        scanf("%d", &array[i]);
    }
}

int arr_contains(int *array, int arrLength, int num)
{
    int i, found = 0;
    for (i = 0; i < arrLength; i++)
    {
        if (array[i] == num)
        {
            found = 1;
            break;
        }
    }
    
    return found;
}

void filling_distinct_arr(int *resultArr, int *firstArr, int *secondArr,
            int resultArrLength, int firstArrLength, int secondArrLength)
{
    int i, j;
    resultArr[0] = firstArr[0];
    for (i = 1, j = 1; i < firstArrLength; i++)
    {
        if (!arr_contains(resultArr, i, firstArr[i]))
        {
            resultArr[j] = firstArr[i];
            j++;
        }
    }
    
    if (i == resultArrLength)
    {
        i--;
    }
    
    for (j = 0; j < secondArrLength; j++)
    {
        if (!arr_contains(resultArr, i, secondArr[j]))
        {
            resultArr[i] = secondArr[j];
            i++;
        }
    }
}

void bubble_sort(int *array, int length)
{
    int hasSwapped = 1;
    while (hasSwapped)
    {
        hasSwapped = 0;
        int i;
        for (i = 0; i < length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                int oldValue = array[i];
                array[i] = array[i + 1];
                array[i + 1] = oldValue;
                hasSwapped = 1;
            }
        }
    }
}

void print_array(int *array, int length)
{
    int i;
    for (i = 0; i < length; i++)
    {
        if (i < length - 1)
        {
            printf("%d, ", array[i]);
        }
        else
        {
            printf("%d", array[i]);
        }
    }
}

int distinct_count(int *firstArr, int *secondArr, 
                    int firstArrLength, int secondArrLength)
{
    int i,j, count = 1;
    int tempArrLength = firstArrLength + secondArrLength;
    int tempArr[tempArrLength];
    for (i = 0, j = 0; i < tempArrLength; i++)
    {
        if (i < firstArrLength)
        {
            tempArr[i] = firstArr[i];
        }
        else
        {
            tempArr[i] = secondArr[j];
            j++;
        }
    }
    
    for (i = 1; i < firstArrLength; i++)
    {
        if (!arr_contains(tempArr, i, firstArr[i]))
        {
            count++;
        }
    }
    
    for (j = 0; j < secondArrLength; j++)
    {
        if (!arr_contains(tempArr, i, secondArr[j]))
        {
            count++;
            i++;
        }
    }
      
    return count;
}