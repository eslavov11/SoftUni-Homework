#include <errno.h>
#include <limits.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>


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
