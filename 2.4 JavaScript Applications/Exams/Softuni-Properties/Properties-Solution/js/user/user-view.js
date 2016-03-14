var app = app || {};

app.userViews = (function() {
    function UserViews() {
        this.loginView = {
            loadLoginView: loadLoginView
        };
        this.registerView = {
            loadRegisterView: loadRegisterView
        };
    }

    function loadLoginView (selector) {
        $.get('templates/login.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        }).then(function() {
            $('#login-button').click(function() {
                var username = $('#username').val();
                var password = $('#password').val();

                $.sammy(function() {
                    this.trigger('login', {username: username, password: password});
                });
                return false;
            })
        }).done();

    }

    function loadRegisterView (selector) {
        $.get('templates/register.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        }).then(function() {
            $('#register-button').click(function() {
                var username = $('#username');
                var password = $('#password');
                var repeatPass = $('#confirm-password');

                if(repeatPass.val() !== password.val()) {
                    noty({
                        theme: 'relax',
                        text: 'Passwords do not match!',
                        type:'error',
                        timeout: 2000,
                        closeWith: ['click']
                    });
                    password.val('');
                    repeatPass.val('');
                } else {
                    $.sammy(function() {
                        this.trigger('register', {username: username.val(), password: password.val()});
                    });
                }

                return false;
            })
        }).done();
    }

    return {
        load: function() {
            return new UserViews();
        }
    }
}());