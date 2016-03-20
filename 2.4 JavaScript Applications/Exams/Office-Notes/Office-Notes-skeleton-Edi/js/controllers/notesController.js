var app = app || {};

app.notesController = (function () {
    function NotesController(viewBag, model) {
        this.model = model;
        this.viewBag = viewBag;
        this._notesPerPage = 10;
    }

    NotesController.prototype.loadOfficeNotes = function (selector, page) {
        var _this = this;
        var date = new Date().toISOString().substr(0, 10);
        this.model.getNotesForToday(date)
            .then(function (data) {
                _this.model.getNotesForTodayCount(date)
                    .then(function (count) {
                        var result = {
                            notes: [],
                            pagination: {
                                numberOfItems: count,
                                itemsPerPage: _this._notesPerPage,
                                selectedPage: page,
                                hrefPrefix: '#/office/'
                            }
                        };

                        data.forEach(function (note) {
                            result.notes.push({
                                title: note.title,
                                text: note.text,
                                deadline: note.deadline,
                                author: note.author,
                                id: note._id
                            })
                        });

                        _this.viewBag.showOfficeNotes(selector, result);
                    })
            });
    };

    NotesController.prototype.loadMyNotes = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._notesPerPage;
        var userId = sessionStorage['userId'];
        this.model.getNotesByCreatorId(userId, _this._notesPerPage, skipPages)
            .then(function (data) {
                _this.model.getNotesByCreatorIdCount(userId)
                    .then(function (count) {
                        var result = {
                            notes: [],
                            pagination: {
                            numberOfItems: count,
                                itemsPerPage: _this._notesPerPage,
                                selectedPage: page,
                                hrefPrefix: '#/myNotes/'
                            },
                            isEdible : true
                        };


                        data.forEach(function (note) {
                            result.notes.push({
                                title: note.title,
                                text: note.text,
                                deadline: note.deadline,
                                author: note.author,
                                id: note._id
                            })
                        });

                        _this.viewBag.showMyNotes(selector, result);
                    })
            });
    };

    NotesController.prototype.loadAddNote = function (selector) {
        this.viewBag.showAddNote(selector);
    };

    NotesController.prototype.addNote = function (data) {
        var result = {
            title: data.title,
            text: data.text,
            deadline: data.deadline,
            author: sessionStorage['username']
        };

        this.model.addNote(result)
            .then(function (success) {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/myNotes/'});
                });
            });
    };

    NotesController.prototype.loadEditNote = function (selector, data) {
        this.viewBag.showEditNote(selector, data);
    };

    NotesController.prototype.editNote = function (data) {
        data.author = sessionStorage['username'];
        this.model.editNote(data._id, data)
            .then(function (success) {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/myNotes/'});
                });
            })
    };

    NotesController.prototype.loadDeleteNote = function (selector, data) {
        this.viewBag.showDeleteNote(selector, data);
    };

    NotesController.prototype.deleteNote = function (noteId) {
        this.model.deleteNote(noteId)
            .then(function (success) {
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/myNotes/'});
                });
            },function (error) {
                //TODO:
            });
    };

    return {
        load: function (viewBag, model) {
            return new NotesController(viewBag, model);
        }
    };
}());