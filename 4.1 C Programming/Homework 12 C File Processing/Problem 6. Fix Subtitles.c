#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>

char *read_line(FILE *);
void die(const char *);

struct time
{
    size_t hours;
    size_t minutes;
    size_t seconds;
    size_t milliseconds;
};

void process_times(struct time *, char *, size_t);



int main()
{
    size_t offset;
    scanf("%lu", &offset);
    
    FILE *srcSub = fopen("srcSub.srt", "r");
    if(!srcSub) die(NULL);
    FILE *destSub = fopen("destSub.srt", "w");
    if(!destSub) die(NULL);
    
    while(!feof(srcSub))
    {
        char *line = read_line(srcSub);
        if(!strstr(line, "-->"))
        {
            char *normalLine = malloc(strlen(line)+2);
            strcpy(normalLine, line);
            normalLine[strlen(line)] = '\n';
            normalLine[strlen(line)+1] = '\0';
            fwrite(normalLine, 1, strlen(normalLine), destSub);
        }
        else
        {
            char *start = strtok(line," --> ");
            char *end = strtok(NULL, " -- >");
            struct time t1,t2;
            
            process_times(&t1, start, offset);
            process_times(&t2, end, offset);
            
            char result[30];
            sprintf(result,
                    "%02lu:%02lu:%02lu,%03lu --> %02lu:%02lu:%02lu,%03lu\n",
                    t1.hours, t1.minutes, t1.seconds, t1.milliseconds,
                    t2.hours, t2.minutes, t2.seconds, t2.milliseconds);
            fwrite(result, 1, strlen(result), destSub);
            
        }
        //free(line);
    }
    
    
    fclose(srcSub);
    fclose(destSub);
    return 0;
}

void die(const char *msg)
{
    if(errno)
    {
        perror(msg);
    }
    else
    {
        printf("%s\n", msg);
    }
    exit(1);
}

char *read_line(FILE *file)
{
    int initialSize = 4;
    char *readline = malloc(initialSize);
    int index = 0;
    char ch = fgetc(file);//getchar();
    while (ch != '\n' && ch != EOF)
    {
        if (index == initialSize - 1)
        {
            char *newReadLine = realloc(readline, initialSize * 2);
            if (!newReadLine)
            {
                printf("Not enough memory!");
                exit(1);
            }
            
            readline = newReadLine;
            initialSize *= 2;
        }
        
        *(readline + index) = ch;
        index++;
        ch = fgetc(file);
    }
    
    *(readline + index) = '\0';
    
    return readline;
}

void process_times(struct time *t, char *token, size_t offset)
{
    int hours = offset  / 10000000;
    int minutes = ((offset / 100000) % 100) % 60;
    int seconds = ((offset / 1000) % 1000) % 60;
    int milliseconds = offset % 1000;
 
    char *time2 = strtok(token, " ,:");
    
    t->hours = atoi(time2) + hours;
    t->minutes = atoi(strtok(NULL, " ,:")) + minutes;
    t->seconds = atoi(strtok(NULL, " ,:")) + seconds;
    t->milliseconds = atoi(strtok(NULL, " ,:")) + milliseconds;
    
    t->hours += t->minutes / 60;
    t->minutes %= 60;
    t->minutes += t->seconds / 60;
    t->seconds %= 60;
    t->seconds  += t->milliseconds / 1000;
    t->milliseconds %= 1000;
}