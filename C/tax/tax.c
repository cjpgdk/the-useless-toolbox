/**
 * tax.c: This app calculates the tax of a number
 *
 * got bored while waiting so why not!
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

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

#if defined(WIN32) || defined(WIN64) || defined(_WIN32) || defined(_WIN64)
#define strcasecmp _stricmp
#else
#include <strings.h>
#endif

int main(int argc, char *argv[])
{
    if (argc != 3 && argc != 4)
    {
        printf("Usage: %s [-p] aount tax\n", argv[0]);
        printf("       *[-p] tax is in percentage\n");
        return 1;
    }

    double amount = 0;
    double tax = 0;
    int percentage = 0;

    for (int i = 1; i < argc; i++)
    {
        if (strcasecmp(argv[i], "-p") == 0)
        {
            percentage = 1;
        }
        else if (amount == 0)
        {
            amount = atof(argv[i]);
        }
        else if (tax == 0)
        {
            tax = atof(argv[i]);
        }
    }

    double percent_in_dec;
    if (percentage == 1)
    {
        percent_in_dec = 1+(tax / 100);
        double price_witout_tax = (amount / percent_in_dec);
        double tax_amount = amount - price_witout_tax;
        printf("Price witout tax:\n");
        printf("1+(%.2f %% / 100) = %.2f\n", tax, percent_in_dec);
        printf("%.2f / %.2f = %.2f\n", amount, percent_in_dec, price_witout_tax);
        printf("Total tax amount:\n");
        printf("%.2f - %.2f = %.2f\n", amount, price_witout_tax, tax_amount);
        printf("%f %% tax of %f:\n", tax, amount);
        printf("%f %% = %.2f\n", tax, tax_amount);
    }
    else
    {
        percent_in_dec = tax / amount;
        printf("%.2f / %.2f = %f\n", tax, amount, percent_in_dec);
        double percent = percent_in_dec * 100;
        printf("%f * 100 = %.2f %%\n", percent_in_dec, roundf(percent * 100) / 100);
    }
}
