var app = app || {};

(function(eventsSystem) {
    "use strict";

    var TEXT_PATTERN = /^[A-Za-z][A-Za-z\s]*$/,
        DURATION_PATTERN = /^[0-9]+$/;

    function hall(name, numberOfLectures) {
        this.setName(name);
        this.setCapacity(numberOfLectures);
        this.parties = [];
        this.lectures = [];
    }

    hall.prototype.getName = function() {
        return this._name;
    }

    hall.prototype.setName = function(name) {
        if (!(TEXT_PATTERN.test(name))) {
            throw new Error('Name can contain only letters and whitespace.');
        }

        this._name = name;
    }

    hall.prototype.getCapacity = function() {
        return this._capacity;
    }

    hall.prototype.setCapacity = function(capacity) {
        if (!(DURATION_PATTERN.test(capacity))) {
            throw new Error('Parameter capacity can contain only digits.');
        }

        this._capacity = capacity;
    }

    hall.prototype.addEvent = function (event) {
        if (!(event instanceof eventsSystem.party) && !(event instanceof eventsSystem.lecture)) {
            throw new TypeError('Parameter should be an instance of lecture or party.');
        }

        if (event instanceof eventsSystem.party) {
            this.parties.push(event);
        } else if (event instanceof eventsSystem.lecture) {
            this.lectures.push(event);
        }
    }

    eventsSystem.hall = hall;
})(app);