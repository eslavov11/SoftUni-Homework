#include <errno.h>
#include <limits.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>

//reads the intire line
char *read_line()
{
    int initialSize = 4;
    char *readline = malloc(initialSize);
    int index = 0;
    char ch = getchar();
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
        ch = getchar();
    }
    
    *(readline + index) = '\0';
    
    return readline;
}

//reverses string
char *string_reverse(char *input)
{
    size_t stringLength= strlen(input);
    char *reversed = calloc(stringLength + 1, sizeof(char));
    if (!reversed)
    {
        printf("Cannot allocate enough memory!");
        exit(1);
    }
    
    int i, j;
    for (i = stringLength - 1, j = 0; i >= 0; i--, j++)
    {
        reversed[j] = input[i];
    }
    
    reversed[j] = '\0';
    
    return reversed;
}

//pad string right with chars
char *pad_right(char *input, char paddingChar, int totalStringSize)
{
    //doesnt work with big values over 40
    size_t stringLength= strlen(input);
    
    char *cpy = malloc(totalStringSize+1);
    
    if(stringLength<totalStringSize)
    {
        strcpy(cpy,input);
        int i;
        for (i = stringLength; i < totalStringSize; i++) 
        {
            cpy[i] = paddingChar;
        }
        cpy[totalStringSize] = '\0';
        strcpy(input,cpy);
    }
    
    return input;
}

//pad string left with chars
char *pad_left(char *input, char paddingChar, int totalStringSize)
{
    //doesnt work with big values over 40
    size_t stringLength= strlen(input);
    
    char *cpy = malloc(totalStringSize+1);
    
    if(stringLength<totalStringSize)
    {
        strcpy(cpy,input);
        int i,j;
        for (i = 0; i < totalStringSize-stringLength; i++) 
        {
            cpy[i] = paddingChar;
        }
        for (i = totalStringSize-stringLength,j=0; i < totalStringSize; i++) {
            cpy[i] = input[j++];
        }

        cpy[totalStringSize] = '\0';
        strcpy(input,cpy);
    }
    
    return input;
}

//removes equal consecutive chars ex. aaabb -> ab
char *remove_equal_consecutive_chars(char *input)
{
    size_t stringLength= strlen(input);
    
    char *cpy = malloc(stringLength);
    cpy[0] = input[0];
    int i,index=0;
    for (i = 0; i < stringLength; i++) 
    {
        if(input[i] != input[i-1])
        {
            cpy[index] = input[i];
            index++;
        }
    }
    cpy[index] = '\0';
    strcpy(input,cpy);
        
    return input;
}

int pow_ints(int a, int b)
{
    int i,result=1;
    for (i = 0; i < b; i++) {
        result*=a;
    }
    return result;
}

int countSubstringOccurances(const char *string, const char *substr)
{
    int count = 0;
    int i,j,subIn,inCount;
    for (i = 0; i < strlen(string); i++) {
        for (j = i,subIn=0, inCount = 0; j < i + strlen(substr); j++) {
            if(string[j] == substr[subIn++])
            {
                inCount++;
            }
        }
        if(inCount == strlen(substr))
        {
            count++;
        }

    }

int
has_text_characters (char *string)
{
  int result = 0;

  int byte_index;
  for (byte_index = 0;
       string[byte_index];
       ++byte_index)
    {
      if ((unsigned char) string[byte_index] > ' ')
        {
          result = 1;
          break;
        }
    }

  return result;
}


int
delete_trailing_whitespace (char *string, int len)
{
  int index = len;

  while (index--)
    {
      if ((unsigned char) string[index] > ' ')
        {
          break;
        }
    }

  int new_len = index + 1;
  string[new_len] = 0;

  return new_len;
}


char
input_char (void)
{
  int result = getc (stdin);

  if (result == EOF)
    {
      fprintf (stderr, "error: No input given\n");
      exit (1);
    }
  else if (result <= ' ')
    {
      fprintf (stderr, "error: Invalid input given\n");
      exit (1);
    }

  while (1)
    {
      int trailing_input = getc (stdin);
      if (trailing_input == EOF || trailing_input == '\n')
        {
          break;
        }
    }

  return (char) result;
}


void
input_string (char *buffer, int buffer_size)
{
  if (!(fgets (buffer, buffer_size, stdin)))
    {
      fprintf (stderr, "error: No input given\n");
      exit (1);
    }
}


long
input_long_int (void)
{
  char input_buffer[4096];
  input_string (input_buffer, sizeof (input_buffer));

  char *input_end;
  errno = 0;
  long result = strtol (input_buffer, &input_end, 10);

  if (errno || input_end == input_buffer || has_text_characters (input_end))
    {
      fprintf (stderr, "error: Invalid integer given\n");
      exit (1);
    }

  return result;
}


int
input_int (void)
{
  long long_num = input_long_int();

  if (long_num > INT_MAX || long_num < INT_MIN)
    {
      fprintf (stderr, "error: Integer number is out of range\n");
      exit (1);
    }

  int result = (int) long_num;

  return result;
}


unsigned int
input_uint (void)
{
  long long_num = input_long_int();

  if (long_num > UINT_MAX)
    {
      fprintf (stderr, "error: Integer number is out of range\n");
      exit (1);
    }

  unsigned int result = (unsigned int) long_num;

  return result;
}


double
input_double (void)
{
  char input_buffer[4096];
  input_string (input_buffer, sizeof (input_buffer));

  char *input_end;
  errno = 0;
  double result = strtod (input_buffer, &input_end);

  if (errno || input_end == input_buffer || has_text_characters (input_end))
    {
      fprintf (stderr, "error: Invalid number given\n");
      exit (1);
    }

  return result;
}


void
input_array (int *array, int len)
{
  int index;
  for (index = 0;
       index < len;
       ++index)
    {
      array[index] = input_int ();
    }
}


void
input_array_line (int *array, int len)
{
  /* Inputs into an ARRAY exactly LEN amount of integers. */

  char input_buffer[4096];
  input_string (input_buffer, sizeof (input_buffer));
  char *input_begin = input_buffer;
  char *input_end;

  int index;
  for (index = 0;
       index < len;
       ++index)
    {
      errno = 0;
      long long_num = strtol (input_begin, &input_end, 10);

      if (errno || input_end == input_begin)
        {
          fprintf (stderr, "error: Invalid integer input\n");
          exit (1);
        }

      if (long_num > INT_MAX || long_num < INT_MIN)
        {
          fprintf (stderr, "error: Integer number is out of range\n");
          exit (1);
        }

      array[index] = (int) long_num;
      input_begin = input_end;
    }

  if (has_text_characters (input_end))
    {
      fprintf (stderr, "error: Invalid integer line input\n");
      exit (1);
    }
}


int
input_int_line (int *array, int max_len)
{
  /* Inputs into an ARRAY a variable amount of integers up MAX_LEN. */

  char input_buffer[4096];
  input_string (input_buffer, sizeof (input_buffer));
  char *input_begin = input_buffer;
  char *input_end;

  int index;
  for (index = 0;
       index < max_len;
       ++index)
    {
      errno = 0;
      long long_num = strtol (input_begin, &input_end, 10);

      if (errno)
        {
          fprintf (stderr, "error: Invalid integer input\n");
          exit (1);
        }

      if (input_end == input_begin)
        {
          break;
        }

      if (long_num > INT_MAX || long_num < INT_MIN)
        {
          fprintf (stderr, "error: Integer number is out of range\n");
          exit (1);
        }

      array[index] = (int) long_num;
      input_begin = input_end;
    }

  if (has_text_characters (input_end))
    {
      fprintf (stderr, "error: Invalid integer line input\n");
      exit (1);
    }

  if (index == 0)
    {
      fprintf (stderr, "error: Empty integer line\n");
      exit (1);
    }

  return index;
}


void
input_matrix (int *matrix, int width, int height)
{
  int row;
  for (row = 0;
       row < height;
       ++row)
    {
      int *matrix_row = matrix + row * width;
      input_array_line (matrix_row, width);
    }
}


void
print_array (int *array, int len)
{
  if (len > 0)
    {
      printf ("%d", array[0]);

      int index;
      for (index = 1;
           index < len;
           ++index)
        {
          printf (" %d", array[index]);
        }
      printf ("\n");
    }
}


void
print_matrix (int *matrix, int width, int height)
{
  int row;
  for (row = 0;
       row < height;
       ++row)
    {
      int *matrix_row = matrix + row * width;
      print_array (matrix_row, width);
    }
}


void
quick_sort (int *array, int start_index, int end_index)
{
  if (start_index < end_index)
    {
      /* All values smaller than the pivot will be put behind the
         divider index. */
      int divider_index = start_index;

      {
        int end_value = array[end_index]; /* pivot */
        int index;
        for (index = start_index;
             index < end_index;
             ++index)
          {
            int value = array[index];
            if (value < end_value)
              {
                array[index] = array[divider_index];
                array[divider_index] = value;
                ++divider_index;
              }
          }

        array[end_index] = array[divider_index];
        array[divider_index] = end_value;
      }

      quick_sort (array, start_index, divider_index - 1);
      quick_sort (array, divider_index + 1, end_index);
    }
}


void
sort_array (int *array, int len)
{
  quick_sort (array, 0, len - 1);
}
