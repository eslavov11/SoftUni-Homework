var app = app || {};

app.userController = (function() {
    function UserController(viewBag, model, constants) {
        this.model = model;
        this.viewBag = viewBag;
        this.constants = constants;
    }

    UserController.prototype.loadLoginPage = function(selector) {
        this.viewBag.showLoginPage(selector);
    };

    UserController.prototype.login = function(data) {
        var _this = this;

        return this.model.login(data)
            .then(function(success) {
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;

                app.notyInfoMessage(_this.constants.LOGIN_SUCCESS_MSG);
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'});
                });

            }, function (error) {
                app.notyErrorMessage(_this.constants.LOGIN_INVALID_DATA_MSG);

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/login/'});
                });
            }).done();
    };


    UserController.prototype.loadRegisterPage = function(selector) {
        this.viewBag.showRegisterPage(selector);
    };

    UserController.prototype.register = function(data) {
        var _this = this;

        if (data.password !== data.confirmPassword) {
            app.notyErrorMessage(_this.constants.REGISTER_MISMATCH_PASSWORDS_MSG);
            Sammy(function() {
                this.trigger('redirectUrl', {url: '#/register/'});
            });
            return;
        }

        var registerData = {
            username: data.username,
            password: data.password
        },
        _this = this;;

        return this.model.register(registerData)
            .then(function(success) {
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;

                app.notyInfoMessage(_this.constants.REGISTER_SUCCESS_MSG);
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/home/'});
                });
            }, function (error) {
                app.notyErrorMessage(_this.constants.REGISTER_EXISTING_USER_MSG);

                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/register/'});
                });
            }).done();
    };

    UserController.prototype.logout = function() {
        var _this = this;

        this.model.logout()
            .then(function() {
                sessionStorage.clear();

                app.notyInfoMessage(_this.constants.LOGOUT_MSG);
                Sammy(function() {
                    this.trigger('redirectUrl', {url: '#/'});
                });
            })
    };

    return {
        load: function(viewBag, model, constants) {
            return new UserController(viewBag, model, constants);
        }
    }
}());