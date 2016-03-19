var app = app || {};

app.notesModel = (function () {
    function NotesModel(requester) {
        this.requester = requester;
        this.serviceUrl = requester.baseUrl + 'appdata/' + requester.appId + '/notes/';
    }

    NotesModel.prototype.getNotesForToday = function(deadline) {
        var requestUrl = this.serviceUrl + '?query={"deadline":"'+deadline + '"}&resolve=_acl.creator';
        return this.requester.get(requestUrl, true);
    };

    NotesModel.prototype.getNotesByCreatorId = function(userId) {
        var requestUrl = this.serviceUrl + '?query={"_acl.creator":"'+ userId + '"}';
        return this.requester.get(requestUrl, true);
    };

    NotesModel.prototype.addNote = function(data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    NotesModel.prototype.editNote = function(noteId, data) {
        var requestUrl = this.serviceUrl + noteId;
        return this.requester.put(requestUrl, data, true);
    };

    NotesModel.prototype.deleteNote = function(noteId) {
        var requestUrl = this.serviceUrl + noteId;
        return this.requester.remove(requestUrl, true);
    };

    return {
        load: function (requester) {
            return new NotesModel(requester);
        }
    }
}());