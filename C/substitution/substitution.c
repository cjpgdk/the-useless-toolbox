/*
: substitution.c
CS50x, 2019: Problem Set (substitution)
C app created for 'CS50's Introduction to Computer Science' via edX.og.

Modified to take file input and 
*/
#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <ctype.h>
#include <math.h>
#include <time.h>
#include <string.h>
#include "inputs.h"
#include "encryption.h"
#include "growablestring.h"

#if defined(WIN32) || defined(WIN64) || defined(_WIN32) || defined(_WIN64)
#define strcasecmp _stricmp
#else
#include <strings.h>
#endif

#define N 26
// generate a key of 26 chars a-z in none repeating order
char* grnrstr_26();
// check the chiper text is ready for use.
int pre_run_checks(const char *key);

// string used in app.
const char* ERROR_TEXT_ONLY_ALPHA = "Key must only contain alphabetic characters.";
const char* ERROR_TEXT_MUST_26 = "Key must contain 26 characters.";
const char* ERROR_TEXT_NO_REPEAT = "Key must not contain repeated characters.";

// the chiper key.
char chiperkey[N];

int main(size_t argc, char* argv[])
{
    // check that we got arguments.
    if (!(argc >= 2 && argc <= 5))
    {
        printf("Usage: %s [-g|[-d] key|key [-d] -f FILE] \n", argv[0]);
        return 1;
    }

    // if argument is '-g' we generate a valid key!
    if (strcasecmp(argv[1], "-g") == 0)
    {
        char* nkey = grnrstr_26();
        printf("Key: %s", nkey);
        free(nkey);
        return 0;
    }

    int decode = 0;
    char *file = NULL;
    char* key = NULL;

    // loop args to set the right options
    for (size_t i = 1; i < argc; i++)
    {
        if (strcasecmp(argv[i], "-d") == 0)
        {
            decode = 1;
        }
        else if (strcasecmp(argv[i], "-f") == 0)
        {
            file = argv[++i];
        }
        else
        {
            key = argv[i];
        }
    }

    // make sure the key is 26 chars.
    if (key == NULL || strlen(key) != N)
    {
        printf("%s\n", ERROR_TEXT_MUST_26);
        return 1;
    }

    // check the chiper key is ok.
    int pre_run;
    if ((pre_run = pre_run_checks(key)) != 0)
    {
        return pre_run;
    }


    if (file != NULL)
    {
        printf("Encoding file %s\n", file);
        // open the file
        FILE* fileptr = fopen(file, "r");
        // check that it's open
        if (fileptr == NULL)
        {
            printf("Could not open %s.\n", file);
            return 3;
        }
        growable_string_t gstr = growable_string_new(5120000); // 5 Mb (large file)
        char c;
        // loop every char and encode it!
        while ((c = fgetc(fileptr)) != EOF)
        {
            // append to temp string
            growable_string_append_char(gstr, c);
        }
        // close the handle
        fclose(fileptr);


        printf("Writing file %s.\n", file);

        // open the file
        fileptr = fopen(file, "w");
        if (fileptr == NULL)
        {
            growable_string_delete(gstr);
            printf("Could not open %s\n", file);
            return 3;
        }
        char *encstr = substitution(gstr->s, chiperkey, decode);
        // dump the string!
        fwrite(encstr, sizeof(char), strlen(encstr), fileptr);
        // release memory
        growable_string_delete(gstr);
        free(encstr);
        fclose(fileptr);
    }
    else
    {

        // get input from the user!
        char *plaintext = input_promt("plaintext:  ");
        char *ciphertext = substitution(plaintext, chiperkey, decode);
        printf("ciphertext: %s\n", ciphertext);
        free(ciphertext);
        free(plaintext);
    }
}

// check the chiper key is ready for use.
int pre_run_checks(const char *key)
{
    // init chiper key table.
    for (int i = 0; i < N; i++)
    {
        chiperkey[i] = '\0';
    }

    // check that the key contains only alphabetic and non repeated characters
    for (int i = 0; i < N; i++)
    {

        char lower = tolower(key[i]);

        if (lower < 'a' || lower > 'z')
        {
            printf("%s\n", ERROR_TEXT_ONLY_ALPHA);
            return 1;
        }

        if (!isalpha(key[i]))
        {
            printf("%s\n", ERROR_TEXT_ONLY_ALPHA);
            return 1;
        }

        // check if 'lower' value of the chiper key is repeated.
        for (size_t j = 0, n = strlen(chiperkey); j < n; j++)
        {
            if (lower == chiperkey[j])
            {
                printf("%s\n", ERROR_TEXT_NO_REPEAT);
                return 1;
            }
        }
        chiperkey[i] = lower;
    }
    return 0;
}

// generate a key of 26 chars a-z in none repeating order
char *grnrstr_26()
{
    srand(time(NULL));
    char nkey[N];
    size_t i = 0;
    while (i < N)
    {
        int num = (int)round(rand() % N);

        int contins = 0;
        char c = 'a' + num;
        for (size_t j = 0; i != 0 && j < i; j++)
        {
            if (c == nkey[j])
            {
                contins = 1;
            }
        }
        if (contins == 0)
        {
            nkey[i++] = c;
        }
    }

    char* out = malloc((N * sizeof(char)) + 1);
    if (out == NULL)
    {
        return NULL;
    }
    for (size_t i = 0; i < N; i++)
    {
        out[i] = nkey[i];
    }
    out[N] = '\0';
    return out;
}