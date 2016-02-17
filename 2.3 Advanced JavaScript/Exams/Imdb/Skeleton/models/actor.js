;var imdb = imdb || {};

(function(scope) {
    'use strict';

    function Actor(name, bio, born) {
        this._id = Actor.idCount;
        this.name = name;
        this.bio = bio;
        this.born = born;
        Actor.idCount++;
    }

    Actor.idCount = 1;

    scope.getActor = function (name, bio, born) {
        return new Actor(name, bio, born);
    }
})(imdb);
