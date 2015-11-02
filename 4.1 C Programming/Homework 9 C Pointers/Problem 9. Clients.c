#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

struct Client
{
    char *name;
    unsigned int age;
    long double balance;
};

void bubble_sort_clients(struct Client *clients, 
        int count, 
        int (*compare)(struct Client *, struct Client *));

void swap(void *first, void *second, size_t size);

int compare_name(struct Client *first, struct Client *second);

int compare_age(struct Client *first, struct Client *second);

int compare_balance(struct Client *first, struct Client *second);

void print_struct(struct Client *clients, int count);

int compare_doubles(long double first, long double second);

int main() 
{
    struct Client clients[] = {
        {.name = "Pesho", .age = 23, .balance = 15.69},
        {.name = "Gosho", .age = 28, .balance = 123.45}
    };    

    int clientsCount = 2;
    printf("Struct before any sorting:\n");
    print_struct(clients, clientsCount);
    
    printf("After sorting by Name:\n");
    bubble_sort_clients(clients, clientsCount, &compare_name);
    print_struct(clients, clientsCount);
    
    printf("After sorting by Balance:\n");
    bubble_sort_clients(clients, clientsCount, &compare_balance);
    print_struct(clients, clientsCount);
    
    printf("After sorting by Age:\n");
    bubble_sort_clients(clients, clientsCount, &compare_age);
    print_struct(clients, clientsCount);
    
    return 0;
}

void bubble_sort_clients(struct Client *clients, 
        int count, 
        int (*compare)(struct Client *, struct Client *))
{
    int hasSwaped = 1;
    while (hasSwaped)
    {
        hasSwaped = 0;
        int i;
        for (i = 0; i < count - 1; i++)
            {
            if (compare(&clients[i], &clients[i + 1]))
            {
                swap(&clients[i].age, 
                        &clients[i + 1].age, 
                        sizeof(int));
                swap(&clients[i].balance, 
                        &clients[i + 1].balance, 
                        sizeof(long double));
                swap(&clients[i].name, 
                        &clients[i + 1].name,
                        sizeof(char));
                hasSwaped = 1;
            }
        }
    }
}

int compare_name(struct Client *first, struct Client *second)
{
    int diff = strcmp(first->name, second->name);
    if (diff >= 0)
    {
        return 1;
    }
    
    return 0;
}

int compare_age(struct Client *first, struct Client *second)
{
    return first->age > second->age;
}

int compare_balance(struct Client *first, struct Client *second)
{
    int bigger = compare_doubles(first->balance, second->balance);
    return !bigger;
}

void swap(void *first, void *second, size_t size)
{
    char *firstPtr = first;
    char *secondPtr = second;
    int i;
    for (i = 0; i < size; i++)
    {
        char tempByte = firstPtr[i];
        firstPtr[i] = secondPtr[i];
        secondPtr[i] = tempByte;
    }
}

void print_struct(struct Client *clients, int count)
{
    int i;
    for (i = 0; i < count; i++)
    {
        printf("Name: %s -> Age: %d -> Balance: %Lf\n", 
                clients[i].name, clients[i].age, clients[i].balance);
    }
}

int compare_doubles(long double first, long double second)
{
    double eps = 0.000001;
    
    double diff = fabs(first - second);
    if (diff >= eps)
    {
        return 1;
    }

    return 0;
}