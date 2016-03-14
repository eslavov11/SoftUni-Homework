var app = app || {};

app.notesController = function () {
    function NotesController(model, views, notesPerPage) {
        this._model = model;
        this._viewBag = views;
        this._notesPerPage = notesPerPage;
    }

    NotesController.prototype.showAddNote = function (selector) {
        this._viewBag.showAddNoteView(selector);
    };

    NotesController.prototype.showEditNote = function (selector, data) {
        this._viewBag.showEditNoteView(selector, data);
    };

    NotesController.prototype.showDeleteNote = function (selector, data) {
        this._viewBag.showDeleteNoteView(selector, data);
    };

    NotesController.prototype.showTodayNotes = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._notesPerPage;
        /*When using date as deadline date*/
        var today = new Date().toISOString().substring(0,10);
        var date = new Date(today).toISOString();
        /*When using strings as deadline date*/
        //var date = new Date().toISOString().substring(0, 10);

        this._model.getTodayNotes(date, this._notesPerPage, skipPages)
            .then(function (notesData) {
                var viewInputData = {
                    results: [],
                    pagination: {
                        numberOfItems: notesData.count,
                        itemsPerPage: _this._notesPerPage,
                        selectedPage: page,
                        hrefPrefix: '#/office/'
                    },
                    isEdible : false
                };

                parseInputData(notesData.results, viewInputData.results);

                _this._viewBag.showNotes(selector, viewInputData);
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to get today's notes",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    NotesController.prototype.showMyNotes = function (selector, page) {
        var _this = this;
        var skipPages = (page - 1) * this._notesPerPage;
        /*When using users as pointers*/
        var author = JSON.stringify({
            __type: 'Pointer',
            className: '_User',
            objectId: sessionStorage['userId']
        });
        /*When using users as string*/
        //var author = sessionStorage['fullName'];

        this._model.getMyNotes(author, this._notesPerPage, skipPages)
            .then(function (notesData) {
                var viewInputData = {
                    results: [],
                    pagination: {
                        numberOfItems: notesData.count,
                        itemsPerPage: _this._notesPerPage,
                        selectedPage: page,
                        hrefPrefix: '#/myNotes/'
                    },
                    isEdible : true
                };

                parseInputData(notesData.results, viewInputData.results);

                _this._viewBag.showNotes(selector, viewInputData);
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to get your notes",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    NotesController.prototype.addNote = function (selector, data) {
        var note = {
            title: data.title,
            text: data.text,
            /*When using pointer as author*/
            author: {
                __type: 'Pointer',
                className: '_User',
                objectId: sessionStorage['userId']
            },
            /*When using strings as author*/
            //author: sessionStorage['fullName'],
            /*When using dates as date*/
            deadline: {
                __type: 'Date',
                iso: new Date(data.deadline).toISOString()
            }
            /*When using strings as date*/
            //deadline: data.deadline
        };

        console.log(data.deadline);

        this._model.addNote(note)
            .then(function (data) {
                noty({
                    theme: 'relax',
                    text: "Successfully added new note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function () {
                    this.trigger('changePath', '#/myNotes/');
                });

            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to add a new note",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    NotesController.prototype.editNote = function (selector, data) {
        var editNoteData = {
            note: {}
        };
        if (data.title !== '') {
            editNoteData.note.title = data.title;
        }
        if (data.text !== '') {
            editNoteData.note.text = data.text;
        }
        if (data.deadline) {
            editNoteData.note.deadline =  {
                __type:'Date',
                iso : new Date(data.deadline).toISOString()
            };
        }
        editNoteData.id = data.id;

        this._model.editNote(editNoteData)
            .then(function (data) {
                noty({
                    theme: 'relax',
                    text: "Successfully edited note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function() {
                    this.trigger('changePath', '#/myNotes/');
                })
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to edit your note",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    NotesController.prototype.deleteNote = function (selector, id) {
        this._model.deleteNote(id)
            .then(function (data) {
                noty({
                    theme: 'relax',
                    text: "Successfully deleted note!",
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                $.sammy(function() {
                    this.trigger('changePath', '#/myNotes/');
                });
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || "A problem occurred while trying to delete your note",
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });
    };

    function parseInputData(inputData, outputData) {

        inputData.forEach(function (data) {
            var note = {
                objectId: data.objectId,
                author: data.author.fullName,
                deadline: data.deadline.iso.substring(0, 10),
                title: data.title,
                text: data.text
            };

            outputData.push(note);
        });
    }

    return {
        load: function (model, views, notesPerPage) {
            return new NotesController(model, views, notesPerPage);
        }
    }
}();