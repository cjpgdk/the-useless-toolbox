/**
 * Visibility object.
 * @author Christian M. Jensen <cmj@cjpg.dk>.
 * @version 1.0.0
 *
 * require('./utils/jquery.visibility');
 * Visibility.hide("#password");
 * Visibility.show("#password");
 */
;(function (visibility) {
    let registeredInModuleLoader;
    if (typeof define === 'function' && define.amd) {
        define(visibility);
        registeredInModuleLoader = true;
    }
    if (typeof exports === 'object') {
        module.exports = visibility();
        registeredInModuleLoader = true;
    }
    if (!registeredInModuleLoader) {
        let OldVisibility = window.Visibility;
        let api = window.Visibility = visibility();
        api.noConflict = function () {
            window.visibility = OldVisibility;
            return api;
        };
    }
}(function () {
    function loopElementList(selectors, callback) {
        let elementList = document.querySelectorAll(selectors);
        if (elementList && elementList.length) {
            for (let element of elementList) {
                callback(element);
            }
        }
    }

    // https://stackoverflow.com/a/1349426
    function makeid(length) {
        let result = '';
        let characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
        let charactersLength = characters.length;
        for (let i = 0; i < length; i++) {
            result += characters.charAt(Math.floor(Math.random() * charactersLength));
        }
        return result;
    }

    function visibility() {
        const oldStyles = {};

        function hide(selectors) {
            loopElementList(
                selectors, element => {
                    if (!element.id) {
                        element.id = makeid(8)
                    }
                    if (!oldStyles[element.id]) {
                        oldStyles[element.id] = {
                            visibility: element.style.visibility,
                            display: element.style.display
                        };
                    }
                    element.style.visibility = "hidden";
                    element.style.display = "none";
                }
            );
        }

        function show(selectors) {
            loopElementList(
                selectors, element => {
                    if (!oldStyles[element.id]) {
                        element.style.visibility = oldStyles[element.id].visibility;
                        element.style.display = oldStyles[element.id].display;
                    } else {
                        element.style.visibility = "visible";
                        element.style.display = "initial";
                    }
                }
            );
        }

        let obj = function () {};
        obj.prototype.hide = hide;
        obj.prototype.show = show;
        return new obj();
    }

    return visibility();
}));

