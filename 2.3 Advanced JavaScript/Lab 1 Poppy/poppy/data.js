;
var poppy = poppy || {};
(function(scope) {
    'use strict';

    Object.prototype.extends = function(parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var Popup = (function() {
        function Popup(title, message, autoHide, timeout, closeButton) {
            if (this.constructor === Popup) {
                throw new Error("Cannot instantiate an abstract class.");
            }

            this.title = title;
            this.message = message;
            this.autoHide = autoHide;
            this.timeout = timeout;
            this.closeButton = closeButton;
        }

        Popup.prototype.callback = function() {
        };

        return Popup;
    })();

    var Success = (function() {
        function Success(title, message) {
            Popup.call(this, title, message, true, 0, false)
        }

        Success.extends(Popup);

        return Success;
    })();

    var Info = (function() {
        function Info(title, message) {
            Popup.call(this, title, message, false, 0, true)
        }

        Info.extends(Popup);

        return Info;
    })();

    var Error = (function() {
        function Error(title, message) {
            Popup.call(this, title, message, false, 0, false)
        }

        Error.extends(Popup);

        return Error;
    })();

    var Warning = (function() {
        function Warning(title, message) {
            Popup.call(this, title, message, false, 0, false)
        }

        Warning.extends(Popup);

        return Warning;
    })();

})(poppy);