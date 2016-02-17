;var imdb = imdb || {};

(function(scope) {
    'use strict';

    function Theatre(name, length, rating, country) {
        this._id = Theatre.idCount;
        scope._Movie.call(this, name, length, rating, country);
        this.isPuppet = false;
        Theatre.idCount++;
    }

    Theatre.extend(scope._Movie);

    Theatre.idCount = 1;

    scope.getTheatre = function (name, length, rating, country) {
        return new Theatre(name, length, rating, country);
    }
})(imdb);
