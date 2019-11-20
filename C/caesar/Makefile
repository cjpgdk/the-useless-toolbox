
ARCH=`arch`
HELPERSLIB_DIR=../../HelpersLib
TOOLSET_DIR=../../ToolSet/${ARCH}
CWD=`pwd`
#OUTPUT_DIR=../bin/
OUTPUT_DIR=${TOOLSET_DIR}

all: caesar

helperslib:
	cd ${HELPERSLIB_DIR} && make

caesar: helperslib
	cd ${CWD} && mkdir -p ${OUTPUT_DIR}
	cd ${CWD} && gcc -g -v -static -Wall -std=gnu99 -o ${OUTPUT_DIR}/caesar caesar.c ${TOOLSET_DIR}/lib/libhelpers.a \
	-L${TOOLSET_DIR}/lib -I${TOOLSET_DIR}/include
