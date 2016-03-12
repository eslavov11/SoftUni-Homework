var app = app || {};

// getting all books
app.getBooks = function () {
    app.requester.makeRequest('GET', (app.requester.baseUrl + 'appdata/' + app.requester.appId + '/' + 'book'), null, true)
        .then(
            function (books) {
                app.renderAllBooks(books);
            },
            function (error) {
                console.error(error);
            }
        );
}

// creating book
app.createBook = function createBook(title, author, isbn) {
    app.requester.makeRequest(
        'POST',
        (app.requester.baseUrl + 'appdata/' + app.requester.appId + '/' + 'book'),
        {'title': title, 'author': author, 'isbn': isbn},
        true).then(
        function () {
            app.getBooks();
        },
        function (error) {
            console.error(error);
        }
    );
}

// editing book
app.editBook = function editBook(id, newTitle, newAuthor, newIsbn) {
    app.requester.makeRequest(
        'PUT',
        (app.requester.baseUrl + 'appdata/' + app.requester.appId + '/' + 'book/' + id),
        {'title': newTitle, 'author': newAuthor, 'isbn': newIsbn},
        true).then(
        function () {
            app.getBooks();
        },
        function (error) {
            alert('You cannot edit a book you haven\'t created!');
            console.error(error);
        }
    );
}


// deleting book
app.deleteBook = function deleteBook(id) {
    app.requester.makeRequest(
        'DELETE',
        (app.requester.baseUrl + 'appdata/' + app.requester.appId + '/' + 'book/' + id),
        null,
        true).then(
        function () {
            app.getBooks();
        },
        function (error) {
            alert('You cannot delete a book you haven\'t created!')
            console.error(error);
        })
}