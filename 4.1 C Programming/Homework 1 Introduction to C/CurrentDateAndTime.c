#include <time.h>
#include <stdio.h>

int main(void)
{
    time_t mytime;
    mytime = time(NULL);
    printf(ctime(&mytime));

    return 0;
}