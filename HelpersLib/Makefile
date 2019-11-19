
ARCH=`arch`
OUTPUT_DIR=../ToolSet/${ARCH}

all: inputs encryption growablestring
	ar ruv helperslib.a inputs.o encryption.o growablestring.o
	ranlib helperslib.a
	
	mkdir -p ${OUTPUT_DIR}/lib
	mkdir -p ${OUTPUT_DIR}/include
	cp -f helperslib.a ${OUTPUT_DIR}/lib
	cp -f *.h ${OUTPUT_DIR}/include
	make clean

encryption:
	gcc -c -o encryption.o encryption.c

growablestring:
	gcc -c -o growablestring.o growablestring.c

inputs:
	gcc -c -o inputs.o inputs.c
	
clean:
	rm -f *.o
	rm -f *.a