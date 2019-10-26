/*
CS50x, 2019: Problem Set 2 (caesar)

C app created for 'CS50's Introduction to Computer Science' via edX.og.
*/

#include <inputs.h>
#include <encryption.h>
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>

// define function found later in this file.
int print_usage(char* binary_name);

int main(int argc, char* argv[])
{
    // check the args length
    if (argc != 2)
    {
        return print_usage(argv[0]);
    }

    // check the argument only contains digits
    for (int i = 0, n = strlen(argv[1]); i < n; i++)
    {
        // first char is '-'
        if (i == 0 && argv[1][i] != '-' && !isdigit(argv[1][i]))
        {
            // not -, and not 0 - 9 so exit.
            return print_usage(argv[0]);
        }
        else if (i != 0 && !isdigit(argv[1][i]))
        {
            // not 0 - 9, so exit.
            return print_usage(argv[0]);
        }
    }

    // convert argument to int.
    int key = atoi(argv[1]);

    // collect user input plaintext
    char *plaintext = input_promt("plaintext : ");
    printf("ciphertext: ");

    for (int i = 0, n = strlen(plaintext); i < n; i++)
    {
        if (isalpha(plaintext[i]))
        {
            printf("%c", caesar_encode_char(plaintext[i], key));
        }
        else
        {
            printf("%c", plaintext[i]);
        }
    }
    printf("\n");
    free(plaintext);
}

// print app usage and return 1 as exit code.
int print_usage(char* binary_name)
{
    printf("Usage: %s key\n", binary_name);
    return 1;
}