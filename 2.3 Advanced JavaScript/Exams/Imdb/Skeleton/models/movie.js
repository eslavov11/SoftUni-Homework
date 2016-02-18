;var imdb = imdb || {};
(function(scope) {
    'use strict';

    function Movie(title, length, rating, country) {
        this._id = Movie.idCount;
        this.title = title;
        this.length = length;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        Movie.idCount++;
    }

    Movie.idCount = 1;

    Movie.prototype.addActor = function(actor) {
        this._actors.push(actor);
    };

    Movie.prototype.getActors = function() {
        return this._actors;
    };

    Movie.prototype.addReview = function(review) {
        this._reviews.push(review);
    };

    Movie.prototype.deleteReview = function(review) {
        var indexOfReviewToDelete = this._reviews.indexOf(review);
        if (indexOfReviewToDelete > -1) {
            this._reviews.splice(indexOfReviewToDelete, 1);
        }
    };

    Movie.prototype.deleteReviewById = function(id) {
        this._reviews = this._reviews.filter(function (review) {
            return review._id !== id;
        });
    };

    Movie.prototype.getReviews = function() {
        return this._reviews;
    };

    scope._Movie = Movie;

    scope.getMovie = function (title, length, rating, country) {
        return new Movie(title, length, rating, country);
    }
})(imdb);
