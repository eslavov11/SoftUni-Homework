;
'use strict';
Object.prototype.extends = function(parent) {
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

var Popup = (function() {
    function Popup(type, title, message, autoHide, timeout, closeButton, position) {
        if (this.constructor === Popup) {
            throw new Error("Cannot instantiate an abstract class.");
        }

        this.type = type;
        this.title = title;
        this.message = message;
        this.autoHide = autoHide;
        this.timeout = timeout;
        this.closeButton = closeButton;
        this.position = position;
    }

    Popup.prototype.callback = function() {
    };

    return Popup;
})();

var Success = (function() {
    function Success(type, title, message) {
        Popup.call(this, type, title, message, true, 300, false, 'bottomLeft');
    }

    Success.extends(Popup);

    return Success;
})();

var Info = (function() {
    function Info(type, title, message) {
        Popup.call(this, type, title, message, false, 50, true, 'topLeft');
    }

    Info.extends(Popup);

    return Info;
})();

var Error = (function() {
    function Error(type, title, message) {
        Popup.call(this, type, title, message, false, 10, false, 'topRight');
    }

    Error.extends(Popup);

    return Error;
})();

var Warning = (function() {
    function Warning(type, title, message) {
        Popup.call(this, type, title, message, false, 10, false, 'bottomRight');
    }

    Warning.extends(Popup);

    return Warning;
})();