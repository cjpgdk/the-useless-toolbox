/**
 * Class CaesarCipher.
 * @author Christian M. Jensen <cmj@cjpg.dk>
 */
class CaesarCipher {
    /**
     * Initialise CaesarCipher class.
     * @param {int} key
     */
    constructor(key) {
        this._key = parseInt(key);
    }

    get key(){
        return this._key;
    }
    set key(key){
        this._key = parseInt(key);
    }

    /**
     * Decrypt a string using the Caesar cipher
     * @param {string} text
     * @returns {string}
     */
    decrypt(text) {
        let out = "";
        for (let i = 0; i < text.length; i++) {
            out += this.caesar(text[i], -this._key);
        }
        return out;
    }

    /**
     * Encrypt a string using the Caesar cipher
     * @param {string} text
     * @returns {string}
     */
    encrypt(text) {
        let out = "";
        for (let i = 0; i < text.length; i++) {
            out += this.caesar(text[i], this._key);
        }
        return out;
    }

    /**
     * get letter 'l' using caesar ecryption
     * @param {string} l the letter to ecrypt.
     * @param {int} k the key to use.
     * @returns {string}
     */
    caesar(l, k) {
        k = k % 26;
        let ch = this.shift(l);
        if(ch < 0 || ch > 25) {
            return l;
        }
        ch = ch + k;
        while (ch < 0)
        {
            ch = ch + 26;
        }
        while (ch > 25)
        {
            ch = ch - 26;
        }
        let a = this.isLower(l) ? "a".charCodeAt(0) : "A".charCodeAt(0);
        return String.fromCharCode(a + ch);
    }

    /**
     * shift the letter 'l' into a number between 0-25
     * @param {string} l the letter to shift.
     * @returns {number}
     */
    shift(l) {
        return l.toLowerCase().charCodeAt(0) - "a".charCodeAt(0);
    }

    /**
     * Check if str is all lowercase
     * @param {string} str the string to check
     * @returns {boolean} true: if all letters are lowercase.
     */
    isLower(str) {
        return str === str.toLowerCase();
    }
}
