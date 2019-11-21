
BASE_DIR=C

all: tax mod caesar vigenere substitution

mod:
	cd ${BASE_DIR}/mod && make

tax:
	cd ${BASE_DIR}/tax && make

caesar:
	cd ${BASE_DIR}/caesar && make

vigenere:
	cd ${BASE_DIR}/vigenere && make

substitution:
	cd ${BASE_DIR}/substitution && make
