var app = app || {};

app.booksViews = (function () {
    function showAllBooks(selector, data) {
        $.get('templates/books.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
            $('#addNewBooks').on('click', function (e) {
                Sammy(function () {
                    this.trigger('redirectUrl', { url: '#/addNewBook' })
                });
            });
        });
    }

    function showEditBook(selector, data) {
        $.get('templates/recent-books.html', function (template) {
            var rendered = Mustache.render(template, data);
            $(selector).html(rendered);
        });
    }

    function showAddNewBook(selector, postId) {
        $.get('templates/addNewBook.html', function (template) {
            var rendered = Mustache.render(template);
            $(selector).html(rendered);
            $('#addBook').on('click', function (e) {
                var text = $('#text').val();
                Sammy(function () {
                    this.trigger('add-new-book', {
                        text: text, post: {
                            "_type": "KinveyRef",
                            "_id": postId,
                            "_collection": "posts"
                        }
                    });
                });
            });
        });
    }

    return {
        load: function () {
            return {
                showAllBooks: showAllBooks,
                showAddNewBook: showAddNewBook,
                showEditBook: showEditBook
            }
        }
    };
})();