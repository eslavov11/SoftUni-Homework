var app = app || {};

(function(eventsSystem) {
    "use strict";

    var TEXT_PATTERN = /^[A-Za-z][A-Za-z\s]*$/,
        WORK_HOURS_PATTERN = /^[0-9]+$/;

    function employee(name, numberOfLectures) {
        this.setName(name);
        this.setWorkHours(numberOfLectures);
    }

    employee.prototype.getName = function() {
        return this._name;
    }

    employee.prototype.setName = function(name) {
        if (!(TEXT_PATTERN.test(name))) {
            throw new Error('Name can contain only letters and whitespace.');
        }

        this._name = name;
    }

    employee.prototype.getWorkhours = function() {
        return this._workHours;
    }

    employee.prototype.setWorkHours = function(workHours) {
        if (!(WORK_HOURS_PATTERN.test(workHours))) {
            throw new Error('Parameter workHours can contain only digits.');
        }

        this._workHours = workHours;
    }

    eventsSystem.employee = employee;
})(app);