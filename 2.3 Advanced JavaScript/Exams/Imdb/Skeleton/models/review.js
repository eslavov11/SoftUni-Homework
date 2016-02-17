;var imdb = imdb || {};

(function(scope) {
    'use strict';

    function Review(name, content, date) {
        this._id = Review.idCount;
        this.name = name;
        this.bio = content;
        this.date = date;
        Review.idCount++;
    }

    Review.idCount = 1;

    scope.getReview = function (name, content, date) {
        return new Review(name, content, date);
    }
})(imdb);
