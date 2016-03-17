var app = app || {};

app.booksController = (function () {
    function BooksController(model, viewBag) {
        this._model = model;
        this._viewBag = viewBag;
    }

    BooksController.prototype.loadAllBooks = function (selector) {
        var _this = this;

        this._model.getAllBooks()
            .then(function (successData) {
                var result = {
                    books: []
                };

                successData.forEach(function (book) {
                    result.books.push({
                        id: book.id,
                        title: book.title,
                        author: book.author,
                        author: book.isbn,
                    });
                });

                _this._viewBag.showAllBooks(selector, result);
            });
    };

    BooksController.prototype.loadAddBookPage = function (selector, postId) {
        this._viewBag.showAddNewBook(selector, postId);
    };

    BooksController.prototype.addNewBook = function (data) {
        this._model.addNewBook(data)
            .then(function () {
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/posts/' + data.post._id + '/books'});
                });
            });
    };

    BooksController.prototype.editBook = function (data) {
        return this.model.editBook(data)
            .then(function () {
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/books'});
                });
            }, function (error) {
                console.error(error);
            });
    };

    BooksController.prototype.deleteBook = function (id) {
        return this.model.deleteBook(id)
            .then(function () {
                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/books'});
                });
            }, function (error) {
                console.error(error);
            });
    };

    return {
        load: function (model, viewBag) {
            return new BooksController(model, viewBag);
        }
    };
})();