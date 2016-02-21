var app = app || {};

(function(eventsSystem) {
    "use strict";

    var TEXT_PATTERN = /^[A-Za-z][A-Za-z\s]*$/,
        LECTURES_PATTERN = /^[0-9]+$/;

    function course(name, numberOfLectures) {
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);
    }

    course.prototype.getName = function() {
        return this._name;
    }

    course.prototype.setName = function(name) {
        if (!(TEXT_PATTERN.test(name))) {
            throw new Error('Name can contain only letters and whitespace.');
        }

        this._name = name;
    }

    course.prototype.getNumberOfLectures = function() {
        return this._numberOfLectures;
    }

    course.prototype.setNumberOfLectures = function(numberOfLectures) {
        if (!(LECTURES_PATTERN.test(numberOfLectures))) {
            throw new Error('Parameter numberOfLectures can contain only digits.');
        }

        this._numberOfLectures = numberOfLectures;
    }

    eventsSystem.course = course;
})(app);