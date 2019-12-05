// bmi.c: calculate the BMI of a person

#include <stdlib.h>
#include <stdio.h>
#include <math.h>

int print_usage(char* binary_name);

int main(int argc, char* argv[])
{
    if (argc < 3)
    {
        // invalid show help.
        return print_usage(argv[0]);
    }

    double weight = atof(argv[1]);
    double height = atof(argv[2]);
    double bmi = weight / powl(height, 2);

    printf("Weight: %f kg\n", weight);
    printf("Height: %f m\n", height);
    printf("BMI: %f\n", bmi);
}

// print app usage and return 1 as exit code.
int print_usage(char* binary_name)
{
    printf("Usage: %s weight-in-kg height-in-meters \n", binary_name);
    printf("\teg: %s 120 1.79\n", binary_name);
    return 1;
}