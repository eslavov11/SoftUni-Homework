var app = app || {};

app.booksModel = (function () {
    function BooksModel(requester) {
        this._requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/books';
    }

    BooksModel.prototype.getAllBooks = function () {
        return this._requester.get(this.serviceUrl, true);
    };

    BooksModel.prototype.addNewBook = function (data) {
        return this._requester.post(this.serviceUrl, data, true);
    };

    BooksModel.prototype.editBook = function (data) {
        var outputData = {
            title: data.title,
            author: data.author,
            isbn: data.isbn
        };

        return this._requester.put(this.serviceUrl + '/' + data.id, outputData, true);
    };

    BooksModel.prototype.deleteBook = function (id) {
        return this._requester.remove(this.serviceUrl + '/' + id, true);
    };

    return {
        load: function (requester) {
            return new BooksModel(requester);
        }
    };
})();