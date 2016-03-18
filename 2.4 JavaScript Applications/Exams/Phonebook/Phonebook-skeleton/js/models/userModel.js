var app = app || {};

app.userModel = (function () {
    function UserModel(requester) {
        this._requester = requester;
        this.serviceUrl = requester.baseUrl + 'user/' + requester.appId;
    }

    UserModel.prototype.login = function(data) {
        var loginUrl = this.serviceUrl + '/login';
        return this._requester.post(loginUrl, data, false);
    };

    UserModel.prototype.logout = function() {
        var logoutUrl = this.serviceUrl + '/_logout';
        return this._requester.post(logoutUrl, null, true);
    };

    UserModel.prototype.register = function(data) {
        return this._requester.post(this.serviceUrl, data);
    };

    UserModel.prototype.editProfile = function(id, data) {
        return this._requester.put(this.serviceUrl + '/' + id, data, true);
    };

    return {
        load: function(requester) {
            return new UserModel(requester);
        }
    }
}());