
#include <stdio.h>
#include <stdlib.h>

/*
 */ 
int main(int argc, char** argv) {
    char *quotesString = "The \"use\" of quotations causes difficulties."
    " \\n, \\t and \\ are also special characters.";
    printf("%s\n", quotesString);
    return (EXIT_SUCCESS);
}

