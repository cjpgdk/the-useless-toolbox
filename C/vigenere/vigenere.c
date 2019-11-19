/*
CS50x, 2019: Problem Set 2 (vigenere)

C app created for 'CS50's Introduction to Computer Science' via edX.og.

Modified to take additional arguments.

DEFAULT:
./vigenere keyword
 - Take console input and encode with KEY
 - To decode instead of encode use -KEY (DASH)KEY
 - EG. encode ./vigenere abc
 - EG. decode ./vigenere abc -d

ENCODE File:
./vigenere abc -f /path/to/file.txt

DECODE File:
./vigenere abc -d -f /path/to/file.txt
*/
#include <stdio.h>
#include <ctype.h>
#include <string.h>

// define functions found later in this file.
int print_usage(string binary_name);
int shift(char c);
char get_encrypted_letter(char letter, int key);

int main(int argc, char *argv[])
{

	// check the args length
	if (argc != 2)
	{
		return print_usage(argv[0]);
	}

	// check the argument only contains digits
	for (int i = 0, n = strlen(argv[1]); i < n; i++)
	{
		if (isdigit(argv[1][i]))
		{
			// not a - z, so exit.
			return print_usage(argv[0]);
		}
	}


	// collect user input plaintext
	string plaintext = get_string("plaintext : ");
	printf("ciphertext: ");

	int keylength = strlen(argv[1]);

	for (int i = 0, j = 0, n = strlen(plaintext); i < n; i++)
	{
		if (isalpha(plaintext[i]))
		{
			printf("%c", get_encrypted_letter(plaintext[i], shift(argv[1][j])));
			if (keylength == ++j)
			{
				j = 0;
			}
		}
		else
		{
			printf("%c", plaintext[i]);
		}
	}
	printf("\n");
}

// change the char code into a number between 0-25 
int shift(char c)
{
	char l = tolower(c);
	if (!isalpha(l))
	{
		return 0;
	}
	return l - 'a';
}

// get the letter 'letter' encrypted by key
char get_encrypted_letter(char letter, int key)
{
	bool lc = islower(letter);
	char a = (lc ? 'a' : 'A');
	char z = (lc ? 'z' : 'Z');
	int ch = letter + key;
	while (ch > z)
	{
		ch = a + (ch - (z + 1));
	};
	return ch;
}

// print app usage and return 1 as exit code.
int print_usage(string binary_name)
{
	printf("Usage: %s keyword\n", binary_name);
	return 1;
}