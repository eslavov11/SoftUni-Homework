var app = app || {};

app.userViews = (function () {
    function showRegisterPage(selector) {
        $.get('templates/register.html', function (template) {
            $(selector).html(template);
            $('#register').on('click', function (e) {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    confirmPass = $('#confirm-password').val();

                if (password === confirmPass) {
                    Sammy(function () {
                        this.trigger('register', { username: username, password: password, isAdmin: false });
                    });
                }
            });
        });
    }

    function showLoginPage(selector) {
        $.get('templates/login.html', function (template) {
            $(selector).html(template);
            $('#login').on('click', function (e) {
                var username = $('#username').val(),
                    password = $('#password').val();
                    
                Sammy(function () {
                    this.trigger('login', { username: username, password: password });
                });              
            });
        });
    }

    return {
        load: function () {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage
            }
        }
    };

})();