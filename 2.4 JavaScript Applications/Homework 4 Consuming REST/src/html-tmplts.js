var app = app || {};
var selector = $('#wrapper');

app.renderAllBooks = function renderAllBooks(books) {
    if ($('#all-books')) {
        $('#all-books').remove();
        $('#add-btn').remove();
    }

    var ol = $('<ol>').attr('id', 'all-books');
    ol.append('<li>').html('<b>Title &nbsp;&nbsp;&nbsp;&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Author</b>');
    books.forEach(function (book) {
        ol.append(app.getTemplateCRUDLi(book));
    });

    selector.append(ol);
    selector.append(app.setAddBtn());
}

app.getTemplateCRUDLi = function getTemplateCRUDLi(row) {
    var editBtn = $('<span style="color:blue; cursor:pointer; padding-right: 10px;">edit</span>')
        .on('click', function () {
            var newTitle = prompt('Enter title:', row.title);
            if (!newTitle) {
                alert('Title is mandatory!');
                return;
            }

            var newAuthor = prompt('Enter author:', row.author);
            var newIsbn = prompt('Enter isbn:', row.isbn);
            app.editBook(row._id, newTitle, newAuthor, newIsbn);
        }),
        delBtn = $('<span style="color:blue; cursor:pointer;">delete</span>')
            .on('click', function () {
                app.deleteBook(row._id);
            });

    return $('<li>')
        .append('<span style="padding-right: 20px;">' + row.title + '</span>')
        .append('<span style="padding-right: 10px;">' + row.author + '</span>')
        .append(editBtn)
        .append(delBtn);
};

app.setAddBtn = function() {
    var btn = $('<button>').html('add book')
        .attr('id', 'add-btn').css('float', 'right').css('cursor', 'pointer')
        .on('click', function () {
            var newTitle = prompt('Enter new title:');
            if (!newTitle) {
                alert('Title is mandatory!');
                return;
            }

            var newAuthor = prompt('Enter author:');
            var newIsbn = prompt('Enter isbn:');
            app.createBook(newTitle, newAuthor, newIsbn);
        });

    return btn;
}