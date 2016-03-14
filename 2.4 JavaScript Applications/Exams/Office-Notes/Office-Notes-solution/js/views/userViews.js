var app = app || {};

app.userViews = (function() {
    function UserViews() {
        this.loadLoginView = loadLoginView;
        this.loadRegisterView = loadRegisterView;
    }

    function loadLoginView (selector) {
        $.get('templates/login.html', function(template) {
            var outHtml = Mustache.render(template);
            $(selector).html(outHtml);
        }).then(function() {
            $('#loginButton').click(function() {
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
            $('#registerButton').click(function() {
                var username = $('#username').val();
                var password = $('#password').val();
                var fullName = $('#fullName').val();

                $.sammy(function() {
                    this.trigger('register', {username: username, password: password, fullName: fullName});
                });

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