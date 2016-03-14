var app = app || {};

app.noteModel = (function() {
    function NoteModel(baseUrl, requester, headers) {
        this._requester = requester;
        this._headers = headers;
        this._serviceUrl = baseUrl + 'classes/Note/';
    }

    NoteModel.prototype.getTodayNotes = function (date, showAmount, skipPages) {
        /*Query when using dates for saving the deadline date*/
        var queryUrl = this._serviceUrl +
                '?where={"deadline":{"__type":"Date", "iso":"' + date + '"}}' +
                '&include=author' +
                '&limit=' + showAmount +
                '&skip=' + skipPages +
                '&count=1';
        /*Query when using strings for saving the deadline date*/
        //var queryUrl = this._serviceUrl +
        //    '?where={"deadline":"' + date.toLocaleString() + '"}' +
        //    '&limit=' + showAmount +
        //    '&skip=' + skipPages +
        //    '&count=1';

        var headers = this._headers.getHeaders(true);

        return this._requester.get(headers, queryUrl);
    };

    NoteModel.prototype.getMyNotes = function (author, showAmount, skipPages) {
        var queryUrl = this._serviceUrl +
            '?where={"author":' + author + '}' +
            '&include=author' +
            '&limit=' + showAmount +
            '&skip=' + skipPages +
            '&count=1';
        var headers = this._headers.getHeaders(true);

        return this._requester.get(headers, queryUrl);
    };

    NoteModel.prototype.addNote = function (note) {
        var headers = this._headers.getHeaders(true);

        return this._requester.post(headers, this._serviceUrl, note);
    };

    NoteModel.prototype.editNote = function (data) {
        var url = this._serviceUrl + data.id;
        var headers = this._headers.getHeaders(true);

        return this._requester.put(headers, url, data.note);
    };

    NoteModel.prototype.deleteNote = function (noteId) {
        var queryUrl = this._serviceUrl + noteId;
        var headers = this._headers.getHeaders(true);

        return this._requester.delete(headers, queryUrl);
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new NoteModel(baseUrl, requester, headers);
        }
    }
}());