/*
CS50x, 2019: Problem Set 2 (vigenere)

C app created for 'CS50's Introduction to Computer Science' via edX.og.

Modified to take additional arguments.

DEFAULT:
./vigenere keyword
 - Takes console input and encode with KEY
 - EG. encode ./vigenere abc
 - EG. decode ./vigenere abc -d

ENCODE File:
./vigenere abc -f /path/to/file.txt

DECODE File:
./vigenere abc -d -f /path/to/file.txt
*/
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <ctype.h>
#include <string.h>
#include "inputs.h"
#include "encryption.h"
#include "growablestring.h"

#if defined(WIN32) || defined(WIN64) || defined(_WIN32) || defined(_WIN64)
#define strcasecmp _stricmp
#else
#include <strings.h>
#endif

// define functions found later in this file.
int print_usage(char *binary_name);
// make sure we only got a-z in the keywaord
int check_keyword(const char *keyword);
// shift the char code into a number between 0-25
int shift(const char c);

int main(int argc, char *argv[])
{

    // min 2 args
    if (argc <  2)
    {
        return print_usage(argv[0]);
    }

    char *keyword = NULL;
    char *file = NULL;
    FILE *fileptr = NULL;
    int decode = -1;
    int usefile = 0;

    // sort the args
    for (size_t i = 1; i < argc; i++)
    {
        if (strcasecmp(argv[i], "-h") == 0)
        {
            return print_usage(argv[0]);
        }
        if (strcasecmp(argv[i], "-d") == 0)
        {
            decode = 1;
        }
        else if (strcasecmp(argv[i], "-f") == 0)
        {
            usefile = 1;
            // check if we have any more args!
            if ((argc-1) >= (i + 1))
            {
                // move the index.
                ++i;
                // get and open the file!
                file = argv[i];
                fileptr = fopen(file, "r");
            }
        }
        else
        {
            // if app is call corectly this is the keyword!
            keyword = argv[i];
        }
    }

    // make sure we got a key!
    if (keyword == NULL || check_keyword(keyword) == 0)
    {
        printf("Empty or invalid keyword provided!\n");
        return 2;
    }

    // check if file and that we got a file.
    if (usefile == 1 && fileptr == NULL)
    {
        printf("Using file flag '-f' but no file is provided! or the file do not exists!\n");
        return 2;
    } 
    else if (usefile == 1 && fileptr != NULL)
    {
        /*
         * Decode/Encode file!
         */
        printf("Reading file %s\n", file);
        growable_string_t gstr = growable_string_new(1);
        char c;
        size_t i = 0;
        size_t keyword_length = strlen(keyword);
        // loop every char and encode it!
        while ((c = fgetc(fileptr)) != EOF)
        {
            if (isalpha(c))
            {
                c = vigenere_encode_char(c, shift(keyword[i]) * (decode == 1 ? -1 : 1));
                if (keyword_length == ++i)
                {
                    i = 0;
                }
            }
            // append to temp string
            growable_string_append_char(gstr, c);
        }
        // close the handle
        fclose(fileptr);

        printf("Writing file %s\n", file);

        // open the file
        fileptr = fopen(file, "w");
        if (fileptr == NULL)
        {
            printf("Could not open %s for writing\n", file);
            return 3;
        }
        // dump the string!
        fwrite(gstr->s, sizeof(char), gstr->length, fileptr);
        // release memory
        growable_string_delete(gstr);
        fclose(fileptr);
    }
    else
    {
        // encode / decode the input!

        char *plaintext = input_promt("plaintext : ");
        char *enc = vigenere(plaintext, keyword, decode);
        printf("ciphertext: %s", enc);
        if (enc != NULL)
        {
            free(enc);
        }
        if (plaintext != NULL)
        {
            free(plaintext);
        }
        printf("\n");
    }

    // close the file, if open!
    if (fileptr != NULL)
    {
        fclose(fileptr);
    }
    return 0;
}

// print app usage and return 1 as exit code.
int print_usage(char *binary_name)
{
	printf("Usage: %s keyword [-d] [-f FILE]\n", binary_name);
	return 1;
}


// make sure we only got a-z in the keywaord
int check_keyword(const char *keyword)
{
    for (size_t i = 0, n = strlen(keyword); i < n; i++)
    {
        if (!isalpha(keyword[i]))
        {
            return 0;
        }
    }
    return 1;
}