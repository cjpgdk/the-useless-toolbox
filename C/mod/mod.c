// mod.c: This app calculates the mod of the args.
//
// lets say mod 3 of 30 then we call this app
// ./mod 30 3

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    if (argc != 3)
    {
        printf("Usage: %s num1 num2\n", argv[0]);
        return 1;
    }

    int n1 = atoi(argv[1]);
    int n2 = atoi(argv[2]);

    printf("%i %% %i = %i\n", n1, n2, (n1 % n2));
}
