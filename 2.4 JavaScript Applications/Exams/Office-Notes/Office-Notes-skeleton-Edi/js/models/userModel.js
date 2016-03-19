var app = app || {};

app.userModel = (function() {
    function UserModel(requester) {
        this.requester = requester;
        this.serviceUrl = requester.baseUrl + 'user/' + requester.appId + '/';
    }

    UserModel.prototype.login = function(data) {
        var requestUrl = this.serviceUrl + 'login';
        return this.requester.post(requestUrl, data, false);
    };

    UserModel.prototype.register = function(data) {
        return this.requester.post(this.serviceUrl, data, false);
    };

    UserModel.prototype.logout = function() {
        var requestUrl = this.serviceUrl + '_logout';
        return this.requester.post(requestUrl, null, true);
    };


    return {
        load: function(requester) {
            return new UserModel(requester);
        }
    }
}());