var app = app || {};

app.userController = (function() {
    function UserController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    UserController.prototype.showLoginScreen = function(selector) {
        this.viewBag.loadLoginView(selector);
    };

    UserController.prototype.showRegisterScreen = function(selector) {
        this.viewBag.loadRegisterView(selector);
    };

    UserController.prototype.login = function(data) {
        return this.model.login(data.username, data.password)
            .then(function(loginData) {
                noty({
                    theme: 'relax',
                    text: 'You have successfully logged in!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                setUserToStorage(loginData);
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while signing in!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    UserController.prototype.register = function(username, password, fullName) {
        var data = {
            username: username,
            password: password,
            fullName: fullName
        };

        return this.model.register(data)
            .then(function(registerData) {
                noty({
                    theme: 'relax',
                    text: 'You have successfully registered!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });

                var data = {
                    username: username,
                    fullName: fullName,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };
                setUserToStorage(data);
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while trying to register!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    UserController.prototype.logout = function() {
        return this.model.logout()
            .then(function() {
                noty({
                    theme: 'relax',
                    text: 'You have successfully logged out!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });

                clearUserFromStorage();
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while signing out!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            });

    };

    function setUserToStorage(data) {
        sessionStorage['username'] = data.username;
        sessionStorage['userId'] = data.objectId;
        sessionStorage['fullName'] = data.fullName;
        sessionStorage['sessionToken'] = data.sessionToken;
    }

    function clearUserFromStorage() {
        delete sessionStorage['username'];
        delete sessionStorage['userId'];
        delete sessionStorage['fullName'];
        delete sessionStorage['sessionToken'];
    }

    return {
        load : function(model, views) {
            return new UserController(model, views);
        }
    }
}());