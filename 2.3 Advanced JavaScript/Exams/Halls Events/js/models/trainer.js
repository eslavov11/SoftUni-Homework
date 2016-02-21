var app = app || {};

(function(eventsSystem) {
    "use strict";

    function trainer(name, numberOfLectures) {
        eventsSystem.employee.call(this, name, numberOfLectures);
        this.courses = [];
        this.feedbacks = [];
    }

    trainer.extends(eventsSystem.employee);

    trainer.prototype.addCourse = function (course) {
        if (!(course instanceof eventsSystem.course)) {
            throw new TypeError('Parameter should be an instance of course.');
        }

        this.courses.push(course);
    }

    trainer.prototype.addFeedback = function (text) {
        if (text instanceof String) {
            throw new TypeError('Feedback should be of type string.');
        }

        this.feedbacks.push(text);
    }

    eventsSystem.trainer = trainer;
})(app);