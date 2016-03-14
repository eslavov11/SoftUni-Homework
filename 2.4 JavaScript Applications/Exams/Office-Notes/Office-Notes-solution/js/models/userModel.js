var app = app || {};

app.userModel = (function() {
    function UserModel(baseUrl, requester, headers) {
        this._baseUrl = baseUrl;
        this._requester = requester;
        this._headers = headers;
    }

    UserModel.prototype.login = function (username, password) {
        var queryUrl = this._baseUrl + 'login' + '?username=' + username + '&password=' + password;
        var headers = this._headers.getHeaders();

        return this._requester.get(headers, queryUrl);
    };

    UserModel.prototype.register = function (data) {
        var queryUrl = this._baseUrl + 'users/';
        var headers = this._headers.getHeaders();

        return this._requester.post(headers, queryUrl, data);
    };

    UserModel.prototype.logout = function () {
        var queryUrl = this._baseUrl + 'logout';

        var headers = this._headers.getHeaders(true);

        return this._requester.post(headers, queryUrl);
    };

    return {
        load: function(baseUrl, requester, headers) {
            return new UserModel(baseUrl, requester, headers);
        }
    }
}());