var app = app || {};

app.userController = (function() {
    function UserController(model, viewBag, messages) {
        this._model = model;
        this._viewBag = viewBag;
        this._messages = messages;
    }

    UserController.prototype.showLoginPage = function(selector) {
        this._viewBag.showLoginPage(selector);
    };

    UserController.prototype.showRegisterPage = function(selector) {
        this._viewBag.showRegisterPage(selector);
    };

    UserController.prototype.showEditProfilePage = function(selector) {
        this._viewBag.showEditProfilePage(selector, sessionStorage);
    };

    UserController.prototype.login = function(data) {
        this._model.login(data)
            .then(function(successData) {
                setSessionStorage(successData);

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'});
                });
            }).done();
    };

    UserController.prototype.register = function(data) {
        this._model.register(data)
            .then(function(successData) {
                setSessionStorage(successData);

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'});
                });
            }).done();
    };

    UserController.prototype.editProfile = function(data) {
        this._model.editProfile(data.userId, data)
            .then(function(successData) {
                sessionStorage['username'] = successData.username;// TODO: check if not changed!!
                sessionStorage['fullName'] = successData.fullName;// TODO: check if not changed!!

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'});
                });
            }).done();
    };

    UserController.prototype.logout = function() {
        this._model.logout()
            .then(function() {
                clearSessionStorage();
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/'});
                });
            }).done();
    };

    function setSessionStorage(data) {
        sessionStorage['sessionAuth'] = data._kmd.authtoken;
        sessionStorage['userId'] = data._id;
        sessionStorage['username'] = data.username;
        sessionStorage['fullName'] = data.fullName;
    }

    function clearSessionStorage() {
        delete sessionStorage['sessionAuth'];
        delete sessionStorage['userId'];
        delete sessionStorage['username'];
        delete sessionStorage['fullName'];
    }

    return {
        load: function (model, viewBag, messages) {
            return new UserController(model, viewBag, messages);
        }
    }
}());