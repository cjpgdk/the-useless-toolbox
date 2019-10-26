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

 /*
  * shift the char code into a number between 0-25
  */
int shift(char c);

/**
 * caesar encode : Shift char 'c' with key 'n'.
 * This one uses modular arithmetic
 */
char caesar_encode_char(char c, int n);

/**
 * caesar decode : Shift char 'c' with key 'n'.
 * This one uses modular arithmetic
 */
char caesar_decode_char(char c, int n);

/**
 * caesar encode : Shift char 'c' with key 'n'.
 * This one uses a while loop to get the shifted char code.
 */
char caesar_encode_char1(char c, int n);

/**
 * caesar decode : Shift char 'c' with key 'n'.
 * This one uses a while loop to get the shifted char code.
 */
char caesar_decode_char1(char c, int n);

#endif