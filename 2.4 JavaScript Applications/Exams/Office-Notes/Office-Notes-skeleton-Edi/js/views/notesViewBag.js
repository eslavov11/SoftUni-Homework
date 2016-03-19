var app = app || {};

app.notesViewBag = (function () {
    function showOfficeNotes(selector, data) {
        $.get('templates/officeNoteTemplate.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
        })
    }

    function showMyNotes(selector, data) {
        $.get('templates/myNoteTemplate.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            $('.edit').on('click', function () {
                var noteId = $(this).parent().attr('data-id');

                var note = data.notes.filter(function (a) {
                    return a.id == noteId;
                });

                if (note.length) {
                    Sammy(function () {
                        this.trigger('showEditNote', note[0]);
                    })
                }
            });
            $('.delete').on('click', function () {
                var noteId = $(this).parent().attr('data-id');

                var note = data.notes.filter(function (a) {
                    return a.id == noteId;
                });

                if (note.length) {
                    Sammy(function () {
                        this.trigger('showDeleteNote', note[0]);
                    })
                }
            })
        })
    }

    function showAddNote(selector) {
        $.get('templates/addNote.html', function (templ) {
            $(selector).html(templ);
            $('#addNoteButton').on('click', function () {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val();

                Sammy(function () {
                    this.trigger('addNote', {title: title, text: text, deadline: deadline});
                })
            })
        })
    }

    function showEditNote(selector, data) {
        $.get('templates/editNote.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#editNoteButton').on('click', function() {
                var title = $('#title').val(),
                    text = $('#text').val(),
                    deadline = $('#deadline').val(),
                    id = $(this).attr('data-id');

                Sammy(function () {
                    this.trigger('editNote', {title: title, text: text, deadline: deadline, _id:id});
                })
            })
        })
    }

    function showDeleteNote(selector, data) {
        $.get('templates/deleteNote.html', function (templ) {
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);
            $('#deleteNoteButton').on('click', function() {
                var id = $(this).attr('data-id');
                Sammy(function () {
                    this.trigger('deleteNote', {_id:id});
                })
            })
        })
    }

    return {
        load: function () {
            return {
                showOfficeNotes: showOfficeNotes,
                showMyNotes: showMyNotes,
                showAddNote: showAddNote,
                showEditNote: showEditNote,
                showDeleteNote: showDeleteNote
            }
        }
    }
}());