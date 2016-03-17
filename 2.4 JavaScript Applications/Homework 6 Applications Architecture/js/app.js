var app = app || {};

(function() {

    var router = Sammy(function () {
        var selector = '#wrapper';

        var requester = app.requester.config('kid_bkeREc9VJZ','e0a07a1765cb4b4cbfaf3dac70156325');
        var booksViews = app.booksViews.load();
        var booksModel = app.booksModel.load(requester);
        var booksController = app.booksController.load(booksModel, booksViews);

        this.get('#/books', function() {
            booksController.loadAllBooks(selector);
        });

        this.get('#/books/add', function() {
            booksController.loadAddBookPage(selector);
        });

        this.get('#/books/edit', function() {
            booksController.loadEditBookPage(selector);
        });

        this.get('#/books/delete', function() {
            booksController.loadDeletePhonePage(selector);
        });

        this.bind('redirectUrl', function(e, data) {
            this.redirect(data.url);
        });

        this.bind('add-new-book', function(e, data) {
            booksController.addNewBook(data);
        });

    });

    router.run('#/books');
}());