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

#ifndef _ENC_HELPER_H
#define _ENC_HELPER_H

/**
 * vigenere encode/decode
 * returns a pointer to the encoded string
 */
char* vigenere(const char *cstr, const char* keyword, int decode);

/**
 * vigenere decode : Shift char 'c' with key 'n'.
 */
char vigenere_decode_char(const char c, int n);
/**
 * vigenere decode : Shift char 'c' with key 'n'.
 */
char vigenere_encode_char(const char c, int n);

/**
 * caesar decode a string using key
 * returns a pointer to the encoded string
 */
char *caesar_decode(const char *cstr, int key);

/**
 * caesar encode a string using key
 * returns a pointer to the encoded string
 */
char *caesar_encode(const char *cstr, int key);

/**
 * caesar encode : Shift char 'c' with key 'n'.
 */
char caesar_encode_char(const char c, int n);

/**
 * caesar decode : Shift char 'c' with key 'n'.
 */
char caesar_decode_char(const char c, int n);

/**
 * shift the char code into a number between 0-25
 */
int shift(const char c);

#endif