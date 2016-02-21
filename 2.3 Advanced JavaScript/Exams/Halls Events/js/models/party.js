var app = app || {};

(function(eventsSystem) {
    "use strict";

    function party(options) {
        eventsSystem.event.call(this, options);
        this.setCatered(options.isCatered);
        this.setBirthday(options.isBirthday);
        this.setOrganiser(options.organiser);
    }

    party.extends(eventsSystem.event);

    party.prototype.checkIsCatered = function() {
        return this._isCatered;
    }

    party.prototype.setCatered = function(isCatered) {
        if ((typeof(isCatered) !== "boolean")) {
            throw new TypeError('Parameter isCatered should be of type boolean.');
        }

        this._isCatered = isCatered;
    }

    party.prototype.checkIsBirthday = function() {
        return this._isBirthday;
    }

    party.prototype.setBirthday = function(isBirthday) {
        if ((typeof(isBirthday) !== "boolean")) {
            throw new TypeError('Parameter isBirthday should be of type boolean.');
        }

        this._isBirthday = isBirthday;
    }

    party.prototype.getOrganiser = function() {
        return this._organiser;
    }

    party.prototype.setOrganiser = function(organiser) {
        if (!(organiser instanceof eventsSystem.employee)) {
            throw new TypeError('Parameter should be an instance of employee.');
        }

        this._organiser = organiser;
    }

    eventsSystem.party = party;
})(app);