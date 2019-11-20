
ARCH=`arch`
OUTPUT_DIR=../ToolSet/${ARCH}

all: inputs encryption growablestring
	ar ruv libhelpers.a inputs.o growablestring.o encryption.o
	ranlib libhelpers.a
	
	mkdir -p ${OUTPUT_DIR}/lib
	mkdir -p ${OUTPUT_DIR}/include
	cp -f libhelpers.a ${OUTPUT_DIR}/lib
	cp -f *.h ${OUTPUT_DIR}/include
	make clean

encryption: growablestring
	gcc -c -o encryption.o encryption.c
	ar ruv libencryption.a growablestring.o encryption.o
	ranlib libencryption.a
	mkdir -p ${OUTPUT_DIR}/lib
	mkdir -p ${OUTPUT_DIR}/include
	cp -f libencryption.a ${OUTPUT_DIR}/lib
	cp -f growablestring.h ${OUTPUT_DIR}/include

growablestring:
	gcc -c -o growablestring.o growablestring.c

inputs:
	gcc -c -o inputs.o inputs.c
	
clean:
	rm -f *.o
	rm -f *.a