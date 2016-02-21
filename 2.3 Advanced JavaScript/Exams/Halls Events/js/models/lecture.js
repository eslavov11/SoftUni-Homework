var app = app || {};

(function(eventsSystem) {
    "use strict";

    function lecture(options) {
        eventsSystem.event.call(this, options);
        this.setTrainer(options.trainer);
        this.setCourse(options.course);
    }

    lecture.extends(eventsSystem.event);

    lecture.prototype.getTrainer = function() {
        return this._trainer;
    }

    lecture.prototype.setTrainer = function(trainer) {
        if (!(trainer instanceof eventsSystem.trainer)) {
            throw new TypeError('Parameter should be an instance of trainer.');
        }

        this._trainer = trainer;
    }

    lecture.prototype.getCourse = function() {
        return this._course;
    }

    lecture.prototype.setCourse = function(course) {
        if (!(course instanceof eventsSystem.course)) {
            throw new TypeError('Parameter should be an instance of course.');
        }

        this._course = course;
    }

    eventsSystem.lecture = lecture;
})(app);