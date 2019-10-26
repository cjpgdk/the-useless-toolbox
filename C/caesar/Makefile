all: caesar

encryption-lib:
	gcc -c -o encryption.o ../../HelpersLib/encryption.c

inputs-lib:
	gcc -c -o inputs.o ../../HelpersLib/inputs.c

caesar: inputs-lib encryption-lib
	gcc -c -o caesar.o -I../../HelpersLib/ caesar.c
	gcc -o caesar -I../../HelpersLib/ caesar.o inputs.o encryption.o
	
clean:
	rm -f caesar.o inputs.o encryption.o