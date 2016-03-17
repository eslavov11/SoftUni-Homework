var app = app || {};

app.userViews = (function () {
    function showLoginPage(selector) {
        $.get('templates/login.html', function(templ) {
            $(selector).html(templ);
            $('#loginButton').on('click', function(e) {
                var username = $('#username').val(),
                    password = $('#password').val();
                Sammy(function() {
                    this.trigger('login', {username: username, password: password});
                })
            })
        })
    }

    function showRegisterPage(selector) {
        $.get('templates/register.html', function(templ) {
            $(selector).html(templ);
            $('#registerButton').on('click', function(e) {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    fullName = $('#fullName').val();

                Sammy(function() {
                    this.trigger('register', {username: username, password: password, fullName: fullName});
                })
            })
        })
    }

    function showEditProfilePage(selector) {
        $.get('templates/edit-user.html', function(templ) {
            $(selector).html(templ);
            $('#editProfileButton').on('click', function(e) {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    fullName = $('#fullName').val();

                Sammy(function() {
                    this.trigger('edit', {username: username, password: password, fullName: fullName});
                })
            })
        })
    }


    return {
        load: function() {
            return {
                showLoginPage: showLoginPage,
                showRegisterPage: showRegisterPage,
                showEditProfilePage: showEditProfilePage
            }
        }
    }
}());