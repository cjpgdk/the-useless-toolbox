
ARCH=`arch`
TOOLSET_DIR=../../ToolSet/${ARCH}
#OUTPUT_DIR=../bin/
OUTPUT_DIR=${TOOLSET_DIR}

all:
	mkdir -p ${OUTPUT_DIR}
	gcc -g -v -static -Wall -std=gnu99 -o ${OUTPUT_DIR}/mod mod.c 
