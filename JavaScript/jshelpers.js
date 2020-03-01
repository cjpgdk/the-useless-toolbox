/**
 * File: jshelper.js
 *
 * @author    Christian M. Jensen <cmj@cjpg.dk>.
 * @licence   MIT.
 * @version   0.0.3
 * @copyright Christian M. Jensen <cmj@cjpg.dk>.
 */

/**
 * String functions attached to 'String.prototype'
 */

if (!String.prototype.reverse) {
    /**
     * Reverse the text.
     *
     * @returns {string} The text in reverse.
     */
    String.prototype.reverse = function () {
        return this.split('').reverse().join('')
    };
}

// translate
window.translations = window.translations || undefined;
if (!String.prototype.translate) {
    /**
     * Translate a string, or replace the original string with the corresponding string in the language (local)
     *
     * @param {string} local The language local to use when looking for a translation.
     * @param {object} replace An object with key*=>value** pairs to replace in the string *RegExp+flag 'g'. ** any string.
     *
     * @returns {string} The modified string if a translation exists ohervize the original string.
     */
    String.prototype.translate = function (local, replace) {
        if (!window.translations) {
            console.log("No translations loaded into 'window.translations'");
            return this;
        }
        if (local && !window.translations[local]) {
            console.log("No translations found for local ${local} in 'window.translations'");
            return this;
        }

        let _str = undefined;
        if (local) {
            _str = window.translations[local][this] ? window.translations[local][this] : this;
        } else {
            _str = window.translations[this] ? window.translations[this] : this;
        }

        // replace place holders

        if (typeof replace !== 'undefined' && replace) {
            for (let item in replace) {
                _str = _str.replace(new RegExp(item, 'g'), replace[item]);
            }
        }
        return _str;
    }
}

// ucfirst
if (!String.prototype.ucfirst) {
    /**
     * Convert the first char of a string/word to uppercase.
     *
     * @returns {string} The modified string.
     */
    String.prototype.ucfirst = function () {
        return this.charAt(0).toUpperCase() + this.slice(1);
    };
}
