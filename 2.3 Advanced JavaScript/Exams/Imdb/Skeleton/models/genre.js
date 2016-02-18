;var imdb = imdb || {};
(function(scope) {
    'use strict';

    function Genre(name) {
        this._id = Genre.idCount;
        Genre.idCount++;
        this.name = name;
        this._movies = [];
    }

    Genre.idCount = 1;

    Genre.prototype.addMovie = function(movie) {
        this._movies.push(movie);
    };

    Genre.prototype.deleteMovie = function(movie) {
        var indexOfElementToDelete = this._movies.indexOf(movie);
        if (indexOfElementToDelete > -1) {
            this._movies.splice(indexOfElementToDelete, 1);
        }
    };

    Genre.prototype.deleteMovieById = function(id) {
        this._movies = this._movies.filter(function (movie) {
            return movie._id !== id;
        });
    };

    Genre.prototype.getMovies = function() {
        return this._movies;
    };

    scope.getGenre = function (name) {
        return new Genre(name);
    }
})(imdb);

