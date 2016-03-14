var app = app || {};

app.notesViews = (function() {
    function NotesViews() {
        this.showNotes = showNotesView;
        this.showAddNoteView = showAddNoteView;
        this.showEditNoteView = showEditNoteView;
        this.showDeleteNoteView = showDeleteNoteView;
    }

    function showNotesView (selector, data) {
        $.get('templates/notesTemplate.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('.edit').click(function () {
                var data = getElementData(this);

                $.sammy(function () {
                    this.trigger('showEditNote', data);
                })
            });

            $('.delete').click(function () {
                var data = getElementData(this);

                $.sammy(function() {
                    this.trigger('showDeleteNote', data);
                });
            });

            $('#pagination').pagination({
                items: data.pagination.numberOfItems,
                itemsOnPage: data.pagination.itemsPerPage,
                cssStyle: 'light-theme',
                hrefTextPrefix: data.pagination.hrefPrefix
            }).pagination('selectPage', data.pagination.selectedPage);
         }).done();
    }

    function showAddNoteView (selector) {
        $.get('templates/addNote.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        }).then(function() {
            $('#addNoteButton').click(function() {
                var title = $('#title').val();
                var text = $('#text').val();
                var deadline = $('#deadline').val();

                $.sammy(function() {
                    this.trigger('addNote', {title: title, text: text, deadline: deadline});
                });

                return false;
            })
        }).done();
    }

    function showEditNoteView (selector, data) {
        $.get('templates/editNote.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#editNoteButton').click(function() {
                var title = $('#title').val();
                var text = $('#text').val();
                var deadline = $('#deadline').val();
                var id = $('#edit-note').attr('data-id');

                $.sammy(function() {
                    this.trigger('editNote', {title: title, text: text, deadline: deadline, id: id});
                });

                return false;
            })
        }).done();
    }

    function showDeleteNoteView (selector, data) {
        $.get('templates/deleteNote.html', function(template) {
            var outHtml = Mustache.render(template, data);
            $(selector).html(outHtml);
        }).then(function() {
            $('#deleteNoteButton').click(function() {
                var id = $('#delete-note').attr('data-id');

                $.sammy(function() {
                    this.trigger('deleteNote', id);
                });

                return false;
            })
        }).done();
    }

    function getElementData(element) {
        var title = $($(element).parent().children()[0]).find('h2').text();
        var text = $($(element).parent().children()[0]).find('p').text();
        var deadline = $($(element).parent().children()[0]).find('.deadline').text();
        var id = $(element).parent().attr('data-id');

        return {title:title, text:text, deadline:deadline, objectId:id};
    }

    return {
        load: function() {
            return new NotesViews();
        }
    }
}());