var app = app || {};

(function(eventsSystem) {
    "use strict";

    var TEXT_PATTERN = /^[A-Za-z][A-Za-z\s]*$/,
        DURATION_PATTERN = /^[0-9]+$/;

    function event(options) {
        if (this.constructor === event) {
            throw new Error("Cannot instantiate the abstract class event.");
        }

        this.setTitle(options.title);
        this.setType(options.type);
        this.setDuration(options.duration);
        this.setDate(options.date);
    }

    event.prototype.getTitle = function() {
        return this._title;
    }

    event.prototype.setTitle = function(title) {
        if (!(TEXT_PATTERN.test(title))) {
            throw new Error('Title can contain only letters and whitespace.');
        }

        this._title = title;
    }

    event.prototype.getType = function() {
        return this._type;
    }

    event.prototype.setType = function(type) {
        if (!(TEXT_PATTERN.test(type))) {
            throw new Error('Type can contain only letters and whitespace.');
        }

        this._type = type;
    }

    event.prototype.getDuration = function() {
        return this._duration;
    }

    event.prototype.setDuration = function(duration) {
        if (!(DURATION_PATTERN.test(duration))) {
            throw new Error('Duration can contain only digits.');
        }

        this._duration = duration;
    }

    event.prototype.getDate = function() {
        return this._date;
    }

    event.prototype.setDate = function(date) {
        if (!(date instanceof Date)) {
            throw new TypeError('Parameter should be an instance of Date.');
        }

        this._date = date;
    }

    eventsSystem.event = event;
})(app);