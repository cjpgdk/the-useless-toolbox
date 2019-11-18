/**
 * inputs Library for C
 *
 * Handles geting inputs from the use.
 * https://git.cjpg.dk/christian/the-useless-toolbox/
 *
 * MIT License
 *
 * Copyright (c) 2019 Christian M. Jensen
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

#include <stdio.h>
#include <stdlib.h>
#include <stdint.h>
#include <stdarg.h>

#include "inputs.h"


/**
 * Promt the user for some input!
 * NOTE* you must free the return pointer when done with it!
 */
char *input_promt(char *format, ...)
{
    va_list args;
    va_start(args, format);
    // print out remainder of message
    vfprintf(stdout, format, args);
    va_end(args);
    return read_input();
}

/*
 * Gets some input from the user, and return it as a 'char *'
 * NOTE* you must free the return pointer when done with it!
 */
char *read_input()
{
    // keep track of the length
    int length = 0;

    // output buffer
    char *outbuffer = (char *)malloc(2 * sizeof(char));
    if (outbuffer == NULL)
    {
        return NULL;
    }

    // read input: https://linux.die.net/man/3/fgetc
    char c;
    while (c = fgetc(stdin))
    {
        // end of file or error
        if (c == EOF)
        {
            break;
        }
        // stop on return key or new line.
        if (c == '\n' || c == '\r')
        {
            break;
        }

        // append to output buffer.
        if (length < SIZE_MAX) {
            outbuffer[length++] = c;
        }
        else
        {
            // input to long!
            break;
        }

        // resize the buffer
        char *tmp = realloc(outbuffer, length + 1);
        if (tmp == NULL)
        {
            // unable to resize the buffer!
            break;
        }
        outbuffer = tmp;
    }
    // return the buffer
    if (outbuffer)
    {
        // add "string" terminator
        outbuffer[length] = '\0';
        return outbuffer;
    }
    return NULL;
}