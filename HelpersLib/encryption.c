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
#define _CRT_SECURE_NO_WARNINGS

#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include <stdbool.h>

#include "encryption.h"

/**
 * vigenere encode/decode
 * returns a pointer to the encoded string
 */
char *vigenere(const char *cstr, const char *keyword, int decode)
{
    size_t len = strlen(cstr);
    char* str = (char*)malloc((len + 1) * sizeof(char));
    if (str == NULL)
    {
        return NULL;
    }
    strcpy(str, cstr);

    size_t keyword_length = strlen(keyword);

    for (size_t i = 0, j = 0, n = len; i < n; i++)
    {
        if (isalpha(str[i]))
        {
            str[i] = vigenere_encode_char(str[i], shift(keyword[j]) * (decode == 1 ? -1 : 1));
            if (keyword_length == ++j)
            {
                j = 0;
            }
        }
    }

    return str;
}

/**
 * vigenere decode : Shift char 'c' with key 'n'.
 */
char vigenere_decode_char(const char c, int n)
{
    return caesar_encode_char(c, -n);
}

/**
 * vigenere decode : Shift char 'c' with key 'n'.
 */
char vigenere_encode_char(const char c, int n)
{
    return caesar_encode_char(c, n);
}

/**
 * caesar decode a string using key
 * returns a pointer to the encoded string
 */
char *caesar_decode(const char *cstr, int key)
{
    return caesar_encode(cstr, -key);
}

/**
 * caesar encode a string using key
 * returns a pointer to the encoded string
 */
char *caesar_encode(const char *cstr, int key)
{
    size_t len = strlen(cstr);
    char *str = (char *)malloc((len + 1) * sizeof(char));
    if (str == NULL)
    {
        return NULL;
    }
    strcpy(str, cstr);
    for (size_t i = 0; i < len; i++)
    {
        if (isalpha(str[i]))
        {
            str[i] = caesar_encode_char(str[i], key);
        }
    }
    return str;
}

/**
 * caesar decode : Shift char 'c' with key 'n'.
 */
char caesar_decode_char(const char c, int n)
{
    return caesar_encode_char(c, -n);
}


/**
 * caesar encode : Shift char 'c' with key 'n'.
 */
char caesar_encode_char(const char c, int n)
{
    if (!isalpha(c))
    {
        return c;
    }

    n = n % 26;
    int _c = shift(c) + n;

    while (_c < 0)
    {
        _c = _c + 26;
    }

    while (_c > 25)
    {
        _c = _c - 26;
    }

    int a = islower(c) ? 'a' : 'A';
    return (a + _c);
}


/**
 * shift the char code into a number between 0-25 
 */
int shift(const char c)
{
    char l = tolower(c);
    if (!isalpha(l))
    {
        return 0;
    }
    return l - 'a';
}