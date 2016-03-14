var app = app || {};

app.userController = (function() {
    function UserController(model, views) {
        this.model = model;
        this.viewBag = views;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this.viewBag.loginView.loadLoginView(selector);
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        this.viewBag.registerView.loadRegisterView(selector);
    };

    UserController.prototype.login = function(username, password) {
        return this.model.login(username, password)
            .then(function(loginData) {
                setUserToStorage(loginData);
                window.location.replace('#/home/');
                noty({
                    theme: 'relax',
                    text: 'Successfully logged in!',
                    type:'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }, function(error) {
                noty({
                    theme: 'relax',
                    text:  error.responseText,
                    type:'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    UserController.prototype.register = function(username, pass, fullName) {
        return this.model.register(username, pass, fullName)
            .then(function(registerData) {
                var data = {
                    username: username,
                    fullName: fullName,
                    objectId: registerData.objectId,
                    sessionToken: registerData.sessionToken
                };

                setUserToStorage(data);
                window.location.replace('#/home/');
                noty({
                    theme: 'relax',
                    text: 'Successfully registered!',
                    type:'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseText,
                    type:'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            })
    };

    UserController.prototype.logout = function() {
        return this.model.logout()
            .then(function() {
                clearUserFromStorage();
                window.location.replace('#/');
                noty({
                    theme: 'relax',
                    text: 'Successfully logged out!',
                    type:'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseText,
                    type:'error',
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