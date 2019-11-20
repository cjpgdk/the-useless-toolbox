
BASE_DIR=C

all: mod caesar vigenere substitution

mod:
	cd ${BASE_DIR}/mod && make

caesar:
	cd ${BASE_DIR}/caesar && make

vigenere:
	cd ${BASE_DIR}/vigenere && make

substitution:
	cd ${BASE_DIR}/substitution && make
