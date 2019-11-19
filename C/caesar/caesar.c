/*
CS50x, 2019: Problem Set 2 (caesar)

C app created for 'CS50's Introduction to Computer Science' via edX.og.

Modified to take additional arguments.

DEFAULT:
./caesar KEY
 - Take console input and encode with KEY
 - To decode instead of encode use -KEY (DASH)KEY
 - EG. encode ./caesar 123
 - EG. decode ./caesar -123

ENCODE File:
./caesar KEY /path/to/file.txt

DECODE File:
./caesar -KEY /path/to/file.txt
*/
#define _CRT_SECURE_NO_WARNINGS
#include <inputs.h>
#include <encryption.h>
#include <stdio.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>
#include "growablestring.h"

// check the key.
int check_key(const char *key);
// define function found later in this file.
int print_usage(char *binary_name);

int main(int argc, char *argv[])
{
    // we miust have 2 or 3 args!
    if(argc != 2 && argc != 3)
    {
        // invalid show help.
        return print_usage(argv[0]);
    }

    // check the argument only contains digits
    if (check_key(argv[1]) == 0)
    {
        // not valid show help.
        return print_usage(argv[0]);
    }

    // convert key argument to int.
    int key = atoi(argv[1]);

    // check the args length
    if (argc == 2)
    {
        // default promt for input.
        char *plaintext = input_promt("plaintext : ");
        if (plaintext == NULL)
        {
            printf("Not input!\n");
            return 2;
        }

        char *str = caesar_encode(plaintext, key);
        printf("ciphertext: %s\n", str);
        free(plaintext);
        free(str);
    }
    else if (argc == 3)
    {
        printf("Encoding file %s\n", argv[2]);
        // open the file
        FILE* fileptr = fopen(argv[2], "r");
        // check that it's open
        if (fileptr == NULL)
        {
            printf("Could not open %s.\n", argv[2]);
            return 3;
        }
        growable_string_t gstr = growable_string_new(1);
        char c;
        // loop every char and encode it!
        while ((c = fgetc(fileptr)) != EOF)
        {
            if (isalpha(c))
            {
                c = caesar_encode_char(c, key);
            }
            // append to temp string
            growable_string_append_char(gstr, c);

        }
        // close the handle
        fclose(fileptr);

        printf("Writing file %s.\n", argv[2]);

        // open the file
        fileptr = fopen(argv[2], "w");
        if (fileptr == NULL)
        {
            printf("Could not open %s\n", argv[2]);
            return 3;
        }
        // dump the string!
        fwrite(gstr->s, sizeof(char), gstr->length, fileptr);
        // release memory
        growable_string_delete(gstr);
        fclose(fileptr);
    }
}

// print app usage and return 1 as exit code.
int print_usage(char *binary_name)
{
    printf("Usage: %s key [File]\n", binary_name);
    return 1;
}

// check the key.
int check_key(const char *key)
{
    for (size_t i = 0, n = strlen(key); i < n; i++)
    {
        // first char is '-'
        if (i == 0 && key[i] != '-' && !isdigit(key[i]))
        {
            // not -, and not 0 - 9 so exit.
            return 0;
        }
        else if (i != 0 && !isdigit(key[i]))
        {
            // not 0 - 9, so exit.
            return 0;
        }
    }
    return 1;
}