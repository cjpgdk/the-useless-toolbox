/**
 * Visibility object (jQuery version).
 * @author Christian M. Jensen <cmj@cjpg.dk>.
 * @version 1.0.0
 *
 * const Visibility = require('./utils/visibility');
 *
 * $("#password").invisible();
 * $("#password").visible();
 */
;(function (factory) {
    if (typeof define === 'function' && define.amd) {
        define(['jquery'], factory);
    } else if (typeof exports === 'object') {
        factory(require('jquery'));
    } else {
        factory(jQuery);
    }
}(function ($) {
    const oldStyles = {};
    $.fn.invisible = function () {
        return this.each(
            function () {
                if (!oldStyles[$(this).id]) {
                    oldStyles[$(this).id] = {
                        visibility: $(this).css("visibility"),
                        display: $(this).css("display")
                    };
                }
                $(this).css("visibility", "hidden");
                $(this).css("display", "none");
            }
        );
    };

    $.fn.visible = function () {
        return this.each(
            function () {
                if (!oldStyles[$(this).id]) {
                    $(this).css("visibility", oldStyles[element.id].visibility);
                    $(this).css("display", oldStyles[element.id].display);
                } else {
                    $(this).css("visibility", "visible");
                    $(this).css("display", "block");
                }
            }
        );
    };
}));
