# CS50x, 2019: Problem Set 6 (caesar)
from sys import argv


def main():
    # check arg lenght
    if len(argv) != 2:
        print(f"python {argv[0]} k")
        exit(1)

    # convert the key to int.
    key = int(argv[1])
    if not key > 0 and not key < 0:
        print(f"python {argv[0]} k")
        exit(1)

    # get plaintext from the use
    plaintext = input("plaintext : ")

    # print the ciphertext
    print("ciphertext: ", end="")
    for c in plaintext:
        if c.isalpha() and ord(c.lower()) in range(ord("a"), ord("z"), 1):
            print(caesar(c, key), end="")
        else:
            print(c, end="")
    print()


def shift(l):
    """shift the letter 'l' into a number between 0-25"""
    return ord(l)-ord("a") if l.islower() else ord(l)-ord("A");


def caesar(l, k):
    """get letter 'l' using caesar ecryption"""
    a = ord("a") if l.islower() else ord("A")
    return chr(a + (shift(l) + k) % 26)


if __name__ == "__main__":
    main()