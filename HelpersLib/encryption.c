/**
 * encryption Library for C
 *
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

#include <ctype.h>
#include <stdbool.h>

#include "encryption.h"


/**
 * caesar decode : Shift char 'c' with key 'n'.
 */
char caesar_decode_char(char c, int n)
{
    return caesar_encode_char(c, -n);
}


/**
 * caesar encode : Shift char 'c' with key 'n'.
 */
char caesar_encode_char(char c, int n)
{
    int a = islower(c) ? 'a' : 'A';
    return a + ((shift(c) + n) % 26);
}

/**
 * caesar decode : Shift char 'c' with key 'n'.
 *
 * This is the first function i made to create a caesar encoding.
 * it works but function 'caesar_encode' is the correct way.
 */
char caesar_decode_char1(char c, int n)
{
    return caesar_encode_char1(c, -n);
}

/**
 * caesar encode : Shift char 'c' with key 'n'.
 *
 * This is the first function i made to create a caesar encoding.
 * it works but function 'caesar_encode' is the correct way.
 */
char caesar_encode_char1(char c, int n)
{
    bool lc = islower(c);
    char a = (lc ? 'a' : 'A');
    char z = (lc ? 'z' : 'Z');
    int ch = c + n;
    while (ch > z)
    {
        ch = a + (ch - (z + 1));
    }
    return ch;
}


/*
 * shift the char code into a number between 0-25 
 */
int shift(char c)
{
    char l = tolower(c);
    if (!isalpha(l))
    {
        return 0;
    }
    return l - 'a';
}